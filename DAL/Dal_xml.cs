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
 
        public void addTester(Tester newTester) // i need to think how to store the matrix (meybe with convert to string)
        {
            XElement id = new XElement("idTester", newTester.IdTester);
            XElement NameTester = newTester.NameTester.ToXElement();
            // *****in birthday i need to think how to convert this to string***\
            // *****in gender I need to thinl how convert***
            XElement PhoneNumberTester = new XElement("phoneNumberTester", newTester.PhoneNumberTester);
            XElement Addrees = newTester.AddresTester.ToXElement();
            XElement SeniorityTester = new XElement("SeniorityTester", newTester.SeniorityTester);
            XElement MaxTestsTester = new XElement("MaxTestsTester", newTester.MaxTestsTester);
            //// *****in carType I need to thinl how convert***
            //**in matrix i need to think how to convert***
            XElement MaxFarFromTester = new XElement("MaxFarFromTester", newTester.MaxFarFromTester);
            TesterRoot.Add(new XElement("Tester", id, NameTester, PhoneNumberTester, Addrees, SeniorityTester, MaxTestsTester, MaxFarFromTester)); 
            //*** I need to Add the other element that already i not did ********
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
            XElement NameTrainee = newTrainee.NameTrainee.ToXElement();
            XElement IdTrainee = new XElement("IdTrainee", newTrainee.IdTrainee);
            // *****in birthday i need to think how to convert this to string***\
            // *****in gender I need to thinl how convert***
            XElement PhoneNumberTrainee = new XElement("PhoneNumberTrainee", newTrainee.PhoneNumberTrainee);
            XElement AddressTrainee = newTrainee.AddressTrainee.ToXElement();
            XElement SchoolTrainee= new XElement("SchoolTrainee", newTrainee.SchoolTrainee);
            XElement TeacherTrainee = new XElement("TeacherTrainee", newTrainee.TeacherTrainee);
            //// *****in carType I need to think how convert***
            //// *****in Gearbox I need to think how convert***
            XElement NumberOfLesson = new XElement("NumberOfLesson", newTrainee.NumberOfLesson);
            //// *****in LastExamDate I need to think how convert***
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
