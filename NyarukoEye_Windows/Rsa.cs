using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
//PM > Install - Package BouncyCastle
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;

namespace NyarukoEye_Windows
{
    static class Rsa
    {
        private static RSACryptoServiceProvider RSACSPrivate = new RSACryptoServiceProvider();
        private static RSACryptoServiceProvider RSACSPublic = new RSACryptoServiceProvider();
        //新建私鑰
        public static void newPrivateKey(string privateKeyPath = "PrivateKey.xml")
        {
            string xmlString = RSACSPrivate.ToXmlString(true);
            if (privateKeyPath.Length == 0)
            {
                RSACSPrivate.FromXmlString(xmlString);
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(privateKeyPath))
                {
                    writer.WriteLine(xmlString);
                }
            }
        }
        //新建公鑰
        public static void newPublicKey(string publicKeyPath = "PublicKey.xml")
        {
            string xmlString = RSACSPublic.ToXmlString(false);
            if (publicKeyPath.Length == 0)
            {
                RSACSPublic.FromXmlString(xmlString);
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(publicKeyPath))
                {
                    writer.WriteLine(xmlString);
                }
            }

        }
        //載入 XML 格式私鑰
        public static void loadXmlPrivateKey(string privateXmlKeyPath = "PrivateKey.xml")
        {
            using (var sr = new StreamReader(privateXmlKeyPath))
            {
                RSACSPrivate.FromXmlString(sr.ReadToEnd());
            }
        }
        //載入 PEM 格式私鑰（會有一個轉換過程）
        public static void loadPemPrivateKey(string privatePemKeyPath = "PrivateKey.pem")
        {
            string xmlString;
            using (var sr = new StreamReader(privatePemKeyPath))
            {
                xmlString = sr.ReadToEnd();
            }
            privateKeyPem2Xml(privatePemKeyPath, "");
        }
        //載入 XML 格式公鑰
        public static void loadXmlPublicKey(string publicXmlKeyPath = "PrivateKey.xml")
        {
            using (var sr = new StreamReader(publicXmlKeyPath))
            {
                RSACSPublic.FromXmlString(sr.ReadToEnd());
            }
        }
        //XML 私鑰轉換為 PEM 私鑰（應先載入私鑰）
        public static void privateKeyXml2Pem(string privatePemKeyPath = "PrivateKey.pem")
        {
            var p = RSACSPrivate.ExportParameters(true);
            var key = new RsaPrivateCrtKeyParameters(
                new BigInteger(1, p.Modulus), new BigInteger(1, p.Exponent), new BigInteger(1, p.D),
                new BigInteger(1, p.P), new BigInteger(1, p.Q), new BigInteger(1, p.DP), new BigInteger(1, p.DQ),
                new BigInteger(1, p.InverseQ));
            using (var sw = new StreamWriter(privatePemKeyPath))
            {
                var pemWriter = new Org.BouncyCastle.OpenSsl.PemWriter(sw);
                pemWriter.WriteObject(key);
            }
        }
        //PEM 私鑰轉換為 XML 私鑰（應先載入私鑰，privateXmlKeyPath 如果为空则不保存文件，仅加载）
        public static void privateKeyPem2Xml(string privatePemKeyPath = "PrivateKey.pem", string privateXmlKeyPath = "PrivateKey.xml")
        {
            AsymmetricCipherKeyPair keyPair;
            using (var sr = new StreamReader(privatePemKeyPath))
            {
                var pemReader = new Org.BouncyCastle.OpenSsl.PemReader(sr);
                keyPair = (AsymmetricCipherKeyPair)pemReader.ReadObject();
            }
            var key = (RsaPrivateCrtKeyParameters)keyPair.Private;
            var p = new RSAParameters
            {
                Modulus = key.Modulus.ToByteArrayUnsigned(),
                Exponent = key.PublicExponent.ToByteArrayUnsigned(),
                D = key.Exponent.ToByteArrayUnsigned(),
                P = key.P.ToByteArrayUnsigned(),
                Q = key.Q.ToByteArrayUnsigned(),
                DP = key.DP.ToByteArrayUnsigned(),
                DQ = key.DQ.ToByteArrayUnsigned(),
                InverseQ = key.QInv.ToByteArrayUnsigned(),
            };
            var rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(p);
            string xmlString = rsa.ToXmlString(true);
            RSACSPrivate.FromXmlString(xmlString);
            if (privateXmlKeyPath.Length > 0)
            {
                using (var sw = new StreamWriter(privateXmlKeyPath))
                {
                    sw.Write(xmlString);
                }
            }
        }
        //使用公鑰加密內容（應先載入公鑰）
        public static string rsaEncrypt(string content)
        {
            byte[] cipherbytes;
            cipherbytes = RSACSPublic.Encrypt(Encoding.UTF8.GetBytes(content), false);
            return Convert.ToBase64String(cipherbytes);
        }
        //使用私鑰解密內容（應先載入私鑰）
        public static string rsaDecrypt(string content)
        {
            byte[] cipherbytes;
            cipherbytes = RSACSPrivate.Decrypt(Convert.FromBase64String(content), false);
            return Encoding.UTF8.GetString(cipherbytes);
        }
    }
}
