using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace NyarukoEye_Windows
{
    static public class Enc
    {
        static public string opensslPath = "openssl";
        static public string error = "";
        static public bool getError = true;
        static public bool debug = false;
        static public string[] getOpensslPaths()
        {
            Process p = new Process();
            p.StartInfo.FileName = "where";
            p.StartInfo.Arguments = "openssl";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = getError;
            p.StartInfo.CreateNoWindow = true;
            if (debug) Console.WriteLine(p.StartInfo.FileName + " " + p.StartInfo.Arguments);
            p.Start();
            p.WaitForExit();
            string pout = p.StandardOutput.ReadToEnd();
            p.StandardOutput.Close();
            if (getError)
            {
                error = p.StandardError.ReadToEnd();
                p.StandardError.Close();
            }
            p.Close();
            string[] openssls = pout.Split('\n');
            if (openssls[0].IndexOf(".exe") == -1)
            {
                string[] voidArr = { };
                return voidArr;
            }
            return openssls.Where(s => s.IndexOf(".exe") > 0).ToArray();
        }
        static public bool isErrorInfo()
        {
            if (error.Length > 0) return true;
            return false;
        }
        static public string getErrorOnce()
        {
            string einfo = error;
            error = "";
            return einfo;
        }
        static public string genPrivateKey(int length = 1024, string outFile = "")
        {
            Process p = new Process();
            p.StartInfo.FileName = opensslPath;
            List<string> arguments = new List<string>();
            arguments.Add("genrsa");
            if (outFile.Length > 0)
            {
                arguments.Add("-out");
                arguments.Add("\"" + outFile + "\"");
            }
            arguments.Add(length.ToString());
            p.StartInfo.Arguments = string.Join(" ", arguments);
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = getError;
            p.StartInfo.CreateNoWindow = true;
            if (debug) Console.WriteLine(p.StartInfo.FileName + " " + p.StartInfo.Arguments);
            p.Start();
            p.WaitForExit();
            string pout = p.StandardOutput.ReadToEnd();
            p.StandardOutput.Close();
            if (getError)
            {
                error = p.StandardError.ReadToEnd();
                p.StandardError.Close();
            }
            p.Close();
            return pout;
        }
        static public string getPublicKey(string privateKey, bool privateKeyIsPath = false, string outFile = "")
        {
            Process p = new Process();
            p.StartInfo.FileName = opensslPath;
            List<string> arguments = new List<string>();
            arguments.Add("rsa");
            if (privateKeyIsPath)
            {
                arguments.Add("-in");
                arguments.Add("\"" + privateKey + "\"");
            }
            arguments.Add("-pubout");
            if (outFile.Length > 0)
            {
                arguments.Add("-out");
                arguments.Add("\"" + outFile + "\"");
            }
            p.StartInfo.Arguments = string.Join(" ", arguments);
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = !privateKeyIsPath;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = getError;
            p.StartInfo.CreateNoWindow = true;
            if (debug) Console.WriteLine(p.StartInfo.FileName + " " + p.StartInfo.Arguments);
            p.Start();
            if (!privateKeyIsPath)
            {
                p.StandardInput.WriteLine(privateKey);
                p.StandardInput.Close();
            }
            p.WaitForExit();
            if (privateKeyIsPath) return "";
            string pout = p.StandardOutput.ReadToEnd();
            p.StandardOutput.Close();
            if (getError)
            {
                error = p.StandardError.ReadToEnd();
                p.StandardError.Close();
            }
            p.Close();
            return pout;
        }
        static public string encryptData(string pubilcKeyPath, string source, bool sourceIsPath = false, string outFile = "")
        {
            Process p = new Process();
            p.StartInfo.FileName = opensslPath;
            List<string> arguments = new List<string>();
            arguments.Add("rsautl");
            arguments.Add("-encrypt");
            if (sourceIsPath)
            {
                arguments.Add("-in");
                arguments.Add("\"" + source + "\"");
            }
            arguments.Add("-inkey");
            arguments.Add("\"" + pubilcKeyPath + "\"");
            arguments.Add("-pubin");
            if (outFile.Length > 0)
            {
                arguments.Add("-out");
                arguments.Add("\"" + outFile + "\"");
            }
            p.StartInfo.Arguments = string.Join(" ", arguments);
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = !sourceIsPath;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = getError;
            p.StartInfo.CreateNoWindow = true;
            if (debug) Console.WriteLine(p.StartInfo.FileName + " " + p.StartInfo.Arguments);
            p.Start();
            if (!sourceIsPath)
            {
                p.StandardInput.WriteLine(source);
                p.StandardInput.Close();
            }
            p.WaitForExit();
            if (outFile.Length > 0) return "";
            string pout = p.StandardOutput.ReadToEnd();
            if (getError)
            {
                error = p.StandardError.ReadToEnd();
                p.StandardError.Close();
            }
            p.StandardOutput.Close();
            p.Close();
            return pout;
        }
        static public string decryptionData(string privateKeyPath, string source, bool sourceIsPath = false, string outFile = "")
        {
            Process p = new Process();
            p.StartInfo.FileName = opensslPath;
            List<string> arguments = new List<string>();
            arguments.Add("rsautl");
            arguments.Add("-decrypt");
            if (sourceIsPath)
            {
                arguments.Add("-in");
                arguments.Add("\"" + source + "\"");
            }
            arguments.Add("-inkey");
            arguments.Add("\"" + privateKeyPath + "\"");
            if (outFile.Length > 0)
            {
                arguments.Add("-out");
                arguments.Add("\"" + outFile + "\"");
            }
            p.StartInfo.Arguments = string.Join(" ", arguments);
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = !sourceIsPath;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = getError;
            p.StartInfo.CreateNoWindow = true;
            if (debug) Console.WriteLine(p.StartInfo.FileName + " " + p.StartInfo.Arguments);
            p.Start();
            if (!sourceIsPath)
            {
                p.StandardInput.WriteLine(source);
                p.StandardInput.Close();
            }
            p.WaitForExit();
            if (outFile.Length > 0) return "";
            string pout = p.StandardOutput.ReadToEnd();
            p.StandardOutput.Close();
            if (getError)
            {
                error = p.StandardError.ReadToEnd();
                p.StandardError.Close();
            }
            p.Close();
            return pout;
        }
        static public string getAESkey(int length = 32, string outFile = "")
        {
            Process p = new Process();
            p.StartInfo.FileName = opensslPath;
            List<string> arguments = new List<string>();
            arguments.Add("rand");
            arguments.Add("-base64");
            arguments.Add(length.ToString());
            p.StartInfo.Arguments = string.Join(" ", arguments);
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = getError;
            p.StartInfo.CreateNoWindow = true;
            if (debug) Console.WriteLine(p.StartInfo.FileName + " " +p.StartInfo.Arguments);
            p.Start();
            p.WaitForExit();
            string pout = p.StandardOutput.ReadToEnd();
            p.StandardOutput.Close();
            if (getError)
            {
                error = p.StandardError.ReadToEnd();
                p.StandardError.Close();
            }
            p.Close();
            pout = pout.Replace("\r\n", "\n");
            if (outFile.Length > 0) File.WriteAllText(outFile, pout);
            return pout;
        }
        static public string encryptAESData(string aesKeyPath, string source, bool sourceIsPath = false, string encmode = "aes-256-cbc", string outFile = "")
        {
            Process p = new Process();
            p.StartInfo.FileName = opensslPath;
            List<string> arguments = new List<string>();
            arguments.Add("enc");
            arguments.Add("-" + encmode);
            arguments.Add("-pbkdf2");
            arguments.Add("-salt");
            if (sourceIsPath)
            {
                arguments.Add("-in");
                arguments.Add("\"" + source + "\"");
            }
            if (outFile.Length > 0)
            {
                arguments.Add("-out");
                arguments.Add("\"" + outFile + "\"");
            }
            arguments.Add("-pass");
            arguments.Add("\"file:" + aesKeyPath + "\"");
            p.StartInfo.Arguments = string.Join(" ", arguments);
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = !sourceIsPath;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = getError;
            p.StartInfo.CreateNoWindow = true;
            if (debug) Console.WriteLine(p.StartInfo.FileName + " " + p.StartInfo.Arguments);
            p.Start();
            if (!sourceIsPath)
            {
                p.StandardInput.WriteLine(source);
                p.StandardInput.Close();
            }
            p.WaitForExit();
            if (outFile.Length > 0) return "";
            string pout = p.StandardOutput.ReadToEnd();
            if (getError)
            {
                error = p.StandardError.ReadToEnd();
                p.StandardError.Close();
            }
            p.StandardOutput.Close();
            p.Close();
            return pout;
        }

        static public string decryptionAESData(string aesKeyPath, string source, bool sourceIsPath = false, string encmode = "aes-256-cbc", string outFile = "")
        {
            Process p = new Process();
            p.StartInfo.FileName = opensslPath;
            List<string> arguments = new List<string>();
            arguments.Add("enc");
            arguments.Add("-d");
            arguments.Add("-" + encmode);
            arguments.Add("-pbkdf2");
            if (sourceIsPath)
            {
                arguments.Add("-in");
                arguments.Add("\"" + source + "\"");
            }
            if (outFile.Length > 0)
            {
                arguments.Add("-out");
                arguments.Add("\"" + outFile + "\"");
            }
            arguments.Add("-pass");
            arguments.Add("\"file:" + aesKeyPath + "\"");
            p.StartInfo.Arguments = string.Join(" ", arguments);
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = !sourceIsPath;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = getError;
            p.StartInfo.CreateNoWindow = true;
            if (debug) Console.WriteLine(p.StartInfo.FileName + " " + p.StartInfo.Arguments);
            p.Start();
            if (!sourceIsPath)
            {
                p.StandardInput.WriteLine(source);
                p.StandardInput.Close();
            }
            p.WaitForExit();
            if (outFile.Length > 0) return "";
            string pout = p.StandardOutput.ReadToEnd();
            if (getError)
            {
                error = p.StandardError.ReadToEnd();
                p.StandardError.Close();
            }
            p.StandardOutput.Close();
            p.Close();
            return pout;
        }
    }
}
