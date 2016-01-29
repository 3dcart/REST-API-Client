using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections;

namespace DCartRestAPIClient
{

    public enum ActionStatus : int
    { 
        Succeeded = 1,
        Failed =2

    };




    public class RestAPIActions 
    {
        public string HttpHost { get; set; }

        public string ServiceVersion { get; set; }

        public string PrivateKey { get; set; }
        public string Token { get; set; }
        public string SecureURL { get; set; }
        public string ContentType { get; set; }
        public long ID { get; set; }
        public string Type { get; set; }
        public long RecordsGetLimit { get; set; }


        //Creates an instance of HttpClient
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(HttpHost + ServiceVersion + "/");

            client.DefaultRequestHeaders.Accept.Clear();
            //Specify the content type
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ContentType));

            //Set the privatekey, token and securUrl information in request headers
            client.DefaultRequestHeaders.Add("privatekey", PrivateKey);
            client.DefaultRequestHeaders.Add("token", Token);
            client.DefaultRequestHeaders.Add("secureUrl", SecureURL);

            return client;
        }


        
        public RecordInfo GetRecords()
        {
            //Create a RecordInfo object to store the information retrieved through a GET operation
            RecordInfo recordInfo = new RecordInfo();

            //Create a list of Object to hold the records retrieved from a GET
            List<Object> recordList = new List<Object>();

            var client = GetClient();

            try
            {
                string sTypeWithID = string.Empty;
                string sTypeWithLimit = string.Empty;

                //Create an instance of HTTP Client by calling custom GetClient function 

                // If ID is set, GET will retrieve one record matching with ID. If ID is not set, all the records will be retrieved.
                // Type indicates the type of object we are looking to retrieve. For example Customers, CustomerGroup, Products
                if (ID != 0)
                {
                    sTypeWithID = Type + "/" + ID;

                }
                else
                {
                    sTypeWithID = Type;
                }


                //Specify maximum number of records to GET
                if (RecordsGetLimit != 0)
                {
                    sTypeWithLimit = sTypeWithID + "?limit=" + RecordsGetLimit;

                }
                else
                {
                    sTypeWithLimit = sTypeWithID;
                }
                //GET the record(s) by using GetAsync method of HTTPClient and store the response in variable of HttpResponseMessage type
                HttpResponseMessage response = client.GetAsync(sTypeWithLimit).Result;


                //If GET is successful, store the records in  recordList object we already created, else throw the exception to show the error
                if (response.IsSuccessStatusCode)
                {

                    string receiveStream = response.Content.ReadAsStringAsync().Result;
                    recordList = (List<Object>)JsonConvert.DeserializeObject(receiveStream, typeof(List<Object>));

                }
                else
                {
                        //throws exception if operation was not successful
                        response.EnsureSuccessStatusCode();

                }

                //Store the records in resultset property and set the status to successful
                recordInfo.ResultSet = recordList;
                recordInfo.Status = ActionStatus.Succeeded;

            }
            catch (Exception ex)
            {
                recordInfo.Description = ex.Message;
                recordInfo.Status = ActionStatus.Failed;
            }



            return recordInfo;
        }

        
        public RecordInfo AddRecord(Object record)
        {
            
            RecordInfo recordInfo = new RecordInfo();

            try
            {

                //Create an instance of HTTP Client by calling custom GetClient function 
                var client = GetClient();

                //Call the PostAsJsonAsync method to add record through HTTP POST
                HttpResponseMessage response = client.PostAsJsonAsync(Type, record).Result;

                //Call ReadAsStringAsync to check the result code and if there is any error message. Store the information in ResponeInfo object.
                string strResponseJson = response.Content.ReadAsStringAsync().Result;
                ResponseInfo responeInfoObject = JsonConvert.DeserializeObject<ResponseInfo>(strResponseJson.Substring(1, strResponseJson.Length - 2));
                

                //If add is successful, store the ID of newly generated record in 'resultset' property and mark the status as successful, 
                //else set the status to failed and provide the error code and description through CodeNumber and description property
                recordInfo = GetRecordInfo(responeInfoObject, response.IsSuccessStatusCode);

            }

            catch (Exception ex)
            {
                recordInfo.Description = ex.Message;
                recordInfo.Status = ActionStatus.Failed;

            }

            return recordInfo;


        }

        public RecordInfo UpdateRecord(Object record)
        {
            var recordInfo = new RecordInfo();
            
            try
            {
                string sTypeWithID = string.Empty;

                //Create an instance of HTTP Client by calling custom GetClient function 
                var client = GetClient();

                // If ID is set, ID will be appended to URL, else update operation will fail.
                // Type indicates the type of object we are looking to update. For example Customers, CustomerGroup, Products
                if (ID != 0)
                {
                    sTypeWithID = Type + "/" + ID;

                }
                else
                {
                    sTypeWithID = Type;
                }

                //Call the PutAsJsonAsync method to update record through HTTP PUT
                HttpResponseMessage response = client.PutAsJsonAsync(sTypeWithID, record).Result;

                //Call ReadAsStringAsync to check the result code and if there is any error message. Store the information in ResponeInfo object.
                string strResponseJson = response.Content.ReadAsStringAsync().Result;
                ResponseInfo responeInfoObject = JsonConvert.DeserializeObject<ResponseInfo>(strResponseJson.Substring(1, strResponseJson.Length - 2));

                //If update is successful, store the ID of newly updated record in 'resultset' property and mark the status as successful, 
                //else set the status to failed and provide the error code and description through CodeNumber and description property
                recordInfo = GetRecordInfo(responeInfoObject, response.IsSuccessStatusCode);
                
            }

            catch (Exception ex)
            {
                recordInfo.Description = ex.Message;
                recordInfo.Status = ActionStatus.Failed;

            }

            return recordInfo;

        }

        public RecordInfo DeleteRecord()
        {
             RecordInfo recordInfo = new RecordInfo();

             try
             {

                 string sTypeWithID = string.Empty;

                 //Create an instance of HTTP Client by calling custom GetClient function 
                 var client = GetClient();

                 // If ID is set, ID will be appended to URL, else update operation will fail.
                 // Type indicates the type of object we are looking to update. For example Customers, CustomerGroup, Products
                 if (ID != 0)
                 {
                     sTypeWithID = Type + "/" + ID;

                 }
                 else
                 {
                     sTypeWithID = Type;
                 }

                 //Call the DeleteAsync method to delete record through HTTP DELETE
                 HttpResponseMessage response = client.DeleteAsync(sTypeWithID).Result;

                 //Call ReadAsStringAsync to check the result code and if there is any error message. Store the information in ResponeInfo object.
                 string strResponseJson = response.Content.ReadAsStringAsync().Result;
                 ResponseInfo responeInfoObject = JsonConvert.DeserializeObject<ResponseInfo>(strResponseJson.Substring(1, strResponseJson.Length - 2));

                 recordInfo = GetRecordInfo(responeInfoObject, response.IsSuccessStatusCode);

             }

             catch (Exception ex)
             {

                 recordInfo.Description = ex.Message;
                 recordInfo.Status = ActionStatus.Failed;

             }

             return recordInfo;

        }

        //Holds the data returned and result of the HTTP operation
        private RecordInfo GetRecordInfo(ResponseInfo responseInfo, bool IsSuccessStatus)
        {
            var recordInfo = new RecordInfo();

            int intStatusCode = -1;
            bool bResult = Int32.TryParse(responseInfo.Status, out intStatusCode);
            if (!bResult) { intStatusCode = -1; }

            //If success status is passed through function then store status, code number, message and value in properties of RecordInfo object
            //If status is not success then only store status, code number and description in the properties of RecordInfo object
            if (IsSuccessStatus)
            {

                recordInfo.Status = ActionStatus.Succeeded;
                recordInfo.CodeNumber = intStatusCode;
                recordInfo.Description = responseInfo.Message;
                recordInfo.ResultSet = (Object)responseInfo.Value;

            }

            else
            {
                recordInfo.CodeNumber = intStatusCode;
                recordInfo.Description = responseInfo.Message;
                recordInfo.Status = ActionStatus.Failed;
            }

            return recordInfo;
        }

    }



    public enum RestAPIType : int
    {
        Order = 1,
        Customer = 2,
        CustomerGroup = 3,
        Product = 4,
        Category = 5,
        Distributor = 6,
        Manufacturer = 7

    };

}
