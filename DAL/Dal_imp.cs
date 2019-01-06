using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{


    public class Dal_imp: Idal
    {

        static int examIDNum = Configuration.minIDNum;
        public static string getExamIDNum()
        {
            if (examIDNum < 10000000) //reset IDnum - need to check what to do with old tests
            {
            return examIDNum++.ToString().PadLeft(8, '0'); //return examIDnum as a string and adds '0' to left of the number
            }
            return examIDNum++.ToString();
        }

        public void AddTest(Test newTest)
        {
            Console.WriteLine("throw new NotImplementedException");
        }

        public void addTester(Tester newTester)
        {
            Console.WriteLine("throw new NotImplementedException");
        }


        public void addTrainee(Trainee newTrainee)
        {
            Console.WriteLine("throw new NotImplementedException");
        }

        public void changeTester()
        {
            Console.WriteLine("throw new NotImplementedException");
        }

        public void changeTrainee()
        {
            Console.WriteLine("throw new NotImplementedException");
        }


        public void removeTester()
        {
            Console.WriteLine("throw new NotImplementedException");
        }

        public void removeTrainee()
        {
            Console.WriteLine("throw new NotImplementedException");
        }

        public void updateTest()
        {
            Console.WriteLine("throw new NotImplementedException");
        }

        void addTest()
        {
            Console.WriteLine("throw new NotImplementedException");
        }

        List<Tester> Idal.getTesters()
        {
            throw new NotImplementedException();
        }

        List<Trainee> Idal.getTrainees()
        {
            throw new NotImplementedException();
        }

        List<Test> Idal.getTests()
        {
            throw new NotImplementedException();
        }
    }
}
