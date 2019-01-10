using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Tester
    {
        public Tester()
        {
            NameTester = new FullName();
            AddresTester = new Address();
        }
        public string IdTester { get; set; }
        public FullName NameTester { get; set; }
        public DateTime BirthDateTester { get; set; }
        public Gender GenderTester { get; set; }
        public string PhoneNumberTester { get; set; }
        public Address AddresTester { get; set; }
        public int SeniorityTester { get; set; } //שנות וותק
        public int MaxTestsTester { get; set; } 
        public CarType CarTypeTester { get; set; }
        public bool?[,] mat { get; set; } // צריך לאתחל את גודל המטריצה
        public int MaxFarFromTester { get; set; }
    }
}
