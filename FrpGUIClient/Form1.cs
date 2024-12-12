using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Reflection;

namespace FrpGUIClient
{
    public partial class Form1 : Form
    {
        private Process frpProcess = null;
        private BackgroundWorker bgWorker = new BackgroundWorker();
        private bool stopRequested = false;
        private int maxRetries = 10;
        
        public Form1()
        {
            InitializeComponent();

            ExtractFRPC();
            
            bgWorker.WorkerSupportsCancellation = true;
            bgWorker.DoWork += BgWorker_DoWork;
            bgWorker.ProgressChanged += BgWorker_ProgressChanged;
            bgWorker.RunWorkerCompleted += BgWorker_RunWorkerCompleted;
            bgWorker.WorkerReportsProgress = true;

            LoadConfig();

            if (checkBox1.Checked)
            {
                buttonStart_Click(buttonStart, EventArgs.Empty);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void ExtractFRPC()
        {
            var assembly = Assembly.GetExecutingAssembly();
            // frpc를 프로젝트에 '포함 리소스'로 추가하여야 합니다.
            string resourceName = "FrpGUIClient.frpc.exe";
            
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    MessageBox.Show("리소스에서 frpc.exe를 불러오지 못했습니다.");
                    return;
                }

                string exePath = Application.StartupPath;
                string tempPath = Path.Combine(exePath, "frpc.exe");
                using (FileStream fs = new FileStream(tempPath, FileMode.Create, FileAccess.Write))
                {
                    stream.CopyTo(fs);
                    richTextBoxOutput.AppendText("리소스에서 frpc.exe를 불러왔습니다.\n");
                }
            }
        }

        private void LoadConfig()
        {
            if (File.Exists("frpc.ini"))
            {
                var lines = File.ReadAllLines("frpc.ini", Encoding.UTF8);
                string section = "";
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    if (line.StartsWith("[") && line.EndsWith("]"))
                    {
                        section = line.Trim('[', ']');
                        continue;
                    }

                    var parts = line.Split(new char[] { '=' }, 2);
                    if (parts.Length == 2)
                    {
                        string key = parts[0].Trim();
                        string val = parts[1].Trim();

                        if (section == "common")
                        {
                            if (key == "server_addr") textBoxServerAddr.Text = val;
                            if (key == "server_port") textBoxServerPort.Text = val;
                            if (key == "token") textBoxAuthToken.Text = val;
                            if (key == "auto_start") checkBox1.Checked = Convert.ToBoolean(val);
                        }
                        else
                        {
                            // 첫 번째 프록시 섹션
                            textBoxDeviceName.Text = section;
                            if (key == "local_port") textBoxLocalPort.Text = val;
                            if (key == "remote_port") textBoxRemotePort.Text = val;
                        }
                    }
                }
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (frpProcess != null && !frpProcess.HasExited)
            {
                MessageBox.Show("frpc가 이미 실행 중입니다.", "경고");
                return;
            }

            // 필수 입력값 체크
            if (string.IsNullOrWhiteSpace(textBoxServerAddr.Text))
            {
                MessageBox.Show("서버 주소를 입력하세요.", "오류");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxServerPort.Text))
            {
                MessageBox.Show("서버 포트를 입력하세요.", "오류");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxLocalPort.Text))
            {
                MessageBox.Show("로컬 포트를 입력하세요.", "오류");
                return;
            }

            if (!ValidatePort(textBoxServerPort.Text))
            {
                MessageBox.Show("서버 포트는 1에서 65535 사이의 숫자여야 합니다.", "오류");
                return;
            }
            if (!ValidatePort(textBoxLocalPort.Text))
            {
                MessageBox.Show("로컬 포트는 1에서 65535 사이의 숫자여야 합니다.", "오류");
                return;
            }

            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
            stopRequested = false;

            if (!bgWorker.IsBusy)
            {
                richTextBoxOutput.Clear();
                bgWorker.RunWorkerAsync();
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            StopFrp();
        }

        private void StopFrp()
        {
            stopRequested = true;
            if (frpProcess != null && !frpProcess.HasExited)
            {
                try
                {
                    frpProcess.Kill();
                    frpProcess.WaitForExit();
                }
                catch { }
            }
            frpProcess = null;
            richTextBoxOutput.AppendText("frpc가 중지되었습니다.\n");
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
        }

