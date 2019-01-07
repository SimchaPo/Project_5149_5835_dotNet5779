using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BL
{
    internal class BL_imp : IBL
    {
        Idal idal = FactoryDal.GetDal();
        public void addTest(Test newTest)
        {
            // טסטר זמין
            //בדיקה שעברו 7 ימים מטסט קודם
            throw new NotImplementedException();
        }

        public void addTester(Tester newTester)
        {
            try
            {
                if (newTester.BirthDateTester.AddYears(Configuration.minAgetester) > DateTime.Now)
                {
                    throw new Exception("can't be a tester, you are to young");
                }
                if (newTester.BirthDateTester.AddYears(Configuration.maxAgeTester) < DateTime.Now)
                {
                    throw new Exception("can't be a tester, you are to old");
                }
            }
            catch (Exception exeption)
            {
                Console.WriteLine(exeption);
                return;
            }
            idal.addTester(newTester);
        }

        public void addTrainee(Trainee newTrainee)
        {
            try
            {
                if (newTrainee.BirthDateTrainee.AddYears(Configuration.minAgeTrainee) < DateTime.Now)
                {
                    throw new Exception("can't do a test, you are to young");
                }
            }
            catch (Exception exeption)
            {
                Console.WriteLine(exeption);
            }
            idal.addTrainee(newTrainee);
        }

        public void changeTester()
        {
            idal.changeTester();
        }

        public void changeTrainee()
        {
            idal.changeTrainee();
        }

        public List<Tester> getTesters()
        {
            return idal.getTesters();
        }

        public List<Tester> getTestersFilter(Func<Tester, bool> filter)
        {
            throw new NotImplementedException();
        }

        public List<Test> getTests()
        {
            return idal.getTests();
        }

        public List<Trainee> getTrainees()
        {
            return idal.getTrainees();
        }

        public void removeTester()
        {
            idal.removeTester();
        }

        public void removeTrainee()
        {
            idal.removeTrainee();
        }

        public void updateTest()
        {
            idal.updateTest();
        }
    }
}