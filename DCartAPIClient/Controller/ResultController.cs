using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DCartRestAPIClient;
using App.DCartAPIClient.Util;

namespace App.DCartAPIClient.Controller
{
    public class ResultController : ApiController
    {
       
        // GET: api/Result
        public RecordInfo Get(string ClientType)
        {


            return Get(0, ClientType);
        }

        // GET: api/Result/5
        public RecordInfo Get(int id, string ClientType)
        {

            var strRestAPIClientID = "";
            if(id  > 0)
                strRestAPIClientID = id.ToString();

            return GetRestAPIJSON(strRestAPIClientID, ClientType);

        }

        // POST: api/Result
        public RecordInfo Post([FromBody]Object RestAPIObject, string ClientType, int id)
        {
            if (id > 0)
                return UpdateRecord(id, RestAPIObject, ClientType);
            else
                return AddRecord(RestAPIObject, ClientType);
        }

        // PUT: api/Result/5
        public RecordInfo Put(int id, [FromBody]Object RestAPIObject, string ClientType)
        {
            return UpdateRecord(id, RestAPIObject, ClientType);
        }

        // DELETE: api/Result/5
        public RecordInfo Delete(int id, string ClientType)
        {
            var strRestAPIClientID = string.Empty;
            if (id > 0)
                strRestAPIClientID = id.ToString();

           return DeleteRestAPIJSON(strRestAPIClientID, ClientType);

        }

        private RecordInfo UpdateRecord(int id, Object RestAPIObject, string restAPIClientType)
        {
            RestAPIActions restAPIClientWM = DCartUtil.GetRestAPIClient();

            restAPIClientWM.Type = Customer.Type;
            restAPIClientWM.ID = id;

            RecordInfo recInf = restAPIClientWM.UpdateRecord(RestAPIObject);

            return recInf;
        }

        private RecordInfo AddRecord(Object RestAPIObject, string restAPIClientType)
        {
            RestAPIActions restAPIClientWM = DCartUtil.GetRestAPIClient();

            restAPIClientWM.Type = Customer.Type;
            RecordInfo recInf = restAPIClientWM.AddRecord(RestAPIObject);

            return recInf;
        }

        private RecordInfo DeleteRestAPIJSON(string strRestAPIClientID, string restAPIClientType)
        {
            RestAPIActions restAPIClientWM = DCartUtil.GetRestAPIClient();


            restAPIClientWM.Type = restAPIClientType;

            if (DCartUtil.IsNumeric(strRestAPIClientID))
            {
                restAPIClientWM.ID = Convert.ToInt32(strRestAPIClientID);
            }

            RecordInfo recInf = restAPIClientWM.DeleteRecord();

            return recInf;
        }

        private RecordInfo GetRestAPIJSON(string strRestAPIClientID, string restAPIClientType)
        {
            RestAPIActions restAPIClientWM = DCartUtil.GetRestAPIClient();

                       
            restAPIClientWM.Type = restAPIClientType;

            if (DCartUtil.IsNumeric(strRestAPIClientID))
            {
                restAPIClientWM.ID = Convert.ToInt32(strRestAPIClientID);
            }

            RecordInfo recInf = restAPIClientWM.GetRecords();

            return recInf;
            
        }
    }
}
