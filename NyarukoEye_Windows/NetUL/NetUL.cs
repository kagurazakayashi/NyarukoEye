using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using RestSharp;

namespace NyarukoEye_Windows
{
    static public class NetUL
    {
        static public string[] httpUploadFile(string url, string[] files, Dictionary<string, string> stringDict = null)
        {
            RestClientOptions options = new RestClientOptions(url)
            {
                Timeout = TimeSpan.FromSeconds(30),
            };
            RestClient client = new RestClient(options);
            RestRequest request = new RestRequest(url, Method.Post);

            foreach (KeyValuePair<string,string> item in stringDict)
            {
                request.AddParameter(item.Key, item.Value);
            }
            foreach (string item in files)
            {
                request.AddFile("files", item);
            }
            RestResponse response = client.GetAsync(request).Result;
            string[] r = { response.ErrorMessage, response.Content };
            return r;
        }
        static public string[] httpUploadFile2(string url, string[] files, Dictionary<string, string> stringDict = null)
        {
            // HttpContext context
            // 参考 http://www.cnblogs.com/greenerycn/archive/2010/05/15/csharp_http_post.html
            var memStream = new MemoryStream();
            // 边界符
            var boundary = "---------------" + DateTime.Now.Ticks.ToString("x");
            var beginBoundary = Encoding.ASCII.GetBytes("--" + boundary + "\r\n");
            // 文件参数头              
            foreach (var item in files)
            {
                string filePath = item;
                string fileName = Path.GetFileName(item);
                var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                var fileHeaderBytes = Encoding.UTF8.GetBytes($"Content-Disposition: form-data; name=\"{"files"}\"; filename=\"{fileName}\"\r\nContent-Type: application/octet-stream\r\n\r\n");

                // 开始拼数据
                memStream.Write(beginBoundary, 0, beginBoundary.Length);

                // 文件数据
                memStream.Write(fileHeaderBytes, 0, fileHeaderBytes.Length);
                var buffer = new byte[1024];
                int bytesRead;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    memStream.Write(buffer, 0, bytesRead);
                }
                fileStream.Close();
                //必须得写入一个换行
                byte[] bytes = Encoding.UTF8.GetBytes($"\r\n");
                memStream.Write(bytes, 0, bytes.Length);
            }
            // Key-Value数据           
            if (stringDict != null)
            {
                var startBoundary = Encoding.ASCII.GetBytes("\r\n"); // 结束符
                memStream.Write(startBoundary, 0, startBoundary.Length);
                foreach (var item in stringDict)
                {
                    string name = item.Key;
                    string value = item.Value;
                    string kv = $"--{boundary}\r\nContent-Disposition: form-data; name=\"{name}\"\r\n\r\n{value}\r\n";
                    byte[] bytes = Encoding.UTF8.GetBytes(kv);
                    memStream.Write(bytes, 0, bytes.Length);
                }
            }
            // 写入最后的结束边界符            
            var endBoundary = Encoding.ASCII.GetBytes("--" + boundary + "--\r\n"); // 最后的结束符
            memStream.Write(endBoundary, 0, endBoundary.Length);
            // 写入到tempBuffer
            memStream.Position = 0;
            var tempBuffer = new byte[memStream.Length];
            memStream.Read(tempBuffer, 0, tempBuffer.Length);
            memStream.Close();
            // 创建webRequest并设置属性
            var webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "POST";
            webRequest.Timeout = 100000;
            webRequest.ContentType = "multipart/form-data; boundary=" + boundary;
            webRequest.ContentLength = tempBuffer.Length;
            string responseContent;
            try
            {
                Stream requestStream = webRequest.GetRequestStream();
                requestStream.Write(tempBuffer, 0, tempBuffer.Length);
                requestStream.Close();
                var httpWebResponse = (HttpWebResponse)webRequest.GetResponse();
                using (var httpStreamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding("utf-8")))
                {
                    responseContent = httpStreamReader.ReadToEnd();
                }
                httpWebResponse.Close();
            }
            catch (Exception e)
            {
                string[] er = { e.Message, "" };
                return er;
            }
            webRequest.Abort();
            string[] r = { "", responseContent };
            return r;
        }
    }
}
