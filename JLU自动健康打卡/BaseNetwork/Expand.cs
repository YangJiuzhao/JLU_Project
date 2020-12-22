using System.IO;
using System.Net;

namespace BaseNetwork
{
    public static class Expand
    {
        public static string GetResponseString(this HttpWebResponse target)
        {
            using (StreamReader reader = new StreamReader(target.GetResponseStream()))
            {
                return reader.ReadToEnd();
            }
        }
    }
}