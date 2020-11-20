using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace NELauncher
{
    public partial class Form1 : Form
    {
        static private string exeName = "scrchk.exe";
        static private Thread eyeThread;
        static private Process p;
        static private Action<String> listBoxDelegate;
        static private Action<String> stopDelegate;
        static private bool stoping = false;
        private const int WM_HOTKEY = 0x312; //窗口消息-热键
        private const int WM_CREATE = 0x1; //窗口消息-创建
        private const int WM_DESTROY = 0x2; //窗口消息-销毁
        private const int Space = 0x3572; //热键ID
        public Form1()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case WM_HOTKEY: //窗口消息-热键ID
                    switch (m.WParam.ToInt32())
                    {
                        case Space: //热键ID
                            winonoff();
                            break;
                        default:
                            break;
                    }
                    break;
                case WM_CREATE: //窗口消息-创建
                    HotKeys.RegKey(Handle, Space, HotKeys.KeyModifiers.Ctrl | HotKeys.KeyModifiers.Shift | HotKeys.KeyModifiers.Alt, Keys.F11);
                    break;
                case WM_DESTROY: //窗口消息-销毁
                    HotKeys.UnRegKey(Handle, Space); //销毁热键
                    break;
                default:
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists(exeName))
            {
                menuStrip1.Enabled = false;
                //listBox1.Items.Add("[" + DateTime.Now.ToString() + "] 找不到可执行文件： " + exeName);
                Application.Exit();
                return;
            }
            listBoxDelegate = delegate (string n)
            {
                if (n != null)
                {
                    listBox1.Items.Add(n);
                    if (listBox1.Items.Count > 100)
                    {
                        listBox1.Items.RemoveAt(0);
                    }
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                }
            };
            stopDelegate = delegate (string n)
            {
                listBox1.Items.Add("--- ! ---");
                listBox1.Items.Add("[" + DateTime.Now.ToString() + "] 后台进程退出");
                stop();
                start();
                listBox1.Items.Add("--- ! ---");
            };
            start();
            winonoff(0);
        }

        private void winonoff(Int16 mode = -1)
        {
            bool sw = !ShowInTaskbar;
            if (mode == 0)
            {
                sw = false;
            }
            else if (mode == 1)
            {
                sw = true;
            }
            ShowInTaskbar = sw;
            Visible = sw;
        }

        private void start()
        {
            启动服务ToolStripMenuItem.Enabled = false;
            menuStrip1.Enabled = false;
            listBox1.Items.Add("[" + DateTime.Now.ToString() + "] 正在启动后台...");
            ThreadStart eyeRef = new ThreadStart(eyeThreadRun);
            eyeThread = new Thread(eyeRef);
            eyeThread.Name = "eyeThread";
            eyeThread.Start();
            listBox1.Items.Add("[" + DateTime.Now.ToString() + "] 后台已启动。");
            Thread.Sleep(1000);
            menuStrip1.Enabled = true;
            停止服务ToolStripMenuItem.Enabled = true;
        }
        private void stop()
        {
            if (menuStrip1.Enabled == false) return;
            停止服务ToolStripMenuItem.Enabled = false;
            menuStrip1.Enabled = false;
            stoping = true;
            listBox1.Items.Add("[" + DateTime.Now.ToString() + "] 正在停止后台...");
            if (!p.HasExited) p.Kill();
            Process ps = new Process();
            List<string> arguments = new List<string>();
            arguments.Add("/f");
            arguments.Add("/im");
            arguments.Add(exeName);
            ps.StartInfo.FileName = "taskkill";
            ps.StartInfo.Arguments = string.Join(" ", arguments);
            ps.StartInfo.UseShellExecute = false;
            ps.StartInfo.RedirectStandardInput = false;
            ps.StartInfo.RedirectStandardOutput = true;
            ps.StartInfo.RedirectStandardError = false;
            ps.StartInfo.CreateNoWindow = true;
            ps.Start();
            ps.WaitForExit();
            string pout = ps.StandardOutput.ReadToEnd();
            listBox1.Invoke(listBoxDelegate, new object[] { pout });
            ps.Close();
            if (eyeThread != null && eyeThread.IsAlive) eyeThread.Abort();
            eyeThread = null;
            listBox1.Items.Add("[" + DateTime.Now.ToString() + "] 后台已停止。");
            Thread.Sleep(1000);
            stoping = false;
            menuStrip1.Enabled = true;
            启动服务ToolStripMenuItem.Enabled = true;
        }

        private void OnDataReceived(object sender, DataReceivedEventArgs e)
        {
            listBox1.Invoke(listBoxDelegate, new object[] { e.Data });
        }

        private void OnExited(object sender, EventArgs e)
        {
            listBox1.Invoke(listBoxDelegate, new object[] { "后台退出。" });
            if (!stoping) Invoke(stopDelegate, new object[] { "" });
        }

        private void eyeThreadRun()
        {
            p = new Process();
            p.StartInfo.FileName = exeName;
            //List<string> arguments = new List<string>();
            //arguments.Add("");
            //p.StartInfo.Arguments = string.Join(" ", arguments);
            p.StartInfo.UseShellExecute = false;
            //p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            //p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.EnableRaisingEvents = true;
            p.OutputDataReceived += OnDataReceived;
            p.Exited += OnExited;
            p.Start();
            p.BeginOutputReadLine();
        }

        private void 启动服务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            start();
        }

        private void 停止服务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stop();
        }

        private void 重启服务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stop();
            start();
        }

        private void 结束退出F4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stop();
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Opacity = 1.00;
            timer1.Enabled = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            stop();
        }
    }
}
