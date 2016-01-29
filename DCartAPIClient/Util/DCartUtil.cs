using DCartRestAPIClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.DCartAPIClient.Util
{
    public class DCartUtil
    {

        public static RestAPIActions GetRestAPIClient()
        {
            RestAPIActions restAPIClient = new RestAPIActions();

            // Following values should come from web.config
            restAPIClient.HttpHost = "http://apirest.3dcart.com/3dCartWebAPI/v"; ;
            restAPIClient.ServiceVersion = "1";
            restAPIClient.PrivateKey = "bc6c0b6ae8d1fa40314b65fec3047c8b";
            restAPIClient.Token = "f244f1d222b5a691db32ff537281121f";
            restAPIClient.SecureURL = "https://3dcart-nadeem-com.3dcartstores.com";
            restAPIClient.ContentType = "application/json"; 

            return restAPIClient;
        }

        public static bool IsNumeric(string val)
        {
            int n;
            return int.TryParse(val, out n);

        }
    }
}