        private bool ValidatePort(string portStr)
        {
            int port;
            if (int.TryParse(portStr, out port))
            {
                if (port >= 1 && port <= 65535) return true;
            }
            return false;
        }

        private int GetValidPortOrRandom(string portStr)
        {
            if (string.IsNullOrWhiteSpace(portStr))
            {
                // 랜덤 포트 할당
                var rand = new Random();
                return rand.Next(10000, 65535);
            }

            int port;
            if (int.TryParse(portStr, out port))
            {
                if (port >= 1 && port <= 65535) return port;
            }
            return -1; // invalid
        }

        private string GenerateProxyName()
        {
            var name = textBoxDeviceName.Text.Trim().Replace(" ", "");
            if (string.IsNullOrEmpty(name))
            {
                var rand = new Random();
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                name = new string(Enumerable.Repeat(chars, 10).Select(s => s[rand.Next(s.Length)]).ToArray());
            }
            return name;
        }

        private void GenerateConfig(int remotePort, string proxyName)
        {
            // frpc.ini 파일 생성
            using (var sw = new StreamWriter("frpc.ini", false, Encoding.UTF8))
            {
                sw.WriteLine("[common]");
                sw.WriteLine($"server_addr = {textBoxServerAddr.Text.Trim()}");
                sw.WriteLine($"server_port = {textBoxServerPort.Text.Trim()}");
                sw.WriteLine($"token = {textBoxAuthToken.Text.Trim()}");
                sw.WriteLine($"auto_start = {checkBox1.Checked.ToString()}");
                sw.WriteLine();
                sw.WriteLine($"[{proxyName}]");
                sw.WriteLine("type = tcp");
                sw.WriteLine($"local_port = {textBoxLocalPort.Text.Trim()}");
                sw.WriteLine($"remote_port = {remotePort}");
            }
        }

        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int retries = 0;
            bool portAssigned = false;

            while (retries < maxRetries && !portAssigned && !stopRequested)
            {
                int remotePort = GetValidPortOrRandom(textBoxRemotePort.Text.Trim());
                if (remotePort == -1)
                {
                    // 유효하지 않은 포트 입력 시 바로 중단
                    ReportLog("원격 포트는 1에서 65535 사이의 숫자여야 합니다.\n");
                    break;
                }

                string proxyName = GenerateProxyName();
                GenerateConfig(remotePort, proxyName);

                // frpc 실행 파일 경로 설정 (현재 디렉토리 가정)
                string frpExecutable = "frpc.exe";
                string frpFullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, frpExecutable);

                if (!File.Exists(frpFullPath))
                {
                    ReportLog($"frp 실행 파일을 찾을 수 없습니다: {frpFullPath}\n");
                    break;
                }

                ReportLog($"원격 포트(remote_port): {remotePort}로 시도 중...\n");

                // 기존 프로세스 종료
                if (frpProcess != null && !frpProcess.HasExited)
                {
                    try
                    {
                        frpProcess.Kill();
                        frpProcess.WaitForExit();
                    }
                    catch { }
                }

                var psi = new ProcessStartInfo
                {
                    FileName = frpFullPath,
                    Arguments = "-c frpc.ini",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    StandardOutputEncoding = Encoding.UTF8,
                    StandardErrorEncoding = Encoding.UTF8
                };

                frpProcess = Process.Start(psi);

                bool portInUse = false;
                bool startSuccess = false;

