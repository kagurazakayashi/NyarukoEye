using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Autorun
{
    public partial class Form1 : Form
    {
        private string defaultExe = "NELauncher.exe";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = defaultExe;
            openFileDialog1.Filter = "可执行文件|*.exe|所有文件|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK && File.Exists(openFileDialog1.FileName))
            {
                txtPath.Text = openFileDialog1.FileName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string fileDir = Environment.CurrentDirectory;
            DirectoryInfo folder = new DirectoryInfo(fileDir);
            FileInfo[] files = folder.GetFiles("*.exe");
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo nowFile = files[i];
                string nowFilePath = nowFile.FullName;
                txtPath.Items.Add(nowFilePath);
                if (nowFile.Name.Equals(defaultExe)) txtPath.Text = nowFilePath;
            }
            radioUser.Text = "为当前用户 " + Environment.UserName + " 设置开机启动 (&U)";
            radioSys.Text = "为当前计算机 " + Environment.MachineName + " 的所有用户设置开机启动 (&S)";
        }

        private void txtPath_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            if (btnOn.Enabled = btnOff.Enabled = (txtPath.Text.Length > 0 && File.Exists(txtPath.Text)))
            {
                FileInfo file = new FileInfo(txtPath.Text);
                //if (txtName.Text.Length == 0)
                txtName.Items.Clear();
                txtName.Items.Add(file.Name);
                txtName.Text = file.Name;
            }
        }

        private void btnOn_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true); //打开注册表项
                if (key == null) //如果该项不存在的话，则创建该项
                {
                    key = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                }
                key.SetValue(txtName.Text, '"' + txtPath.Text + '"'); //设置为开机启动
                key.Close();
                btnOn.Enabled = false;
                btnOff.Enabled = true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "设置启动项失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (key != null)
                {
                    key.DeleteValue(txtName.Text);
                }
                key.Close();
                btnOff.Enabled = false;
                btnOn.Enabled = true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "取消启动项失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
