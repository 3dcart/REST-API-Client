using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCartRestAPIClient;
using Newtonsoft.Json;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace RestAPIClientInterface
{
    public partial class Main : System.Web.UI.Page
    {

        RestAPIActions restAPIClient = null;

       
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [WebMethod]
        public static string GetRestAPIRecords(string strRestAPIID, string RestAPIType, string PrivateKey, string Token, string SecureURL, string RecordsGetLimit)
        {
            string strRestJSON = GetRestAPIJSON(strRestAPIID, RestAPIType, PrivateKey, Token, SecureURL, RecordsGetLimit);

            return strRestJSON;
        }


        [WebMethod]
        public static string AddRecord(Object RestAPIObject, string RestAPIType, string PrivateKey, string Token, string SecureURL)
        {

            RestAPIActions restAPIClientWM = GetRestAPIClient(PrivateKey, Token, SecureURL);

            restAPIClientWM.Type = RestAPIType;


            RecordInfo addInfo = restAPIClientWM.AddRecord(RestAPIObject);

            string sIDPrefix = RestAPIType.Substring(0, RestAPIType.Length - 1) ;

            if (addInfo.Status == ActionStatus.Succeeded)
            {
                return sIDPrefix + " added. " + sIDPrefix + "ID: " + addInfo.ResultSet;

            }

            else
            {
                return sIDPrefix + " add failed.  Error Code: " + addInfo.CodeNumber + ", Description: " + addInfo.Description;
            }


        }

        
        [WebMethod]
        public static string UpdateRecord(Object RestAPIObject, string RestAPIType, string RestAPIUpdateID, string PrivateKey, string Token, string SecureURL)
        {

            RestAPIActions restAPIClientWM = GetRestAPIClient(PrivateKey, Token, SecureURL);


            restAPIClientWM.Type = RestAPIType;
            restAPIClientWM.ID = Convert.ToInt32(RestAPIUpdateID);


            RecordInfo updateInfo = restAPIClientWM.UpdateRecord(RestAPIObject);

            string sIDPrefix = RestAPIType.Substring(0, RestAPIType.Length - 1) ;

            if (updateInfo.Status == ActionStatus.Succeeded)
            {
                return sIDPrefix + " updated. " + sIDPrefix + "ID: " + updateInfo.ResultSet;
            }

            else
            {
                return sIDPrefix + " update failed.  Error Code: " + updateInfo.CodeNumber + ", Description: " + updateInfo.Description;

            }

        }


        [WebMethod]
        public static string DeleteRecord(string RestAPIType, string RestAPIDeleteID, string PrivateKey, string Token, string SecureURL)
        {

            RestAPIActions restAPIClientWM = GetRestAPIClient(PrivateKey, Token, SecureURL);


            restAPIClientWM.Type = RestAPIType;
            restAPIClientWM.ID = Convert.ToInt32(RestAPIDeleteID);


            RecordInfo deleteInfo = restAPIClientWM.DeleteRecord();

            string sIDPrefix = RestAPIType.Substring(0, RestAPIType.Length - 1); 

            if (deleteInfo.Status == ActionStatus.Succeeded)
            {
                return sIDPrefix + " deleted. " + sIDPrefix + "ID: " + deleteInfo.ResultSet;

            }

            else
            {
                return sIDPrefix + " delete failed.  Error Code: " + deleteInfo.CodeNumber + ", Description: " + deleteInfo.Description;

            }

        }
 

        public static RestAPIActions GetRestAPIClient(string strPrivateKey, string strToken, string strSecureURL )
        {
            RestAPIActions restAPIClientWM = new RestAPIActions();

            string sHost = string.Empty;
            string sVersion = string.Empty;
            string sContentType = string.Empty;

            //Provide the parameters for the HTTP Client 
            sHost = "http://apirest.3dcart.com/3dCartWebAPI/v";
            sVersion = "1";
            sContentType = "application/json";

            restAPIClientWM.HttpHost = sHost;
            restAPIClientWM.ServiceVersion = sVersion;
            restAPIClientWM.PrivateKey = strPrivateKey;
            restAPIClientWM.Token = strToken;
            restAPIClientWM.SecureURL = strSecureURL;
            restAPIClientWM.ContentType = sContentType;

            return restAPIClientWM;
        }

        private static string GetRestAPIJSON(string strRestAPIClientID, string restAPIClientType, string PrivateKey, string Token, string SecureURL, string RecordsGetLimit)
        {
            RestAPIActions restAPIClientWM = GetRestAPIClient(PrivateKey, Token, SecureURL);


            string restAPIClientStream = string.Empty;

            restAPIClientWM.Type = restAPIClientType;

            int parsedValue;
            if (strRestAPIClientID.Length != 0 && int.TryParse(strRestAPIClientID, out parsedValue))
            {
                restAPIClientWM.ID = Convert.ToInt32(strRestAPIClientID);
            }

            int parsedRecordsGetLimitValue;
            if (RecordsGetLimit.Length != 0 && int.TryParse(RecordsGetLimit, out parsedRecordsGetLimitValue))
            {
                restAPIClientWM.RecordsGetLimit = Convert.ToInt32(RecordsGetLimit);
            }

            RecordInfo recInf = restAPIClientWM.GetRecords();



            if (recInf.Status == ActionStatus.Succeeded)
            {

                try
                {
                    List<Object> reclist = (List<Object>)recInf.ResultSet;

                    restAPIClientStream += "[";

                    foreach (Object record in reclist)
                    {
                        string receiveStream = record.ToString();

                        restAPIClientStream += record.ToString() + ",";

                    }

                    restAPIClientStream = restAPIClientStream.TrimEnd(',');

                    restAPIClientStream += "]";


                }
                catch (Exception ex)
                {

                }

            }

            return restAPIClientStream;

        }

    }

    public class CustomException : Exception
    {
        public CustomException()
            : base() { }

        public CustomException(string message)
            : base(message) { }

        public CustomException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public CustomException(string message, Exception innerException)
            : base(message, innerException) { }

    }
}