                if (frpProcess != null)
                {
                    // 초기 출력 모니터링
                    while (!frpProcess.HasExited)
                    {
                        if (bgWorker.CancellationPending || stopRequested)
                            break;
                        string line = frpProcess.StandardOutput.ReadLine();
                        if (line == null) break;

                        HandleLogLine(line);
                        if (line.Contains("port already used") ||
                            line.Contains("the proxy is already in use") ||
                            Regex.IsMatch(line, "proxy .* already exists"))
                        {
                            portInUse = true;
                            break;
                        }
                        if (line.Contains("start proxy success"))
                        {
                            startSuccess = true;
                            portAssigned = true;
                            break;
                        }
                        if (line.Contains("start error"))
                        {
                            portInUse = true;
                            break;
                        }
                    }

                    if (portInUse)
                    {
                        ReportLog($"포트 {remotePort}는 이미 사용 중입니다. 다른 포트로 재시도합니다.\n");
                        try
                        {
                            frpProcess.Kill();
                            frpProcess.WaitForExit();
                        }
                        catch { }
                        retries++;
                        // 다음 루프에서 랜덤 포트
                        this.Invoke((Action)(() => { textBoxRemotePort.Text = ""; }));
                        continue;
                    }
                    else if (!startSuccess)
                    {
                        // 다른 에러
                        try
                        {
                            frpProcess.Kill();
                            frpProcess.WaitForExit();
                        }
                        catch { }
                        break;
                    }

                    if (startSuccess)
                    {
                        // 성공적으로 시작된 경우 원격 포트 업데이트
                        this.Invoke((Action)(() =>
                        {
                            textBoxRemotePort.Text = remotePort.ToString();
                        }));

                        // 성공 후 지속적으로 로그 모니터링
                        while (!frpProcess.HasExited)
                        {
                            if (bgWorker.CancellationPending || stopRequested)
                                break;
                            string line = frpProcess.StandardOutput.ReadLine();
                            if (line == null) break;
                            HandleLogLine(line);
                        }

                        // 종료 시까지 기다림
                        frpProcess.WaitForExit();
                    }
                }
            }

            if (!portAssigned && !stopRequested)
            {
                ReportLog("frpc를 시작할 수 없습니다. 재시도 횟수를 초과했습니다.\n");
            }
            else if (portAssigned && !stopRequested)
            {
                ReportLog($"원격 포트(remote_port): {textBoxRemotePort.Text}로 frpc가 시작되었습니다.\n");
            }
        }

        private void HandleLogLine(string line)
        {
            line = RemoveAnsiEscape(line);
            // 상태 파싱
            if (line.Contains("start frpc service for config file"))
                ReportLog("frpc 서비스를 시작합니다.\n");
            else if (line.Contains("try to connect to server"))
                ReportLog("서버에 연결을 시도합니다...\n");
            else if (line.Contains("login to server success"))
                ReportLog("서버에 성공적으로 로그인했습니다.\n");
            else if (line.Contains("start proxy success"))
                ReportLog("프록시가 성공적으로 시작되었습니다.\n");
            else if (line.Contains("client exit success"))
                ReportLog("클라이언트가 성공적으로 종료되었습니다.\n");

            // 일반 로그 라인도 출력
            ReportLog(line + "\n");
        }

        private string RemoveAnsiEscape(string line)
        {
            var ansiEscape = new Regex(@"\x1B\[[0-?]*[ -/]*[@-~]");
            return ansiEscape.Replace(line, "");
        }

        private void ReportLog(string message)
        {
            if (bgWorker.CancellationPending) return;
            bgWorker.ReportProgress(0, message);
        }

        private void BgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string msg = e.UserState as string;
            if (msg != null)
            {
                richTextBoxOutput.AppendText(msg);
                richTextBoxOutput.SelectionStart = richTextBoxOutput.Text.Length;
                richTextBoxOutput.ScrollToCaret();
            }
        }

        private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!stopRequested)
            {
                buttonStart.Enabled = true;
                buttonStop.Enabled = false;
            }
        }

        private void 창보이기ShowWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = true;
        }

        private void 종료ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frpProcess != null && !frpProcess.HasExited)
            {
                var result = MessageBox.Show("현재 연결이 끊어집니다. 종료하시겠습니까?", "종료 확인", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    StopFrp();
                    this.notifyIcon1.Visible = false;
                    int remotePort;
                    int.TryParse(textBoxRemotePort.Text.Trim(), out remotePort);
                    string proxyName = textBoxDeviceName.Text.Trim();
                    GenerateConfig(remotePort, proxyName);
                    Application.Exit();
                }
            }
            else
            {
                this.notifyIcon1.Visible = false;
                int remotePort;
                int.TryParse(textBoxRemotePort.Text.Trim(), out remotePort);
                string proxyName = textBoxDeviceName.Text.Trim();
                GenerateConfig(remotePort, proxyName);
                Application.Exit();
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = true;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
