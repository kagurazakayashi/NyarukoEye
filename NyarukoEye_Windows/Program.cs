using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace NyarukoEye_Windows
{
    class Program
    {
        static private int debuglevel = 4;
        static private string tempdir = "";
        static private string imgType = "";
        static private string encType = "";
        static private string keyType = "";
        static private string encKeyType = "";
        static private string symmetric = "";
        static private string uUsername = "";
        static private string uPassword = "";
        static private string uURL = "";
        static private int aesLength = 0;
        static private string publicKey = "";
        static private ImageFormat imgFormat;
        static private int sleepTime = 600000;
        static private int workSleepTime = 1000;
        static private string prefix = "";
        static private string name = "";
        static private UInt64 threadID = 0;
        static private string allTempPath = "";
        static private bool screenshotThreadWorking = false;
        static private bool encryptThreadWorking = false;
        static private bool netuploadThreadWorking = false;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            AppDomain appd = AppDomain.CurrentDomain;
            Process[] processes = System.Diagnostics.Process.GetProcessesByName(Application.CompanyName);
            if (processes.Length > 1)
            {
                printf("已经有一个实例正在运行。");
                Thread.Sleep(1000);
                Environment.Exit(1);
            }
            appd.ProcessExit += (s, e) =>
            {
                printf("退出。");
                Thread.Sleep(1000);
            };
            Console.CancelKeyPress += delegate
            {
                printf("停止...");
                screenshotThreadWorking = false;
                Environment.Exit(1);
                return;
            };
            string fileDir = Environment.CurrentDirectory;
            printf("当前程序目录：" + fileDir);
            string[] IniFileDirArr = Directory.GetFiles(fileDir, "*.ini");
            if (IniFileDirArr.Length == 0)
            {
                printf("找不到配置文件！", 3);
                return -1;
            }
            string[] opensslPaths = Enc.getOpensslPaths();
            if (opensslPaths.Length == 0)
            {
                printf("找不到 OpenSSL ！", 3);
            }
            else
            {
                Enc.opensslPath = opensslPaths[0];
                printf("OpenSSL：" + opensslPaths[0]);
            }
            Enc.debug = debuglevel == 4;
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
            prefix = ini.IniReadValue("User", "Prefix");
            if (prefix.Length == 0)
            {
                prefix = "NyarukoEye";
            }
            printf("文件前缀：" + prefix);
            tempdir = ini.IniReadValue("Work", "TempDir");
            if (tempdir.Length == 0)
            {
                string temp = Environment.GetEnvironmentVariable("TEMP");
                DirectoryInfo info = new DirectoryInfo(temp);
                tempdir = info.FullName + "\\" + prefix;
            }
            prefix += "_";
            if (!Directory.Exists(tempdir)) Directory.CreateDirectory(tempdir);
            printf("临时文件夹：" + tempdir);
            imgType = ini.IniReadValue("File", "Type");
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
            encType = ini.IniReadValue("File", "EncType");
            printf("加密文件格式：" + encType);
            keyType = ini.IniReadValue("File", "KeyType");
            printf("对称密钥文件格式：" + keyType);
            encKeyType = ini.IniReadValue("File", "EncKeyType");
            printf("被加密的对称密钥文件存储格式：" + encKeyType);
            publicKey = ini.IniReadValue("Encrypt", "PublicKey");
            printf("公钥：" + publicKey);
            name = ini.IniReadValue("User", "Name");
            if (name.Length == 0)
            {
                name = GetNumberAlpha(Environment.MachineName + Environment.UserDomainName + Environment.UserName) + "_";
            }
            else
            {
                name = name + "_";
            }
            symmetric = ini.IniReadValue("Encrypt", "Symmetric");
            printf("对称加密算法：" + symmetric);
            string lengthI = ini.IniReadValue("Encrypt", "AESLength");
            aesLength = int.Parse(lengthI);
            printf("对称加密长度：" + lengthI);
            printf("用户名：" + name);
            string sleepTimeSec = ini.IniReadValue("Work", "Sleep");
            int sleepTimeSecInt = 60;
            if (sleepTimeSec.Length > 0)
            {
                sleepTimeSecInt = int.Parse(sleepTimeSec);
                sleepTime = sleepTimeSecInt * 1000;
            }
            uUsername = ini.IniReadValue("User", "Username");
            printf("上载用户名：" + uUsername);
            uPassword = ini.IniReadValue("User", "Password");
            printf("上载密码：<*>");
            uURL = ini.IniReadValue("Network", "UploadURL");
            printf("上载URL：" + uURL);
            printf("间隔时间（秒）：" + sleepTimeSecInt.ToString());
            sleepTimeSec = ini.IniReadValue("Work", "WorkSleep");
            sleepTimeSecInt = 1;
            if (sleepTimeSec.Length > 0)
            {
                sleepTimeSecInt = int.Parse(sleepTimeSec);
                workSleepTime = sleepTimeSecInt * 1000;
            }
            printf("批量处理间隔时间（秒）：" + sleepTimeSecInt.ToString());
            ThreadStart screenshotRef = new ThreadStart(screenshotThreadRun);
            Thread screenshotThread = new Thread(screenshotRef);
            screenshotThread.Name = "screenshotThread" + (threadID++).ToString();
            screenshotThread.Start();
            printf("初始化完成。");
            Application.Run();
            return 0;
        }
        static private string[] getTempFiles(string fileExtName)
        {
            allTempPath = prefix + name + "*." + fileExtName;
            DirectoryInfo folder = new DirectoryInfo(tempdir);
            FileInfo[] files = folder.GetFiles(allTempPath);
            string[] filesFullName = new string[files.Length];
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo nowFile = files[i];
                string nowFilePath = nowFile.FullName;
                filesFullName[i] = nowFilePath;
            }
            return filesFullName;
        }

        private static string GetNumberAlpha(string source)
        {
            string pattern = "[A-Za-z0-9]";
            string strRet = "";
            MatchCollection results = Regex.Matches(source, pattern);
            foreach (var v in results)
            {
                strRet += v.ToString();
            }
            return strRet;
        }

        static private void screenshotThreadRun()
        {
            screenshotThreadWorking = true;
            string nowThreadID = threadID.ToString();
            printf("启动屏幕截图线程 " + nowThreadID + " ...", 0);
            while (screenshotThreadWorking)
            {
                printf("进行屏幕截图...", 0);
                printf("屏幕截图完成 " + getScreenshot(), 0);
                if (!encryptThreadWorking && publicKey.Length > 0)
                {
                    ThreadStart encryptRef = new ThreadStart(encryptThreadRun);
                    Thread encryptThread = new Thread(encryptRef);
                    encryptThread.Name = "encryptThread" + (threadID++).ToString();
                    encryptThread.Start();
                }
                Thread.Sleep(sleepTime);
            }
            printf("结束屏幕截图线程 " + nowThreadID + " 。", 0);
            screenshotThreadWorking = false;
            printf("退出。");
            Environment.Exit(1);
        }
        static private void encryptThreadRun()
        {
            encryptThreadWorking = true;
            string nowThreadID = threadID.ToString();
            printf("启动文件加密线程 " + nowThreadID + " ...", 0);
            foreach (string file in getTempFiles(imgType))
            {
                printf("正在处理文件 " + file + " ...", 0);
                string[] extFileName = file.Split('.');
                extFileName[extFileName.Length - 1] = keyType;
                string aesKey = string.Join(".", extFileName);
                extFileName[extFileName.Length - 1] = encType;
                string encFile = string.Join(".", extFileName);
                extFileName[extFileName.Length - 1] = encKeyType;
                string encKeyFile = string.Join(".", extFileName);
                printf("生成对称密钥 " + aesKey + " ...", 0);
                Enc.getAESkey(aesLength, aesKey);
                string err = Enc.getErrorOnce();
                if (err.Length > 0)
                {
                    printf(err, 3);
                    return;
                }
                printf("使用对称密钥加密文件到 " + encFile + " ...", 0);
                Enc.encryptAESData(aesKey, file, true, symmetric, encFile);
                err = Enc.getErrorOnce();
                if (err.Length > 0)
                {
                    printf(err, 3);
                    return;
                }
                printf("加密对称密钥到 " + encKeyFile + " ...", 0);
                Enc.encryptData(publicKey, aesKey, true, encKeyFile);
                err = Enc.getErrorOnce();
                if (err.Length > 0)
                {
                    printf(err, 3);
                    return;
                }
                printf("删除未加密密钥 " + aesKey + " ...", 0);
                if (File.Exists(aesKey)) File.Delete(aesKey);
                printf("删除未加密文件 " + file + " ...", 0);
                if (File.Exists(file)) File.Delete(file);
                if (!netuploadThreadWorking && uURL.Length > 0)
                {
                    ThreadStart encryptRef = new ThreadStart(uploadThreadRun);
                    Thread encryptThread = new Thread(encryptRef);
                    encryptThread.Name = "encryptThread" + (threadID++).ToString();
                    encryptThread.Start();
                }
                Thread.Sleep(workSleepTime);
            }
            printf("结束文件加密线程 " + nowThreadID + " 。", 0);
            encryptThreadWorking = false;
        }
        static private void uploadThreadRun()
        {
            netuploadThreadWorking = true;
            string nowThreadID = threadID.ToString();
            printf("启动网络上载线程 " + nowThreadID + " ...", 0);
            foreach (string file in getTempFiles(encType))
            {
                printf("正在处理文件 " + file + " ...", 0);
                string[] extFileName = file.Split('.');
                extFileName[extFileName.Length - 1] = encKeyType;
                string kFile = string.Join(".", extFileName);
                if (File.Exists(kFile))
                {
                    string[] fileList = { file, kFile };
                    Dictionary<string, string> netArgv = new Dictionary<string, string>();
                    netArgv.Add("userName", uUsername);
                    netArgv.Add("password", uPassword);
                    netArgv.Add("extension", imgType);
                    string[] result = NetUL.httpUploadFile(uURL, fileList, netArgv);
                    string resultErr = result[0];
                    string resultInfo = result[1];
                    if (resultErr != null && resultErr.Length > 0)
                    {
                        printf(resultErr, 3);
                        return;
                    }
                    string msg = "";
                    switch (resultInfo)
                    {
                        case "100":
                            msg = "上传成功"; break;
                        case "101":
                            msg = "上传成功，原文件删除失败"; break;
                        case "200":
                            msg = "用户名或密码不正确"; break;
                        case "202":
                            msg = "创建文件失败"; break;
                        case "203":
                            msg = "保存文件失败"; break;
                        case "204":
                            msg = "解密失败"; break;
                        default:
                            msg = "返回信息"; break;
                    }
                    msg = resultInfo + msg;
                    printf(msg, 0);
                    printf("删除已上传数据文件 " + file + " ...", 0);
                    if (File.Exists(file)) File.Delete(file);
                    printf("删除已上传密钥文件 " + kFile + " ...", 0);
                    if (File.Exists(kFile)) File.Delete(kFile);
                }
                else if (File.Exists(file))
                {
                    File.Delete(file);
                }
                Thread.Sleep(workSleepTime);
            }
            printf("结束网络上载线程 " + nowThreadID + " 。", 0);
            netuploadThreadWorking = false;
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
