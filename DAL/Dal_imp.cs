using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

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
            //****check if the test with this id num already exist
            foreach (Test item in DS.DataSource.Tests)
                if (item.TestNum == newTest.TestNum)
                    throw new Exception("exam with this id num already exist");



            //**in this place i need to do all of the checks
            DS.DataSource.Tests.Add(newTest.Clone());
        }

        public void addTester(Tester newTester)
        {
            //**** check if this tester already exist
            foreach (Tester item in DS.DataSource.Testers)
                if (item.IdTester == newTester.IdTester)
                    throw new Exception("this tester already exist");
            //**check if the the tester in correct age
            if (newTester.BirthDateTester.AddYears(Configuration.minAgetester )> DateTime.Now)//check about the min age
                throw new Exception("This man can't be a tester, he is too young");
            if (newTester.BirthDateTester.AddYears(Configuration.maxAgeTester) < DateTime.Now)//check about the max age
                throw new Exception("This man can't be a tester, he is too old");

            //**in this place i need to do all of the checks
            DS.DataSource.Testers.Add(newTester.Clone());
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
            DS.DataSource.Trainees.Add(newTrainee.Clone());
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
            DataSource.Testers.RemoveAll(t => t.IdTester == idTester);
        }

        public void removeTrainee(string idTrainee)
        {
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

        //******************all of this getters need change to clone************
        List<Tester> Idal.getTesters() => DataSource.Testers;

        List<Trainee> Idal.getTrainees() => DataSource.Trainees;


        List<Test> Idal.getTests() => DataSource.Tests;
        
    }
}
