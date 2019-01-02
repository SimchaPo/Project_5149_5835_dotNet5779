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
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(DAL.Dal_imp.getExamIDNum());

            }
            Console.ReadKey();
        }
    }
}
