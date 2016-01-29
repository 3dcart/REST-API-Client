using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCartRestAPIClient
{
    //Stores the response information after calling an HTTP operation
    public class ResponseInfo
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }

    }
}
