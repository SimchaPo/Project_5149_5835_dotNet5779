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
            Test test = new Test
            {
                TesterId = "3",
                TestDate = DateTime.Now,
                AddresTest = new Address { City = "Jerusalem", hHouseNum = 21, Street = "Havaad Haleumi" }
            };
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(DAL.Dal_imp.getExamIDNum());

            }
            Console.ReadKey();
        }
    }
}
