using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace DCartRestAPIClient
{

    public class Manufacturer : IRestAPIType
    {
        
        public int? ManufacturerID { get; set; }
        public string ManufacturerName { get; set; }
        public string Logo { get; set; }
        public int? Sorting { get; set; }
        public string Header { get; set; }
        public string Website { get; set; }
        public string UserID { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string PageTitle { get; set; }
        public string MetaTags { get; set; }
        public string RedirectURL { get; set; }

        public static RestAPIType key
        {
            get
            {
                return RestAPIType.Manufacturer;
            }
        }


        public static string Type
        {
            get
            {
                return "Manufacturers";
            }
        }


    }





}
