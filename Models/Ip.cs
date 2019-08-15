using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Ip
    {
        public Ip()
        {
            IPInfo = "no info";
            IsMalicious = "not checked";
        }
        public string IPAddress { get; set; }
        public string IPInfo { get; set; }
        public string Country { get; set; }
        public bool IsChecked { get; set; }
        public DateTime TimeChecked { get; set; }
        public string IsMalicious { get; set; }
    }
}
