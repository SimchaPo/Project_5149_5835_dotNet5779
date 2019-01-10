using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Checks
    {
        public bool checkID (string myID)
        {
            return myID.Any(c => char.IsDigit(c)) && myID.Length == 9;
        }
    }
}
