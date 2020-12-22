using System;
using System.Net;
using System.Text.RegularExpressions;

namespace BaseNetwork
{
    public class BaseNetwork
    {
        protected CookieContainer _cookies = new CookieContainer();
        protected WebProxy _proxy = new WebProxy();
        public string Proxy
        {
            get => _proxy?.Address?.Authority;
            set
            {
                Uri p = null;
                try
                {
                    if (!string.IsNullOrEmpty(value) && Regex.IsMatch(value,@"^([A-Za-z0-9]+\.)+[A-Za-z0-9]+(:\d+)*$"))
                        p = new Uri($"http://{value}");
                }
                catch { }
                _proxy.Address = p;
            }
        }
        public HttpWebRequest CreateHttp(string method, string requestUri)
        {
            HttpWebRequest http = WebRequest.CreateHttp(requestUri);

            {
                http.Method = method;
                http.CookieContainer = _cookies;
                http.Proxy = _proxy;
                http.Timeout = 15000;
                http.ReadWriteTimeout = 15000;
                http.ContentType = @"application/x-www-form-urlencoded";
                http.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                //http.ServicePoint.Expect100Continue = false;

                http.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.88 Safari/537.36";
                http.Headers.Set("Accept-Language", "zh-CN,zh;q=0.9");
                //http.Headers.Set("Accept-Encoding", "gzip,deflate,br");
                http.Headers.Set("Cache-Control", "max-age=0");
                http.Headers.Set("Upgrade-Insecure-Requests", "1");
                http.Headers.Set("DNT", "1");
                http.Headers.Set("Sec-Fetch-Site", "same-origin");
                http.Headers.Set("Sec-Fetch-Mode","navigate");
                http.Headers.Set("Sec-Fetch-User","?1"); 
                http.Headers.Set("Sec-Fetch-Dest","document");
            }
            return http;
        }
    }
}
