using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BL
{
    public class BL_imp : IBL
    {
        Idal idal = FactoryDal.GetDal();
        public void AddTest(Test newTest)
        {
            // טסטר זמין
            //בדיקה שעברו 7 ימים מטסט קודם
            idal.AddTest(newTest);
        }

        public void addTester(Tester newTester)
        {
            try
            {
                if (Checks.CheckForNull(newTester))
                {
                    throw new Exception("אנא השלם את כל הפרטים");
                }
                if (!Checks.checkID(newTester.IdTester))
                {
                    throw new Exception("מספר תעודת זהות לא חוקי");
                }
                if (!Checks.checkPhoneNumber(newTester.PhoneNumberTester))
                {
                    throw new Exception("מספר טלפון לא חוקי");
                }
                if (newTester.BirthDateTester.AddYears(Configuration.minAgetester) > DateTime.Now)
                {
                    throw new Exception("בוחן צעיר מדי");
                }
                if (newTester.BirthDateTester.AddYears(Configuration.maxAgeTester) < DateTime.Now)
                {
                    throw new Exception("בוחן מבוגר מדי");
                }
                idal.addTester(newTester);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void addTrainee(Trainee newTrainee)
        {
            try
            {
                if (newTrainee.BirthDateTrainee.AddYears(Configuration.minAgeTrainee) > DateTime.Now)
                {
                    throw new Exception("תלמיד צעיר מדי");
                }

                idal.addTrainee(newTrainee);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void changeTester(Tester newTester)
        {
            idal.changeTester(newTester);
        }

        public void changeTrainee(Trainee updateTrainee)
        {
            idal.changeTrainee(updateTrainee);
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

        public void removeTester(string idTester)
        {
            idal.removeTester(idTester);
        }

        

        public void removeTrainee(string idTrainee)
        {
            idal.removeTrainee(idTrainee);
        }

        public void updateTest(Test updateTest)
        {
            idal.updateTest(updateTest);
        }
    }
}
