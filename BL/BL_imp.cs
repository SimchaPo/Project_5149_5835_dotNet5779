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
                if (Checks.CheckForNullTester(newTester))
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
                if (Checks.CheckForNullTrainee(newTrainee))
                {
                    throw new Exception("אנא השלם את כל הפרטים");
                }
                if (!Checks.checkID(newTrainee.IdTrainee))
                {
                    throw new Exception("מספר תעודת זהות לא חוקי");
                }
                if (!Checks.checkPhoneNumber(newTrainee.PhoneNumberTrainee))
                {
                    throw new Exception("מספר טלפון לא חוקי");
                }
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

        public Test GetTest(string id)
        {
            return idal.GetTest(id);
        }
        public Trainee GetTrainee(string trainee)
        {
            try
            {
                return idal.GetTrainee(trainee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Tester GetTester(string id)
        {
            if (!Checks.checkID(id))
            {
                throw new Exception("מספר תעודת זהות לא תקין");
            }
            return idal.GetTester(id);
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
