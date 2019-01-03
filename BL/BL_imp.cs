using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BL
{
    class BL_imp : IBL
    {
        public void addTest(Test newTest)
        {
                        // טסטר זמין
        //בדיקה שעברו 7 ימים מטסט קודם
            throw new NotImplementedException();
        }

        public void addTester(Tester newTester)
        {
            try{
                if(newTester.BirthDateTester.AddYears(Configuration.minAgetester) > DateTime.Now){
                    throw "can't be a tester, you are to young";
                }
                if(newTester.BirthDateTester.AddYears(Configuration.maxAgeTester) < DateTime.Now){
                    throw Exception("can't be a tester, you are to old");
                }
            }
            catch(string exeption) {
                Console.WriteLine(exeption);
                return;
            }
            
        }

        public void addTrainee(Trainee newTrainee)
        {
            try{
                if(newTrainee.BirthDateTrainee.AddYears(Configuration.minAgeTrainee) < DateTime.Now){
                    throw "can't do a test, you are to young";
                    }
            }
            catch(string exeption){
                Console.WriteLine(exeption);
            }
        }

        public void changeTester()
        {
            throw new NotImplementedException();
        }

        public void changeTrainee()
        {
            throw new NotImplementedException();
        }

        public List<Tester> getTesters()
        {
            throw new NotImplementedException();
        }

        public List<Tester> getTestersFilter(Func<Tester, bool> filter =null)
        {
            throw new NotImplementedException();
        }

        public List<Test> getTests()
        {
            throw new NotImplementedException();
        }

        public List<Trainee> getTrainees()
        {
            throw new NotImplementedException();
        }

        public void removeTester()
        {
            throw new NotImplementedException();
        }

        public void removeTrainee()
        {
            throw new NotImplementedException();
        }

        public void updateTest()
        {
            throw new NotImplementedException();
        }
    }
}