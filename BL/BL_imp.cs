﻿using System;
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
        //********************* Tester Func ******************
        public void addTester(Tester newTester)
        {
            Checks.CheckTesterInput(newTester);
            if (GetTester(newTester.IdTester) != null)
            {
                throw new Exception("בוחן כבר קיים במערכת");
            }
            idal.addTester(newTester);
        }
        public void changeTester(Tester updateTester)
        {
            Checks.CheckTesterInput(updateTester);
            idal.changeTester(updateTester);
        }
        public void removeTester(string idTester)
        {
            var v = from test in getTestsOfTester(GetTester(idTester))
                    select test;
            foreach (Test test in v)
            {
                removeTest(test.TestNum);
            }
            idal.removeTester(idTester);
        }
        public List<Tester> getTesters()
        {
            return idal.getTesters();
        }
        public Tester GetTester(string id)
        {
            Checks.CheckID(id);
            return idal.GetTester(id);
        }
        public List<DateTime> getMoreDatesAvailable(DateTime dateTime)
        {
            List<DateTime> dates = new List<DateTime>();
            dateTime = dateTime.AddDays(-(int)dateTime.DayOfWeek);
            dateTime = dateTime.AddHours(-dateTime.Hour + 9);
            if(dateTime < DateTime.Now)
            {
                if (DateTime.Now.Hour >= 15)
                {
                    dateTime = DateTime.Now.AddDays(1);
                    dateTime = dateTime.AddHours(-dateTime.Hour + 9);
                }
                else
                {
                    dateTime = DateTime.Now.AddHours(1);
                    dateTime = dateTime.AddMinutes(-DateTime.Now.Minute);
                }
            }
            while ((int)dateTime.DayOfWeek <= 4)
            {
                while (dateTime.Hour <= 15)
                {
                    if(getTestersAvailable(dateTime).Count > 0)
                    {
                        dates.Add(dateTime);
                    }
                    dateTime = dateTime.AddHours(1);
                }
                dateTime = dateTime.AddDays(1);
                dateTime = dateTime.AddHours(-dateTime.Hour + 9);
            }
            if(dates.Count == 0)
            {
                throw new Exception("אין מבחנים זמינים בשבוע זה");
            }
            return dates;
        }

        public List<Tester> getTestersAvailable(DateTime dateTime)
        {
            List<Tester> testers = new List<Tester>();
            var v = from item in getTesters()
                    where testerWorksAtDayAndHour(dateTime, item)
                    select item;
            foreach (var item in v)
                testers.Add(item);
            return testers;
        }
        public bool testerWorksAtDayAndHour(DateTime dateTime, Tester tester)
        {
            int day = (int)dateTime.DayOfWeek;
            int hour = dateTime.Hour - 9;
            if (day > 4)
                throw new Exception("מבחנים מתקיימים בין יום ראשון לחמישי בלבד");
            if (hour < 0 || hour > 6)
                throw new Exception("מבחנים מתקיימים בין השעות 09:00 - 15:00 בלבד");
            if (tester.mat[day, hour] == false)
                return false;
            List<Test> tests = new List<Test>(getTestsOfTester(tester));
            if (tests.Any(t => t.TestDate == dateTime))
                return false;
            int count = 0;
            foreach(Test test in tests)
            {
                if (dateTime.AddDays(-day) <= test.TestDate && dateTime.AddDays(4 - day) >= test.TestDate)
                    ++count;
            }
            if (count > tester.MaxTestsTester)
                return false;
            return true;
        }
        public List<Test> getTestsOfTester(Tester tester)
        {
            List<Test> testsOfTester = new List<Test>();
            var v = from tests in getTests()
                    orderby tests.TestDate
                    where tests.TesterId == tester.IdTester
                    select tests;
            foreach (var item in v)
            {
                testsOfTester.Add(item);
            }
            return testsOfTester;
        }
        public bool farFromAddress(Address traineeAddress)
        {
            throw new NotImplementedException();
        }


        //********************* Trainee Func ******************

        public void addTrainee(Trainee newTrainee)
        {
            Checks.CheckTraineeInput(newTrainee);
            if (GetTrainee(newTrainee.IdTrainee) != null)
            {
                throw new Exception("תלמיד כבר קיים במערכת");
            }
            idal.addTrainee(newTrainee);
        }
        public void changeTrainee(Trainee updateTrainee)
        {
            Checks.CheckTraineeInput(updateTrainee);
            idal.changeTrainee(updateTrainee);
        }
        public void checkTraineeDoTest(Trainee trainee)
        {
            List<Test> traineeTests = new List<Test>(getTestsOfTrainee(trainee));
            if (traineeTests.Count > 0)
            {
                if (traineeTests.Last().TestDate > DateTime.Now)
                {
                    throw new Exception("כבר רשום למבחן, לא ניתן לקבוע מבחן נוסף");
                }
                if (traineeTests.Last().Results == null)
                {
                    throw new Exception("לא ניתן לקבוע מבחן טרם התקבלו תוצאות מבחן קודם");
                }
                var v = from item in traineeTests
                        where item.Results.passTest == true
                        select item;
                foreach (var item in v)
                {
                    if (item.carType == trainee.CarTypeTrainee)
                    {
                        if (item.gearbox == Gearbox.גיר_ידני || trainee.GearboxTrainee == Gearbox.תיבת_הילוכים_אוטומטית)
                        {
                            throw new Exception("תלמיד כבר עבר בהצלחה מבחן ברכב מסוג זה");
                        }
                    }
                }
            }
            if (trainee.NumberOfLesson < Configuration.minLessons)
            {
                throw new Exception("תלמיד לא עשה מספיק שיעורים בשביל לגשת למבחן");
            }
        }
        public List<Test> getTestsOfTrainee(Trainee trainee)
        {
            List<Test> testsOfTrainee = new List<Test>();
            var v = from tests in getTests()
                    orderby tests.TestDate
                    where tests.TraineeId == trainee.IdTrainee
                    select tests;
            foreach (var item in v)
            {
                testsOfTrainee.Add(item);
            }
            return testsOfTrainee;
        }
        public List<Trainee> getTrainees()
        {
            return idal.getTrainees();
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
        public bool pastTest(string traineeID)
        {
            throw new NotImplementedException();
        }
        public int amountOfTests(string traineeID)
        {
            throw new NotImplementedException();
        }
        public void removeTrainee(string idTrainee)
        {
            var v = from test in getTestsOfTrainee(GetTrainee(idTrainee))
                    select test;
            foreach(Test test in v)
            {
                removeTest(test.TestNum);
            }
            idal.removeTrainee(idTrainee);
        }


        //********************* Test Func **********************

        public void AddTest(Test test)
        {
            Trainee trainee = GetTrainee(test.TraineeId);
            List<Test> traineeTests = new List<Test>(getTestsOfTrainee(trainee));
            if (traineeTests.Count > 0)
            {
                if (traineeTests.Last().TestDate.AddDays(7) > test.TestDate)
                {
                    throw new Exception("לא ניתן לקבוע מבחן בטווח של שבוע מהמבחן הקודם");
                }
            }
            idal.AddTest(test);
        }
        public void removeTest(string idTest)
        {
            if (getTests().All(t => t.TestNum != idTest))
            {
                throw new Exception("לא קיים מבחן כזה במערכת");
            }
            idal.removeTest(idTest);
        }
        public List<Test> getTests()
        {
            return idal.getTests();
        }
        public Test GetTest(string examId)
        {
            return idal.GetTest(examId);
        }
        public void updateTest(Test updateTest)
        {
            idal.updateTest(updateTest);
        }

        // impelementetion of speciael queries

        public List<IGrouping<string,Trainee>> GetTraineesGroupedBySchool(bool ordered)
        {
            if(ordered)
            return (from Trainee anyTrainee in getTrainees()
                    orderby anyTrainee.NameTrainee.LastName, anyTrainee.NameTrainee.FirstName
                    group anyTrainee by anyTrainee.SchoolTrainee).ToList();
            else
                return (from Trainee anyTrainee in getTrainees()
                        group anyTrainee by anyTrainee.SchoolTrainee).ToList();
        }

        
        public List<IGrouping<string,Trainee>> GetTreineesGroupedByTeacher(bool ordered)
        {
            if(ordered)
            return (from Trainee anyTrainee in getTrainees()
                    orderby anyTrainee.NameTrainee.LastName, anyTrainee.NameTrainee.FirstName
                    group anyTrainee by anyTrainee.TeacherTrainee).ToList();
            else
                return (from Trainee anyTrainee in getTrainees()
                        group anyTrainee by anyTrainee.TeacherTrainee).ToList();
        }

        public List<IGrouping<int,Trainee>> GetTraineesGroupedByNumOfTests(bool ordered)
        {
            if(ordered)
            return (from Trainee anyTrainee in getTrainees()
                    orderby anyTrainee.NameTrainee.LastName, anyTrainee.NameTrainee.FirstName
                    group anyTrainee by GetNumberOfTestTrainee(anyTrainee)).ToList();
            else
                return (from Trainee anyTrainee in getTrainees()
                        group anyTrainee by GetNumberOfTestTrainee(anyTrainee)).ToList();
        }

        public IEnumerable<IGrouping<CarType, Tester>> GetTestersGroupedByCarType(bool ordered)
        {
            if (ordered)
            {
                var v = from tester in getTesters()
                        orderby tester.NameTester.LastName, tester.NameTester.FirstName
                        group tester by tester.CarTypeTester
                       into g
                        select g;
                return v;
            }
            else
            {
                var v = from tester in getTesters()
                        group tester by tester.CarTypeTester
                        into g
                        select g;
                return v.ToList();
            }
        }


        public int GetNumberOfTestTrainee(Trainee trainee)
        {
            return getTestsOfTrainee(trainee).Count();
        }    
    }
}