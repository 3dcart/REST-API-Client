using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


namespace DCartRestAPIClient
{

    public class CustomerGroup : IRestAPIType

    {

        public long CustomerGroupID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal MinimumOrder { get; set; }

        public bool NonTaxable { get; set; }

        public bool AllowRegistration { get; set; }

        public bool DisableRewardPoints { get; set; }

        public bool AutoApprove { get; set; }

        public string RegistrationMessage { get; set; }

        public int PriceLevel { get; set; }

        public static RestAPIType key
        {
            get
            {
                return RestAPIType.CustomerGroup;
            }
        }

        public static string Type
        {
            get
            {
                return "CustomerGroups";
            }
        }


    }
}