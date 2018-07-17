using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace ThreeDCart.Core
{
    public class ThreeDCartJsonParser
    {
        private string privateKey;
        private string token;
        private string secureUrl;

        public ThreeDCartJsonParser(string privateKey, string token, string secureUrl)
        {
            this.privateKey = privateKey;
            this.token = token;
            this.secureUrl = secureUrl;
        }

        public string PostPutJson(string url, string jsonToSubmit, string method = "POST")
        {
            HttpWebRequest req = GetHttpWebRequest(url, method);

            req.ContentType = "application/json";

            req.ContentLength = Encoding.UTF8.GetByteCount(jsonToSubmit);
            using (Stream sw = req.GetRequestStream())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(jsonToSubmit);
                sw.Write(bytes, 0, bytes.Length);
            }

            HttpWebResponse resp = null;

            try
            {
                resp = (HttpWebResponse)req.GetResponse();


                // Verify HTTP for 200 OK status code
                if (resp.StatusCode == HttpStatusCode.OK || resp.StatusCode == HttpStatusCode.Created)
                {
                    using (StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                    {
                        string responseData = sr.ReadToEnd().Replace("\r\n", "");
                        return "OK";
                    }
                }
            }
            catch (WebException webex)
            {
                if (webex.Message == "The remote server returned an error: (501) Not Implemented.")
                    return "The remote server returned an error: (501) Not Implemented.";

                using (var stream = webex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }

            }
            catch (Exception)
            {
                return "ERROR";
            }

            return null;

        }

        public T GetJsonById<T>(string url)
        {
            string resultData = string.Empty;
            HttpWebRequest req = GetHttpWebRequest(url, "GET");
            WebResponse httpResponse = req.GetResponse();

            Stream responseStream = httpResponse.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            resultData = reader.ReadToEnd();
            responseStream.Close();
            httpResponse.Close();

            return JObject.Parse(resultData).ToObject<T>();

        }

        public T GetJson<T>(string url, string jsonStartingPoint)
        {
            string resultData = string.Empty;
            HttpWebRequest req = GetHttpWebRequest(url, "GET");

            WebResponse httpResponse = req.GetResponse();

            Stream responseStream = httpResponse.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            resultData = reader.ReadToEnd();
            responseStream.Close();
            httpResponse.Close();

            if (!String.IsNullOrEmpty(jsonStartingPoint))
                return JArray.Parse(resultData)[jsonStartingPoint].ToObject<T>();
            else
                return JArray.Parse(resultData).ToObject<T>();

        }

        public T PostPutJson<T>(string url, string jsonToSubmit, string jsonStartingPoint, string method = "POST")
        {
            HttpWebRequest req = GetHttpWebRequest(url, method);

            req.ContentLength = Encoding.UTF8.GetByteCount(jsonToSubmit);
            using (Stream sw = req.GetRequestStream())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(jsonToSubmit);
                sw.Write(bytes, 0, bytes.Length);
            }

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            using (StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
            {
                string responseData = sr.ReadToEnd().Replace("\r\n", "");

                if (!String.IsNullOrEmpty(jsonStartingPoint))
                    return JArray.Parse(responseData)[jsonStartingPoint].ToObject<T>();
                else
                    return JArray.Parse(responseData).ToObject<T>();
            }
        }

        private HttpWebRequest GetHttpWebRequest(string url, string method)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

            req.Headers.Add("SecureURL", secureUrl);
            req.Headers.Add("PrivateKey", privateKey);
            req.Headers.Add("Token", token);
            req.Headers.Add("Authorization", "Bearer " + token);

            req.Timeout = 120000;
            req.Method = method;
            req.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36";
            req.Accept = "application/json";
            req.ContentType = "application/json";
            return req;
        }
    }
}
