using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConfigEditerServer
{
    public partial class Form1 : Form
    {
        private string nowOpenJson = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "rsa_server_conf.json";
            openFileDialog1.Filter = "JSON 配置文件|*.json|所有文件|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK && File.Exists(openFileDialog1.FileName))
            {
                nowOpenJson = openFileDialog1.FileName;
                Text = "服务端配置编辑器 - " + nowOpenJson;
                openJson();
                保存SToolStripMenuItem.Enabled = true;
            }
        }

        private void openJson()
        {
            try
            {
                string jsonStr = File.ReadAllText(nowOpenJson);
                JsonReader reader = new JsonTextReader(new StringReader(jsonStr));
                string k = "";
                while (reader.Read())
                {
                    if (reader.Value != null)
                    {
                        if (reader.TokenType == JsonToken.PropertyName)
                        {
                            k = reader.Value.ToString();
                        }
                        else
                        {
                            string v = reader.Value.ToString();
                            Console.WriteLine(k + "\t\t" + v);
                            loadJsonKey(k, v);
                            k = "";
                        }
                    }
                }
                gURL();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "加载配置文件失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadJsonKey(string k, string v)
        {
            string unkown = "";
            switch (k)
            {
                case "handlepath":
                    s_handlepath.Text = v;
                    break;
                case "listenandserve":
                    s_listenandserve.Value = int.Parse(v);
                    break;
                case "filepath":
                    s_filepath.Text = v;
                    break;
                case "uname":
                    s_uname.Text = v;
                    break;
                case "password":
                    s_password.Text = v;
                    break;
                default:
                    unkown += k + "\n";
                    break;
            }
            if (unkown.Length > 0) MessageBox.Show("设置程序无法识别以下键值：\n" + unkown + "\n这些设置将在保存后丢失，请确定版本和配置文件匹配。", "配置文件版本不匹配", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void saveJson(string path)
        {
            try
            {
                StringWriter sw = new StringWriter();
                JsonWriter writer = new JsonTextWriter(sw);
                writer.WriteStartObject();
                writer.WritePropertyName("handlepath");
                writer.WriteValue(s_handlepath.Text);
                writer.WritePropertyName("listenandserve");
                writer.WriteValue(s_listenandserve.Value.ToString());
                writer.WritePropertyName("filepath");
                writer.WriteValue(s_filepath.Text);
                writer.WritePropertyName("uname");
                writer.WriteValue(s_uname.Text);
                writer.WritePropertyName("password");
                writer.WriteValue(s_password.Text);
                writer.WriteEndObject();
                writer.Flush();
                string jsonText = sw.GetStringBuilder().ToString();
                File.WriteAllText(path, jsonText);
                nowOpenJson = path;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "保存配置文件失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveJson(nowOpenJson);
        }

        private void 另存为AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "rsa_server_conf.json";
            saveFileDialog1.Filter = "JSON 配置文件|*.json|所有文件|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveJson(saveFileDialog1.FileName);
            }
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gURL()
        {
            t_URL.Text = s_protocol.Text + "://<您的服务器域名或IP地址>:" + s_listenandserve.Value.ToString() + "/" + s_handlepath.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gURL();
        }

        private void s_url_TextChanged(object sender, EventArgs e)
        {
            gURL();
        }

        private void s_listenandserve_ValueChanged(object sender, EventArgs e)
        {
            gURL();
        }

        private void s_handlepath_TextChanged(object sender, EventArgs e)
        {
            gURL();
        }

        private void s_protocol_TextChanged(object sender, EventArgs e)
        {
            gURL();
        }

        private void cPublicKeyB_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                s_filepath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("要先保存文件吗？", "正在退出", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (nowOpenJson.Length > 0)
                {
                    saveJson(nowOpenJson);
                }
                else
                {
                    另存为AToolStripMenuItem_Click(sender, e);
                }
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
