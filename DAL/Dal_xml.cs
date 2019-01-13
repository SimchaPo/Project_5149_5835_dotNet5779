using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using BE;

namespace DAL
{
    class Dal_xml: Idal
    {
        XElement TesterRoot;
        string TesterPath = @"TesterXml.xml"; //did i need property in the path????
        XElement TraineeRoot;
        string TraineePath = @"TraineeXml.xml"; //did i need property in the path????
        XElement TestRoot;
        string TestPath = @"TestXml.xml"; //did i need property in the path????

        public Dal_xml()
        {
            if (!File.Exists(TesterPath))
                CreateFileTester();
            else
                LoadDataTester();

            if (!File.Exists(TraineePath))
                CreateFileTrainee();
            else
                LoadDateTrainee();

            if (!File.Exists(TestPath))
                CreateFileTest();
            else
                LoadDataTest();
        }

        private void CreateFileTester()
        {
            TesterRoot = new XElement("Testers");
            TesterRoot.Save(TesterPath);
        }

        private void LoadDataTester()
        {
            try
            {
                TesterRoot = XElement.Load(TesterPath);
            }
            catch
            {
                throw new Exception("שגיאה בטעינת קובץ הבוחנים");
            }
        }

        private void CreateFileTrainee()
        {
            TraineeRoot = new XElement("Trainees");
            TraineeRoot.Save(TraineePath);
        }

        private void LoadDateTrainee()
        {
            try
            {
                TraineeRoot = XElement.Load(TraineePath);
            }
            catch
            {
                throw new Exception("שגיאה בטעינת קובץ התלמידים");
            }
        }

        private void CreateFileTest()
        {
            TestRoot = new XElement("Tests");
            TestRoot.Save(TestPath);
        }

        private void LoadDataTest()
        {
            try
            {
                TestRoot = XElement.Load(TestPath);
            }
            catch
            {
                throw new Exception("שגיאה בטעינת קובץ המבחנים");
            }
        }

        public void addTester(Tester newTester)
        {
             
        }

        public void removeTester(string idTester)
        {
            throw new NotImplementedException();
        }

        public void changeTester(Tester updateTester)
        {
            throw new NotImplementedException();
        }

        public void addTrainee(Trainee newTrainee)
        {
            
        }

        public void removeTrainee(string iTrainee)
        {
            throw new NotImplementedException();
        }

        public void changeTrainee(Trainee updateTrainee)
        {
            throw new NotImplementedException();
        }

        public void AddTest(Test newTest)
        {
            throw new NotImplementedException();
        }

        public void updateTest(Test updateTest)
        {
            throw new NotImplementedException();
        }

        public Test GetTest(string id)
        {
            throw new NotImplementedException();
        }

        public Trainee GetTrainee(string trainee)
        {
            throw new NotImplementedException();
        }

        public Tester GetTester(string id)
        {
            throw new NotImplementedException();
        }

        public List<Tester> getTesters()
        {
            throw new NotImplementedException();
        }

        public List<Trainee> getTrainees()
        {
            throw new NotImplementedException();
        }

        public List<Test> getTests()
        {
            throw new NotImplementedException();
        }
    }
}
