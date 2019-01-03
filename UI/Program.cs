using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Tester tester = new Tester
            {
                 IdTester = "3",
                 BirthDateTester = new DateTime(1979, 01,03),
                 AddresTester = new Address { City = "Jerusalem", HouseNum = 21, Street = "Havaad Haleumi" }
            };
            for (int i = 0; i < 10; i++)
            {
                //if(tester.BirthDateTester.CompareTo(DateTime.Now))
                Console.WriteLine(tester.BirthDateTester.AddYears(40) < DateTime.Now);
                Console.WriteLine(tester.BirthDateTester);
            }
            Console.ReadKey();
        }
    }
}
