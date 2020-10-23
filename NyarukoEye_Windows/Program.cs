using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace NyarukoEye_Windows
{
    class Program
    {
        static private int debuglevel = 4;
        static private string tempdir = "";
        static private string imgType = "";
        static private int imgTypeID = 0;
        static private int sleepTime = 600000;
        static private string prefix = "";
        static private string name = "";
        static private int screenW;
        static private int screenH;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run();
            AppDomain appd = AppDomain.CurrentDomain;
            appd.ProcessExit += (s, e) =>
            {
                printf("退出。");
                Thread.Sleep(1000); // 停3秒
            };
            string fileDir = Environment.CurrentDirectory;
            printf("当前程序目录：" + fileDir);
            string[] IniFileDirArr = Directory.GetFiles(fileDir, "*.ini");
            if (IniFileDirArr.Length == 0)
            {
                printf("找不到配置文件！", 3);
                return -1;
            }
            string IniFileDir = IniFileDirArr[0];
            printf("加载配置文件：" + IniFileDir);
            INIClass ini = new INIClass(IniFileDir);
            if (!ini.ExistINIFile())
            {
                printf("找不到配置文件！", 3);
                return -1;
            }
            screenW = Screen.PrimaryScreen.Bounds.Width;
            screenH = Screen.PrimaryScreen.Bounds.Height;
            printf("主屏幕像素：" + screenW.ToString() + " × " + screenH.ToString());
            tempdir = ini.IniReadValue("Work", "TempDir");
            if (tempdir.Length == 0)
            {
                string temp = Environment.GetEnvironmentVariable("TEMP");
                DirectoryInfo info = new DirectoryInfo(temp);
                tempdir = info.FullName;
            }
            printf("临时文件夹：" + tempdir);
            imgType = ini.IniReadValue("Image", "Type");
            if (imgType.Length == 0)
            {
                imgType = "jpg";
            }
            switch (imgType)
            {
                case "bmp":
                    imgTypeID = 1;
                    break;
                case "png":
                    imgTypeID = 2;
                    break;
                case "tif":
                    imgTypeID = 3;
                    break;
                case "gif":
                    imgTypeID = 4;
                    break;
                default:
                    imgTypeID = 0;
                    break;
            }
            printf("文件格式：" + imgType);
            prefix = ini.IniReadValue("Work", "Prefix");
            if (prefix.Length == 0)
            {
                prefix = "NyarukoEye_";
            }
            else
            {
                prefix = prefix + "_";
            }
            printf("文件前缀：" + prefix);
            name = ini.IniReadValue("Work", "Name");
            if (name.Length == 0)
            {
                name = Environment.MachineName + "." + Environment.UserDomainName + "." + Environment.UserName + "_";
            }
            else
            {
                name = name + "_";
            }
            printf("用户名：" + name);
            string sleepTimeSec = ini.IniReadValue("Work", "Sleep");
            int sleepTimeSecInt = 60;
            if (sleepTimeSec.Length > 0)
            {
                sleepTimeSecInt = int.Parse(sleepTimeSec);
                sleepTime = sleepTimeSecInt * 1000;
            }
            printf("间隔时间（秒）：" + sleepTimeSecInt.ToString());
            printf("初始化完成。");
            Application.Run();
            return 0;
        }
        static private void printf(string txt, uint level = 1)
        {
            if (4 - level > debuglevel) return;
            string[] leveltext = new string[4] { "D", "I", "W", "E" };
            string printtext = "[" + DateTime.Now.ToString() + "][" + leveltext[level] + "] " + txt;
            Console.WriteLine(printtext);
        }
        ~Program()
        {
            printf("退出。");
        }
    }
}
