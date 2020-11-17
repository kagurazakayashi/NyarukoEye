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

namespace NELauncher
{
    public partial class Form1 : Form
    {
        static private Thread eyeThread;
        static private Process p;
        static private Action<String> listBoxDelegate;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBoxDelegate = delegate (string n) {
                listBox1.Items.Add(n);
                if (listBox1.Items.Count > 100)
                {
                    listBox1.Items.RemoveAt(0);
                }
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            };
            start();
        }

        private void start()
        {
            启动服务ToolStripMenuItem.Enabled = false;
            menuStrip1.Enabled = false;
            ThreadStart eyeRef = new ThreadStart(eyeThreadRun);
            eyeThread = new Thread(eyeRef);
            eyeThread.Name = "eyeThread";
            eyeThread.Start();
            Thread.Sleep(1000);
            menuStrip1.Enabled = true;
            停止服务ToolStripMenuItem.Enabled = true;
        }
        private void stop()
        {
            停止服务ToolStripMenuItem.Enabled = false;
            menuStrip1.Enabled = false;
            if (eyeThread.IsAlive) eyeThread.Abort();
            eyeThread = null;
            Thread.Sleep(1000);
            menuStrip1.Enabled = true;
            启动服务ToolStripMenuItem.Enabled = true;
        }

        private void OnDataReceived(object sender, DataReceivedEventArgs e)
        {
            listBox1.Invoke(listBoxDelegate, new object[] { e.Data });
        }

        private void OnExited(object sender, EventArgs e)
        {
            listBox1.Invoke(listBoxDelegate, new object[] { e.ToString() }) ;
        }

        private void eyeThreadRun()
        {
            p = new Process();
            p.StartInfo.FileName = "NyarukoEye_Windows.exe";
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

        ~Form1()
        {
            stop();
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
    }
}
