using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Editor
{
    public class EasybaseTime
    {
        public string compNr { get; set; }
        public string empNr { get; set; }
        public DateTime tDate { get; set; }
        public string isComing { get; set; }
        public DateTime? exported { get; set; }

        public EasybaseTime(string compNr,  string empNr, DateTime tdate, string isComing, DateTime? exported)
        {
            this.compNr = compNr;
            this.empNr = empNr;
            this.tDate = tdate;
            this.isComing = isComing;
            this.exported = exported;
        }
    }
}
