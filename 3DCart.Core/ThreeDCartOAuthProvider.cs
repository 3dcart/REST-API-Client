using Newtonsoft.Json.Linq;
using ThreeDCart.Core.Models;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace ThreeDCart.Core
{
    public class ThreeDCartOAuthProvider
    {
        /// <summary>
        /// Creates URL to login to Skubana and generate access token
        /// </summary>
        /// <param name="redirectUri"></param>
        /// <param name="cid"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetAuthorizeUrl(string clientId, string redirectUri, string storeUrl)
        {
            string url = "https://apirest.3dcart.com/oauth/authorize?";

            //https://apirest.3dcart.com/oauth/authorize?clientid=%7bpublicKey%7d&redirect_uri=%7bredirectUri%7d&state=%7btext%7d&response_type=code&store_url=%5boptional

            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            queryString["client_id"] = clientId;
            queryString["redirect_uri"] = redirectUri;
            queryString["state"] = "12345";
            queryString["response_type"] = "code";
            queryString["store_url"] = storeUrl;
            return String.Format(url + queryString.ToString());
        }

        /// <summary>
        /// Returns access_token, refresh_token, and expires_in
        /// </summary>
        /// <param name="client_id"></param>
        /// <param name="client_secret"></param>
        /// <param name="redirect_uri"></param>
        /// <param name="code"></param>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        public ThreeDCartAuth GetAccessToken(string redirectUri, string clientId, string code, string clientSecret)
        {
            string url = "https://apirest.3dcart.com/oauth/token?";

            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);

            queryString["grant_type"] = "authorization_code";
            queryString["client_id"] = clientId;
            queryString["client_secret"] = clientSecret;
            queryString["redirect_uri"] = redirectUri;
            queryString["code"] = code;

            if (!String.IsNullOrEmpty(code))
            {
                string userP = clientId + ":" + clientSecret;
                byte[] authBytes = Encoding.UTF8.GetBytes(userP).ToArray();
                myHttpWebRequest.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(authBytes));
            }

            var data = Encoding.ASCII.GetBytes(queryString.ToString());

            myHttpWebRequest.Method = "POST";
            myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
            myHttpWebRequest.ContentLength = data.Length;

            using (var stream = myHttpWebRequest.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)myHttpWebRequest.GetResponse();

            string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            ThreeDCartAuth threeDCartAuth = JObject.Parse(responseString).ToObject<ThreeDCartAuth>();

            return threeDCartAuth;
        }

    }
}
