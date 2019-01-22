using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class examResults
    {
        public bool mirrors { get; set; }
        public bool blinker { get; set; }
        public bool distance { get; set; }
        public bool passTest { get; set; }
        public override string ToString()
        {
            return "mirrors " + mirrors + " blinker " + " distance " + distance + " passTest " + passTest;
        } 
        
    }
}
