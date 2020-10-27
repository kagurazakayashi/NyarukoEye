using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace NyarukoEye_Windows
{
    class Program
    {
        static private int debuglevel = 4;
        static private string tempdir = "";
        static private string imgType = "";
        static private ImageFormat imgFormat;
        static private int sleepTime = 600000;
        static private string prefix = "";
        static private string name = "";
        static private UInt64 threadID = 0;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
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
            INI ini = new INI(IniFileDir);
            if (!ini.ExistINIFile())
            {
                printf("找不到配置文件！", 3);
                return -1;
            }
            int screenW = Screen.PrimaryScreen.Bounds.Width;
            int screenH = Screen.PrimaryScreen.Bounds.Height;
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
                    imgFormat = ImageFormat.Bmp;
                    break;
                case "png":
                    imgFormat = ImageFormat.Png;
                    break;
                case "tif":
                    imgFormat = ImageFormat.Tiff;
                    break;
                case "gif":
                    imgFormat = ImageFormat.Gif;
                    break;
                default:
                    imgFormat = ImageFormat.Jpeg;
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
            printf("启动屏幕截图线程 " + threadID.ToString() + " ...", 0);
            ThreadStart screenshotRef = new ThreadStart(screenshotThreadRun);
            Thread screenshotThread = new Thread(screenshotRef);
            screenshotThread.Name = "screenshotThread" + (threadID++).ToString();
            screenshotThread.Start();
            printf("初始化完成。");
            Application.Run();
            return 0;
        }
        static private void screenshotThreadRun()
        {
            while (true)
            {
                printf("进行屏幕截图...", 0);
                printf("屏幕截图完成 " + getScreenshot(), 0);
                printf("启动文件加密线程 "+ threadID.ToString() + " ...", 0);
                ThreadStart encryptRef = new ThreadStart(encryptThreadRun);
                Thread encryptThread = new Thread(encryptRef);
                encryptThread.Name = "encryptThread" + (threadID++).ToString();
                encryptThread.Start();
                Thread.Sleep(sleepTime);
            }
        }
        static private void encryptThreadRun()
        {
            printf("加密线程.", 0);
        }
        static private string getScreenshot()
        {
            string time = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
            string filePath = tempdir + "\\" + prefix + name + time + "." + imgType;
            Screenshot.saveScreenshot(filePath, imgFormat);
            return filePath;
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
