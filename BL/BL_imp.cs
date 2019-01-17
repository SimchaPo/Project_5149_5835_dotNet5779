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
        public void AddTest(Test test)
        {

            
            // טסטר זמין
            //בדיקה שעברו 7 ימים מטסט קודם
           // idal.AddTest(newTest);
        }

        public void addTester(Tester newTester)
        {
            Checks.CheckTesterInput(newTester);
            idal.addTester(newTester);
        }

        public void addTrainee(Trainee newTrainee)
        {
            Checks.CheckTraineeInput(newTrainee);
            idal.addTrainee(newTrainee);
        }

        public void changeTester(Tester updateTester)
        {
            Checks.CheckTesterInput(updateTester);
            idal.changeTester(updateTester);
        }

        public void changeTrainee(Trainee updateTrainee)
        {
            Checks.CheckTraineeInput(updateTrainee);
            idal.changeTrainee(updateTrainee);
        }

        public List<Tester> getTestersAvailable(DateTime dateTime)
        {
            List<Tester> testers = new List<Tester>();
            var v = from item in getTesters()
                    where testerAvailable(dateTime, item)
                    select item;
            foreach (var item in v)
                testers.Add(item);
            return testers;
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
            Checks.CheckID(id);
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

        public bool farFromAddress(Address traineeAddress)
        {
            throw new NotImplementedException();
        }

        public bool testerAvailable(DateTime dateTime, Tester tester)
        {
                int day = (int)dateTime.DayOfWeek;
                int hour = dateTime.Hour - 9;
                if (day > 4)
                    throw new Exception("מבחנים מתקיימים בין יום ראשון לחמישי בלבד");
                if (hour < 0 || hour > 6)
                    throw new Exception("מבחנים מתקיימים בין השעות 09:00 - 15:00 בלבד");
                return tester.mat[day, hour] == true;            
        }

        public int amountOfTests(string traineeID)
        {
            throw new NotImplementedException();
        }

        public bool pastTest(string traineeID)
        {
            throw new NotImplementedException();
        }
    }
}
