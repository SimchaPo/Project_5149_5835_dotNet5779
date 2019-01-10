using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Checks
    {
        public bool checkID(string myID)
        {
            return myID.Any(c => char.IsDigit(c)) && myID.Length == 9;
        }
        public bool checkPhoneNumber(string myNumber)
        {
            return myNumber.Any(c => char.IsDigit(c)) && myNumber.Length == 10;
        }
        public bool CheckForNull(Tester t)
        {
            foreach (bool? item in t.mat)
            {
                if (item == null)
                {
                    return true;
                }
            }
            return t.IdTester == null || t.NameTester.FirstName == null || t.NameTester.LastName == null
                || t.PhoneNumberTester == null || t.AddresTester.City == null ||
                t.AddresTester.Street == null;
        }

    }
}
