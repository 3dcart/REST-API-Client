using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCartRestAPIClient
{
    //Stores the status and result of HTTP operation
    public class RecordInfo
    {
        public ActionStatus Status { get; set; }

        public int CodeNumber { get; set; }

        public string Description { get; set; }

        public Object ResultSet { get; set; }



    }
}
