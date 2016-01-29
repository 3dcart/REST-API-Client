using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace DCartRestAPIClient
{


    public class Distributor : IRestAPIType
    {
        public long DistributorID { get; set; }

        public string CompanyName { get; set; }

        public string ContactName { get; set; }

        public string Address { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string EMail { get; set; }

        public string Comments { get; set; }

        public static RestAPIType key
        {
            get
            {
                return RestAPIType.Distributor;
            }
        }

        public static string Type
        {
            get
            {
                return "Distributors";
            }
        }


    }

}