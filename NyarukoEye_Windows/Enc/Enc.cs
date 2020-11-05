using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace NyarukoEye_Windows
{
    static public class Enc
    {
        static public string opensslPath = "openssl";
        static public string[] getOpensslPaths()
        {
            Process p = new Process();
            p.StartInfo.FileName = "where";
            p.StartInfo.Arguments = "openssl";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.WaitForExit();
            string pout = p.StandardOutput.ReadToEnd();
            string[] openssls = pout.Split('\n');
            if (openssls[0].IndexOf(".exe") == -1)
            {
                string[] voidArr = { };
                return voidArr;
            }
            return openssls.Where(s => s.IndexOf(".exe") > 0).ToArray();
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
                arguments.Add(outFile);
            }
            arguments.Add(length.ToString());
            p.StartInfo.Arguments = string.Join(" ", arguments);
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.WaitForExit();
            string pout = p.StandardOutput.ReadToEnd();
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
                arguments.Add("-inFile");
            }
            arguments.Add("-pubout");
            if (outFile.Length > 0)
            {
                arguments.Add("-out");
                arguments.Add(outFile);
            }
            p.StartInfo.Arguments = string.Join(" ", arguments);
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = !privateKeyIsPath;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            if (!privateKeyIsPath) p.StandardInput.WriteLine(privateKey);
            p.WaitForExit();
            if (privateKeyIsPath) return "";
            string pout = p.StandardOutput.ReadToEnd();
            return pout;
        }
        
    }
}
