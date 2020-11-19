using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
//PM > Install - Package BouncyCastle
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;

namespace NyarukoEye_Windows
{
    static public class RsaTool
    {
        public static RSACryptoServiceProvider RSACSPrivate = new RSACryptoServiceProvider();
        public static RSACryptoServiceProvider RSACSPublic = new RSACryptoServiceProvider();
        //新建私鑰
        public static string newPrivateKey(string privateKeyPath = "PrivateKey.xml")
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
            return xmlString;
        }
        //新建公鑰
        public static string newPublicKey(string publicKeyPath = "PublicKey.xml")
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
            return xmlString;
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
            privateKeyPem2Xml2(privatePemKeyPath, "");
        }
        //載入 XML 格式公鑰
        public static void loadXmlPublicKey(string publicXmlKeyPath = "PrivateKey.xml")
        {
            using (var sr = new StreamReader(publicXmlKeyPath))
            {
                RSACSPublic.FromXmlString(sr.ReadToEnd());
            }
        }
        //載入 PEM 格式公鑰
        public static void loadPemPublicKey(string publicXmlKeyPath = "PrivateKey.pub")
        {
            using (var sr = new StreamReader(publicXmlKeyPath))
            {
                RSACSPublic.FromXmlString(publicKeyPem2Xml(sr.ReadToEnd()));
            }
        }
        //XML 私鑰轉換為 PEM 私鑰
        public static string privateKeyXml2Pem(string privateXmlKeyString)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(privateXmlKeyString);
            BigInteger m = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("Modulus")[0].InnerText));
            BigInteger exp = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("Exponent")[0].InnerText));
            BigInteger d = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("D")[0].InnerText));
            BigInteger p = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("P")[0].InnerText));
            BigInteger q = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("Q")[0].InnerText));
            BigInteger dp = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("DP")[0].InnerText));
            BigInteger dq = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("DQ")[0].InnerText));
            BigInteger qinv = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("InverseQ")[0].InnerText));
            RsaPrivateCrtKeyParameters privateKeyParam = new RsaPrivateCrtKeyParameters(m, exp, d, p, q, dp, dq, qinv);
            PrivateKeyInfo privateKeyInfo = PrivateKeyInfoFactory.CreatePrivateKeyInfo(privateKeyParam);
            byte[] serializedPrivateBytes = privateKeyInfo.ToAsn1Object().GetEncoded();
            return "-----BEGIN RSA PRIVATE KEY-----\n" + Convert.ToBase64String(serializedPrivateBytes) + "\n-----END RSA PRIVATE KEY-----";
        }
        //XML 私鑰轉換為 PEM 私鑰（應先載入私鑰）
        public static void privateKeyXml2Pem2(string privatePemKeyPath = "PrivateKey.pem")
        {
            var p = RSACSPrivate.ExportParameters(true);
            var key = new RsaPrivateCrtKeyParameters(
                new BigInteger(1, p.Modulus), new BigInteger(1, p.Exponent), new BigInteger(1, p.D),
                new BigInteger(1, p.P), new BigInteger(1, p.Q), new BigInteger(1, p.DP), new BigInteger(1, p.DQ),
                new BigInteger(1, p.InverseQ));
            if (privatePemKeyPath.Length > 0)
            {
                using (var sw = new StreamWriter(privatePemKeyPath))
                {
                    var pemWriter = new Org.BouncyCastle.OpenSsl.PemWriter(sw);
                    pemWriter.WriteObject(key);
                }
            }
        }
        //PEM 私鑰轉換為 XML 私鑰
        public static string privateKeyPem2Xml(string privatePemKeyString)
        {
            RsaPrivateCrtKeyParameters privateKeyParam = (RsaPrivateCrtKeyParameters)PrivateKeyFactory.CreateKey(Convert.FromBase64String(privatePemKeyString));
            return string.Format("<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent><P>{2}</P><Q>{3}</Q><DP>{4}</DP><DQ>{5}</DQ><InverseQ>{6}</InverseQ><D>{7}</D></RSAKeyValue>",
                Convert.ToBase64String(privateKeyParam.Modulus.ToByteArrayUnsigned()),
                Convert.ToBase64String(privateKeyParam.PublicExponent.ToByteArrayUnsigned()),
                Convert.ToBase64String(privateKeyParam.P.ToByteArrayUnsigned()),
                Convert.ToBase64String(privateKeyParam.Q.ToByteArrayUnsigned()),
                Convert.ToBase64String(privateKeyParam.DP.ToByteArrayUnsigned()),
                Convert.ToBase64String(privateKeyParam.DQ.ToByteArrayUnsigned()),
                Convert.ToBase64String(privateKeyParam.QInv.ToByteArrayUnsigned()),
                Convert.ToBase64String(privateKeyParam.Exponent.ToByteArrayUnsigned()));
        }
        //PEM 私鑰轉換為 XML 私鑰（應先載入私鑰，privateXmlKeyPath 如果为空则不保存文件，仅加载）
        public static void privateKeyPem2Xml2(string privatePemKeyPath = "PrivateKey.pem", string privateXmlKeyPath = "PrivateKey.xml")
        {
            AsymmetricCipherKeyPair keyPair;
            using (StreamReader sr = new StreamReader(privatePemKeyPath))
            {
                var pemReader = new Org.BouncyCastle.OpenSsl.PemReader(sr);
                keyPair = (AsymmetricCipherKeyPair)pemReader.ReadObject();
            }
            RsaPrivateCrtKeyParameters key = (RsaPrivateCrtKeyParameters)keyPair.Private;
            RSAParameters p = new RSAParameters
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
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(p);
            string xmlString = rsa.ToXmlString(true);
            RSACSPrivate.FromXmlString(xmlString);
            if (privateXmlKeyPath.Length > 0)
            {
                using (StreamWriter sw = new StreamWriter(privateXmlKeyPath))
                {
                    sw.Write(xmlString);
                }
            }
        }
        //PEM 公鑰轉換為 XML 公鑰
        public static string publicKeyPem2Xml(string publicPemKeyString)
        {
            RsaKeyParameters publicKeyParam = (RsaKeyParameters)PublicKeyFactory.CreateKey(Convert.FromBase64String(publicPemKeyString));
            return string.Format("<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent></RSAKeyValue>",
                Convert.ToBase64String(publicKeyParam.Modulus.ToByteArrayUnsigned()),
                Convert.ToBase64String(publicKeyParam.Exponent.ToByteArrayUnsigned()));
        }
        //XML 公鑰轉換為 PEM 公鑰
        public static string publicKeyXml2Pem(string publicXmlKeyString)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(publicXmlKeyString);
            BigInteger m = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("Modulus")[0].InnerText));
            BigInteger p = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("Exponent")[0].InnerText));
            RsaKeyParameters pub = new RsaKeyParameters(false, m, p);
            SubjectPublicKeyInfo publicKeyInfo = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(pub);
            byte[] serializedPublicBytes = publicKeyInfo.ToAsn1Object().GetDerEncoded();
            return "-----BEGIN PUBLIC KEY-----\n" + Convert.ToBase64String(serializedPublicBytes) + "\n-----END PUBLIC KEY-----";
        }
        //使用公鑰加密內容（應先載入公鑰）
        public static string rsaEncrypt(string content)
        {
            //byte[] cipherbytes;
            //cipherbytes = RSACSPublic.Encrypt(Encoding.UTF8.GetBytes(content), false);
            //return Convert.ToBase64String(cipherbytes);
            byte[] PlainTextBArray = Encoding.UTF8.GetBytes("加密的内容");
            byte[] CypherTextBArray = RSACSPublic.Encrypt(PlainTextBArray, false);
            string EncryptedContent = Convert.ToBase64String(CypherTextBArray);
            return EncryptedContent;
        }
        //使用私鑰解密內容（應先載入私鑰）
        public static string rsaDecrypt(string content)
        {
            //byte[] cipherbytes;
            //cipherbytes = RSACSPrivate.Decrypt(Convert.FromBase64String(content), false);
            //return Encoding.UTF8.GetString(cipherbytes);
            byte[] PlainTextBArray = Convert.FromBase64String(content);
            byte[] DypherTextBArray = RSACSPrivate.Decrypt(PlainTextBArray, false);
            string dContent = Encoding.UTF8.GetString(DypherTextBArray);
            return dContent;
        }
    }
}
