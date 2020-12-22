using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace BaseNetwork
{
    public class Ehall : BaseNetwork
    {
        private string _token;
        private string _pid;
        private string _sid;
        private string _data = "";
        public void Init() {
            HttpWebRequest http = CreateHttp("GET", "https://ehall.jlu.edu.cn/sso/login");
            try
            {
                http.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
                using (HttpWebResponse response = http.GetResponse() as HttpWebResponse)
                {
                    string result = response.GetResponseString();
                    string str = Regex.Match(result, "name=\"pid\" value=\"[a-zA-Z0-9]*\"").Groups[0].Value;
                    _pid = Regex.Match(str, "[a-zA-Z0-9]{8}").Groups[0].Value;
                    //Console.WriteLine(_pid);

                }
            }
            catch { }
            finally { http.Abort(); }
        }
        public R PostMethod<R>(string requestUri, byte[] requestData, Func<HttpWebResponse, R> callback)
        {
            HttpWebRequest http = CreateHttp("POST", requestUri);
            try
            {
                http.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
                http.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                http.Referer = "https://ehall.jlu.edu.cn/sso/login?x_started=true&redirect_uri=https%3A%2F%2Fehall.jlu.edu.cn%2Fsso%2Foauth2%2Fauthorize%3Fscope%3Dopenid%26response_type%3Dcode%26redirect_uri%3Dhttps%253A%252F%252Fehall.jlu.edu.cn%252Finfoplus%252Flogin%253FretUrl%253Dhttps%25253A%25252F%25252Fehall.jlu.edu.cn%25252Finfoplus%25252Foauth2%25252Fauthorize%25253Fx_redirected%25253Dtrue%252526scope%25253Dprofile%25252Bprofile_edit%25252Bapp%25252Btask%25252Bprocess%25252Bsubmit%25252Bprocess_edit%25252Btriple%25252Bstats%25252Bsys_profile%25252Bsys_enterprise%25252Bsys_triple%25252Bsys_stats%25252Bsys_entrust%25252Bsys_entrust_edit%252526response_type%25253Dcode%252526redirect_uri%25253Dhttps%2525253A%2525252F%2525252Fehall.jlu.edu.cn%2525252Ftaskcenter%2525252Fwall%2525252Fendpoint%2525253FretUrl%2525253Dhttps%252525253A%252525252F%252525252Fehall.jlu.edu.cn%252525252Ftaskcenter%252525252Fworkflow%252525252Findex%252526client_id%25253D1640e2e4-f213-11e3-815d-fa163e9215bb%26state%3D3c0b18%26client_id%3DbwDBpMCWbid5RFcljQRP";

                http.Headers.Set("Origin", "https://ehall.jlu.edu.cn");

                using (Stream writer = http.GetRequestStream())
                {
                    writer.Write(requestData,0,requestData.Length);
                }

                using (HttpWebResponse response = http.GetResponse() as HttpWebResponse)
                {
                    return callback(response);
                }
            }
            catch
            {
            }
            finally
            {
                http.Abort();
            }
            return default;
        }
        public bool Login(string user, string psw)
        {

            string param = $"username={user}&password={psw}&pid={this._pid}&source=";
            byte[] postData = Encoding.Default.GetBytes(param);
            return PostMethod("https://ehall.jlu.edu.cn/sso/login", postData, response =>
              {
                  string result = response.GetResponseString();
                  if (Regex.IsMatch(result, "login"))
                      return false;
                  else
                      return true;
              });
        }
        public int UpData()
        {
            try
            {
                HttpWebRequest http = CreateHttp("GET", "https://ehall.jlu.edu.cn/infoplus/form/BKSMRDK/start");
                using (HttpWebResponse response = http.GetResponse() as HttpWebResponse)
                {
                    string result = response.GetResponseString();
                    string str = Regex.Match(result, "itemscope=\"csrfToken\" content=\"[a-zA-Z0-9]*\"").Groups[0].Value;
                    _token = Regex.Match(str, "[a-zA-Z0-9]{10,}").Groups[0].Value;
                }
            }
            catch
            {
                return 1;
            }
            string postData1 = $"idc=BKSMRDK&csrfToken={_token}";
            byte[] byteData1 = Encoding.Default.GetBytes(postData1);
            try
            {
                if (!PostMethod("https://ehall.jlu.edu.cn/infoplus/interface/start", byteData1, response1 =>
                 {
                     string result1 = response1.GetResponseString();
                     if (Regex.IsMatch(result1, "EVENT_CANCELLED"))
                         return false;
                     else if (Regex.IsMatch(result1, @"form/\d*/render"))
                     {
                         string str1 = Regex.Match(result1, @"form/\d*/render").Groups[0].Value;
                         _sid = Regex.Match(str1, "[0-9]{8,}").Groups[0].Value;
                         return true;
                     }
                     else
                         return false;
                 }))
                    return 2;
            }
            catch { return 2; }
            string postData2 = $"stepId={_sid}&csrfToken={_token}";
            byte[] byteData2 = Encoding.Default.GetBytes(postData2);
            try
            {
                if (!PostMethod("https://ehall.jlu.edu.cn/infoplus/interface/render", byteData2, response2 =>
                {
                    string result2 = response2.GetResponseString();
                    if (Regex.IsMatch(result2, "\"data\":.*\"snapshots\""))
                    {
                        string str2 = Regex.Match(result2, "\"data\":.*\"snapshots\"").Groups[0].Value;
                        var regex_matches = Regex.Matches(str2, "{.*}");
                        _data = regex_matches[0].Groups[0].Value;
                        if (Regex.IsMatch(_data, "\"fieldZtw\":\"\""))
                            _data = _data.Replace("\"fieldZtw\":\"\"", "\"fieldZtw\":\"1\"");

                        return true;
                    }
                    else
                        return false;
                }))
                    return 3;

            }
            catch {  return 3; }
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            string time1 = Convert.ToInt64(ts.TotalSeconds).ToString();
            string boundFields = @"fieldXH,fieldZtw,fieldHidden,fieldSQqsh,fieldSQbj,fieldSQgyl,fieldQums,fieldQu,fieldSQxm,fieldWantw,fieldSQxy,fieldWY,fieldXY1,fieldZtwyc,fieldXY2,fieldXY3,fieldZhongtw,fieldSQxq,fieldShi,fieldWantwyc,fieldSQnj,fieldSheng,fieldZhongtwyc,fieldHide,fieldSQrq";
            string postData3 = $"actionId=1&formData={_data}&nextUsers={{}}&stepId={_sid}&timestamp={time1}&boundFields={boundFields}&csrfToken={_token}";
            byte[] byteData3 = Encoding.UTF8.GetBytes(postData3);
            try
            {
                if (PostMethod("https://ehall.jlu.edu.cn/infoplus/interface/doAction", byteData3, response3 =>
                 {
                     string result3 = response3.GetResponseString();
                     if (Regex.IsMatch(result3, "SUCCEED"))
                         return true;
                     else
                         return false;
                 }))
                    return 0;
                else { return 4; }
            }
            catch {  return 4; }
        }
    }
}
