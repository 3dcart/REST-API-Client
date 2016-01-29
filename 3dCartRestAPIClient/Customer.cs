using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace DCartRestAPIClient
{

  
    //public class Customer : RestAPIObject
    public class Customer : IRestAPIType
    {
        // ID
        public long CustomerID { get; set; }

        // Login Information

        public string Email { get; set; }

        public string Password { get; set; }

        // Billing Information

        public string BillingCompany { get; set; }

        public string BillingFirstName { get; set; }

        public string BillingLastName { get; set; }

        public string BillingAddress1 { get; set; }

        public string BillingAddress2 { get; set; }

        public string BillingCity { get; set; }

        public string BillingState { get; set; }

        public string BillingZipCode { get; set; }

        public string BillingCountry { get; set; }

        public string BillingPhoneNumber { get; set; }

        public static RestAPIType key
        {
            get
            {
                return RestAPIType.Customer;
            }
        }

        public static string Type
        {
            get
            {
                return "Customers";
            }
        }

    }

  






}