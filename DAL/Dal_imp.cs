using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace DAL
{


    public class Dal_imp : Idal
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
            // give idNum to the exam
            newTest.TestNum = getExamIDNum();

            /*Trainee CurrentTrainee = GetTrainee(newTest.TraineeId).Clone();
            Tester CurrnetTester = GetTester(newTest.TesterId).Clone();

            /* set of checks if the input is proper
             if the check failed the function will throw exception
             
           
            //checks about the student

                    //check if the student did exam in this 7 days
                    CurrentTrainee.DidTraineeExamInRecentTime();
                    //check if the studen did enough lessons
                    CurrentTrainee.didTraineeMinLessons();
            //check if the tester fit to this sort of exam
            CurrnetTester.DidtesterFitToTrainee(CurrentTrainee);

            //checks about the tester

                //check if the tester not pass the limit of exams in this week
                CurrnetTester.didTesterPassLimitExam();
                //check if the the 

            //**in this place i need to do all of the checks*/
            DS.DataSource.Tests.Add(newTest);
        }
        public void removeTest(string idTest)
        {
            throw new NotImplementedException();
        }
        public void addTester(Tester newTester)
        {
            //**** check if this tester already exist
            foreach (Tester item in DS.DataSource.Testers)
                if (item.IdTester == newTester.IdTester)
                    throw new Exception("בוחן כבר רשום במערכת");
            //**check if the the tester in correct age
            if (newTester.BirthDateTester.AddYears(Configuration.minAgetester) > DateTime.Now)//check about the min age
                throw new Exception("בוחן צעיר מדי");
            if (newTester.BirthDateTester.AddYears(Configuration.maxAgeTester) < DateTime.Now)//check about the max age
                throw new Exception("בוחן מבוגר מדי");

            //**in this place i need to do all of the checks
            DataSource.Testers.Add(newTester);
        }


        public void addTrainee(Trainee newTrainee)
        {
            foreach (Trainee item in DS.DataSource.Trainees)
                if (item.IdTrainee == newTrainee.IdTrainee)
                    throw new Exception("התלמיד כבר רשום למערכת");
            //****check if the student in the correct age
            if (newTrainee.BirthDateTrainee.AddYears(Configuration.minAgeTrainee) > DateTime.Now)
                throw new Exception("התלמיד צעיר מדי בשביל לגשת לטסט");

            //**in this place i need to do all of the checks
            DS.DataSource.Trainees.Add(newTrainee);
        }

        public void changeTester(Tester updatedTester)
        {
            //***check if this tester exist
            if (!DS.DataSource.Testers.Exists(t => updatedTester.IdTester == t.IdTester))
                throw new Exception("This tester did not exist");
            //*** delete the not updated tester
            DataSource.Testers.RemoveAll(t => t.IdTester == updatedTester.IdTester);
            //***add the updated tester to the list
            DataSource.Testers.Add(updatedTester);
        }

        public void changeTrainee(Trainee updatedTrainee)
        {
            //***check if this student exist
            if (!DS.DataSource.Trainees.Exists(t => updatedTrainee.IdTrainee == t.IdTrainee))
                throw new Exception("This student did not exist");
            //*** delete the not updated student
            DataSource.Trainees.RemoveAll(t => t.IdTrainee == updatedTrainee.IdTrainee);
            //***add the updated student to the list
            DataSource.Trainees.Add(updatedTrainee);
        }


        public void removeTester(string idTester)
        {
            //***check if this tester exist
            if (!DS.DataSource.Testers.Exists(t => idTester == t.IdTester))
                throw new Exception("This tester did not exist");
            DataSource.Testers.RemoveAll(t => t.IdTester == idTester);
        }

        public void removeTrainee(string idTrainee)
        {
            //***check if this student exist
            if (!DS.DataSource.Trainees.Exists(t => idTrainee == t.IdTrainee))
                throw new Exception("This student did not exist");
            DataSource.Trainees.RemoveAll(t => t.IdTrainee == idTrainee);
        }

        public void updateTest(Test updatedTest)
        {
            //***check if this test exist
            if (!DS.DataSource.Tests.Exists(t => updatedTest.TestNum == t.TestNum))
                throw new Exception("This test did not exist");
            //*** delete the unupdated test
            DataSource.Tests.RemoveAll(t => t.TestNum == updatedTest.TestNum);
            //***add the updated test to the list
            DataSource.Tests.Add(updatedTest);
        }
        public Trainee GetTrainee(string id)
        {
            var v = DS.DataSource.Trainees.Where(t => t.IdTrainee == id);
            foreach (var item in v)
                return item;
            throw new Exception("תלמיד זה אינו קיים במערכת");
        }
        public Tester GetTester(string id)
        {
            var v = DS.DataSource.Testers.Where(t => t.IdTester == id);
            foreach (var item in v)
                return item;
            throw new Exception("בוחן זה אינו קיים במערכת");
        }
        public Test GetTest(string id)
        {
            var v = DataSource.Tests.Where(t => t.TestNum == id);
            foreach (var item in v)
                return item;
            throw new Exception("מבחן זה אינו קיים במערכת");
        }

        //******************all of this getters need change to clone************
        List<Tester> Idal.getTesters() => DataSource.Testers.Select(t => t.Clone()).ToList<Tester>();

        List<Trainee> Idal.getTrainees() => DataSource.Trainees.Select(t => t.Clone()).ToList<Trainee>();

        List<Test> Idal.getTests() => DataSource.Tests.Select(t => t.Clone()).ToList<Test>();

    }
}
