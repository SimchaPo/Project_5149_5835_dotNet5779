using BE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace DAL
{
    public class Dal_xml: Idal
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
            XElement id = new XElement("IdTester", newTester.IdTester);
            XElement NameTester = newTester.NameTester.ToXElement();
            // *****in birthday i need to think how to convert this to string***\
            // *****in gender I need to thinl how convert***
            XElement PhoneNumberTester = new XElement("PhoneNumberTester", newTester.PhoneNumberTester);
            XElement Address = newTester.AddresTester.ToXElement();
            XElement SeniorityTester = new XElement("SeniorityTester", newTester.SeniorityTester);
            XElement MaxTestsTester = new XElement("MaxTestsTester", newTester.MaxTestsTester);
            //// *****in carType I need to thinl how convert***
            XElement mat = new XElement("mat", newTester.mat.ToString());
            XElement MaxFarFromTester = new XElement("MaxFarFromTester", newTester.MaxFarFromTester);
            TesterRoot.Add(new XElement("Tester", id, NameTester, PhoneNumberTester, Address, SeniorityTester, MaxTestsTester, MaxFarFromTester));
            //*** I need to Add the other element that already i not did ********
            TesterRoot.Save(TesterPath);
        }

        public void removeTester(string idTester)
        {
            XElement ToRemoveTester;

            ToRemoveTester = (from tra in TesterRoot.Elements()
                               where tra.Element("IdTester").Value == idTester
                               select tra).FirstOrDefault();
            if (ToRemoveTester != null)
            {

                ToRemoveTester.Remove();
                TesterRoot.Save(TesterPath);
            }
            else
                throw new Exception("לא קיים בוחן בעל תעודת זהות זו במערכת");
        }

        public void changeTester(Tester updatedTester)
        {
            XElement ToChangeTester;

            ToChangeTester = (from AnyTester in TesterRoot.Elements()
                         where AnyTester.Element("TesterId").Value==updatedTester.IdTester select AnyTester).FirstOrDefault();
            ToChangeTester.Element("IdTester").Value = updatedTester.IdTester;


            ToChangeTester.Element("FullName").Element("FirstName").Value = updatedTester.NameTester.FirstName;
            ToChangeTester.Element("FullName").Element("LastName").Value = updatedTester.NameTester.LastName;



            //birthday*** i need to think about conversion of date
            //gender **i need to think about enum
            ToChangeTester.Element("PhoneNumberTester").Value = updatedTester.PhoneNumberTester;

            ToChangeTester.Element("Address").Element("City").Value = updatedTester.AddresTester.City;
            ToChangeTester.Element("Address").Element("Street").Value = updatedTester.AddresTester.Street;
            ToChangeTester.Element("Address").Element("HouseNum").Value = updatedTester.AddresTester.HouseNum.ToString();

            ToChangeTester.Element("SeniorityTester").Value = updatedTester.SeniorityTester.ToString();
            ToChangeTester.Element("MaxTestsTester").Value = updatedTester.MaxTestsTester.ToString();
            ////carType **i need to thinl about enum
            ////mat ** i need to think about the convertion of mat
            ToChangeTester.Element("MaxFarFromTester").Value = updatedTester.MaxFarFromTester.ToString();

            TesterRoot.Save(TesterPath);

        }

        public void addTrainee(Trainee newTrainee)
        {
            XElement NameTrainee = newTrainee.NameTrainee.ToXElement();
            XElement IdTrainee = new XElement("IdTrainee", newTrainee.IdTrainee);
            XElement BirthDateTrainee = new XElement("BirthDateTrainee", newTrainee.BirthDateTrainee.ToString());
            // *****in gender I need to thinl how convert***
            XElement PhoneNumberTrainee = new XElement("PhoneNumberTrainee", newTrainee.PhoneNumberTrainee);
            XElement AddressTrainee = newTrainee.AddressTrainee.ToXElement();
            XElement SchoolTrainee= new XElement("SchoolTrainee", newTrainee.SchoolTrainee);
            XElement TeacherTrainee = new XElement("TeacherTrainee", newTrainee.TeacherTrainee);
            //// *****in carType I need to think how convert***
            //// *****in Gearbox I need to think how convert***
            XElement NumberOfLesson = new XElement("NumberOfLesson", newTrainee.NumberOfLesson);
            XElement LastExamDate = new XElement("LastExamDate", newTrainee.LastExamDate.ToString());

            TraineeRoot.Add(new XElement("trainee", NameTrainee, IdTrainee, PhoneNumberTrainee, AddressTrainee, SchoolTrainee, TeacherTrainee, NumberOfLesson));
            //*** I need to Add the other element that already i not did ********
            TraineeRoot.Save(TraineePath);

            Trainee zadoknet = GetTrainee("304123456");
            
            zadoknet.AddressTrainee.City = "new york";
            zadoknet.AddressTrainee.Street = "הועד הועד";
            zadoknet.TeacherTrainee = "מורהאחר";
            changeTrainee(zadoknet);

        }

        public void removeTrainee(string idTrainee)
        {
            XElement ToRemoveTrainee;

            ToRemoveTrainee = (from tra in TraineeRoot.Elements()
                             where tra.Element("IdTrainee").Value == idTrainee
                             select tra).FirstOrDefault();
            if (ToRemoveTrainee != null)
            {

                ToRemoveTrainee.Remove();
                TraineeRoot.Save(TraineePath);
            }
            else
                throw new Exception("לא קיים תלמיד בעל תעודת זהות זו במערכת");
        }

        public void changeTrainee(Trainee updatedTrainee)
        {
            XElement tra = (from anyTrainee in TraineeRoot.Elements()
                            where anyTrainee.Element("IdTrainee").Value == updatedTrainee.IdTrainee
                            select anyTrainee).FirstOrDefault();



            tra.Element("FullName").Element("FirstName").Value = updatedTrainee.NameTrainee.FirstName;
            tra.Element("FullName").Element("LastName").Value = updatedTrainee.NameTrainee.LastName;

            tra.Element("IdTrainee").Value = updatedTrainee.IdTrainee;
            //Gender Trainee ***i need to think how to work with enum
            tra.Element("BirthDateTrainee").Value = updatedTrainee.BirthDateTrainee.ToString();
            tra.Element("PhoneNumberTrainee").Value = updatedTrainee.PhoneNumberTrainee;

            tra.Element("Address").Element("City").Value = updatedTrainee.AddressTrainee.City;
            tra.Element("Address").Element("Street").Value = updatedTrainee.AddressTrainee.Street;
            tra.Element("Address").Element("HouseNum").Value = updatedTrainee.AddressTrainee.HouseNum.ToString();


            tra.Element("SchoolTrainee").Value = updatedTrainee.SchoolTrainee;
            tra.Element("TeacherTrainee").Value = updatedTrainee.TeacherTrainee;
            //car Type ***i need to think how to work with enum
            //and Gear box ***i need to think how to work with enum
            
            tra.Element("NumberOfLesson").Value = updatedTrainee.NumberOfLesson.ToString();
            tra.Element("LastExamDate").Value = updatedTrainee.LastExamDate.ToString();
            TraineeRoot.Save(TraineePath);
        }

        public void AddTest(Test newTest)
        {
            

            XElement TestNum = new XElement("TestNum", newTest.TestNum); //***we need to create function to create a test num****8
            XElement TesterId = new XElement("TesterId", newTest.TesterId); 
            XElement TraineeId = new XElement("TraineeId", newTest.TraineeId);
            //**** i need to think how to convert the date of TestDate****
            XElement HourTest = new XElement("HourTest", newTest.HourTest);
            XElement AddressTest = newTest.AddressTest.ToXElement();
            //**** i need to think how to convert the date of TestTime****
            XElement NoteTester = new XElement("NoteTester", newTest.NoteTester);

            TestRoot.Add(TestNum, TesterId, TraineeId, HourTest, AddressTest, NoteTester);

            TestRoot.Save(TestPath);
        }

        public void updateTest(Test updatedTest)
        {
            throw new NotImplementedException();
        }

        public void removeTest(string idTest)
        {
            XElement ToRemoveTest;

            ToRemoveTest = (from anyTest in TestRoot.Elements()
                               where anyTest.Element("TestNum").Value == idTest
                               select anyTest).FirstOrDefault();
            if (ToRemoveTest != null)
            {

                ToRemoveTest.Remove();
                TestRoot.Save(TestPath);
            }
            else
                throw new Exception("לא קיים בוחן בעל תעודת זהות זו במערכת");
        }

        public Test GetTest(string id)
        {
            LoadDataTest();
            Test result;

            result = (from anyTest in TesterRoot.Elements()
                      where anyTest.Element("TestNum").Value == id
                      select new Test()
                      {
                          TestNum = anyTest.Element("TestNum").Value,
                          TesterId = anyTest.Element("TesterId").Value,
                          TraineeId = anyTest.Element("TraineeId").Value,
                          TestDate = DateTime.Parse(anyTest.Element("TestDate").Value),
                          HourTest = anyTest.Element("HourTest").Value,
                          AddressTest = new Address
                          {
                              City = anyTest.Element("Address").Element("City").Value,
                              Street = anyTest.Element("Address").Element("Street").Value,
                              HouseNum = int.Parse(anyTest.Element("Address").Element("HouseNum").Value)
                          },
                          TestTime = DateTime.Parse(anyTest.Element("TestTime").Value),
                          NoteTester =anyTest.Element("NoteTester").Value
                      }).FirstOrDefault();

            if (result != null)
                return result;
            else
                throw new Exception("לא קיים במערכת בוחן בעל מספר מזהה זה");

        }

        public Trainee GetTrainee(string trainee)
        {
            LoadDateTrainee();
            Trainee rainee;

            rainee = (from tra in TraineeRoot.Elements()
                       where tra.Element("IdTrainee").Value == trainee

                      select new Trainee()
                       {
                          NameTrainee = new FullName()
                          {
                               FirstName= tra.Element("FullName").Element("FirstName").Value,
                              LastName = tra.Element("FullName").Element("LastName").Value
                          },
                          IdTrainee = tra.Element("IdTrainee").Value,
                           //Gender Trainee ***i need to think how to work with enum
                           BirthDateTrainee=DateTime.Parse(tra.Element("BirthDateTrainee").Value),
                           PhoneNumberTrainee =tra.Element("PhoneNumberTrainee").Value,
                           AddressTrainee= new Address
                           {
                               City = tra.Element("Address").Element("City").Value,
                               Street = tra.Element("Address").Element("Street").Value,
                               HouseNum = int.Parse(tra.Element("Address").Element("HouseNum").Value)
                           },
                           SchoolTrainee =tra.Element("SchoolTrainee").Value,
                           TeacherTrainee=tra.Element("TeacherTrainee").Value,
                           //car Type ***i need to think how to work with enum
                           //and Gear box ***i need to think how to work with enum
                           NumberOfLesson=int.Parse(tra.Element("NumberOfLesson").Value),
                           LastExamDate=DateTime.Parse(tra.Element("LastExamDate").Value)

                       }).FirstOrDefault();
            if (rainee != null)
                return rainee;
            else
                throw new Exception("תלמיד בעל תעודת זהות זו לא קיים במערכת");

        }

        public Tester GetTester(string id)
        {
            LoadDataTester();
            Tester result;

            result = (from anyTester in TesterRoot.Elements()
                      where anyTester.Element("IdTester").Value == id
                      select new Tester()
                      {
                          IdTester = anyTester.Element("IdTester").Value,
                          NameTester = new FullName()
                          {
                              FirstName = anyTester.Element("FullName").Element("FirstName").Value,
                              LastName = anyTester.Element("FullName").Element("LastName").Value
                          }
                          ,
                          BirthDateTester=DateTime.Parse(anyTester.Element("BirthDateTester").Value),
                          //gender **i need to think about enum
                          PhoneNumberTester = anyTester.Element("PhoneNumberTester").Value,
                          AddresTester = new Address
                          {
                              City = anyTester.Element("Address").Element("City").Value,
                              Street = anyTester.Element("Address").Element("Street").Value,
                              HouseNum = int.Parse(anyTester.Element("Address").Element("HouseNum").Value)
                          },
                          SeniorityTester = int.Parse(anyTester.Element("SeniorityTester").Value),
                          MaxTestsTester = int.Parse(anyTester.Element("MaxTestsTester").Value),
                          ////carType **i need to thinl about enum
                          ////mat ** i need to think about the convertion of mat
                          MaxFarFromTester = int.Parse(anyTester.Element("MaxFarFromTester").Value)
                      }).FirstOrDefault();
            if (result != null)
                return result;
            else
                throw new Exception("לא קיים במערכת בוחן בעל תעודת זהות זו");

        }

        public List<Tester> getTesters()
        {
            LoadDataTester();
            List<Tester> resultList;

            resultList = (from anyTester in TesterRoot.Elements()

                          select new Tester()
                          {
                              IdTester = anyTester.Element("IdTester").Value,
                              NameTester = new FullName()
                              {
                                  FirstName = anyTester.Element("FullName").Element("FirstName").Value,
                                  LastName = anyTester.Element("FullName").Element("LastName").Value
                              }
                              ,
                              BirthDateTester= DateTime.Parse(anyTester.Element("BirthDateTester").Value),
                              //gender **i need to think about enum
                              PhoneNumberTester = anyTester.Element("PhoneNumberTester").Value,
                              AddresTester = new Address
                              {
                                  City = anyTester.Element("Address").Element("City").Value,
                                  Street = anyTester.Element("Address").Element("Street").Value,
                                  HouseNum = int.Parse(anyTester.Element("Address").Element("HouseNum").Value)
                              },
                              SeniorityTester = int.Parse(anyTester.Element("SeniorityTester").Value),
                              MaxTestsTester = int.Parse(anyTester.Element("MaxTestsTester").Value),
                              ////carType **i need to thinl about enum
                              ////mat ** i need to think about the convertion of mat
                              MaxFarFromTester = int.Parse(anyTester.Element("MaxFarFromTester").Value)
                          }).ToList();

            return resultList;
        }

        public List<Trainee> getTrainees()
        {
            LoadDateTrainee();
            List<Trainee> trainees;


                trainees =(from tra in TraineeRoot.Elements()
                           select new Trainee()
                           {
                               NameTrainee = new FullName()
                               {
                                   FirstName = tra.Element("FullName").Element("FirstName").Value,
                                   LastName = tra.Element("FullName").Element("LastName").Value
                               },
                               IdTrainee = tra.Element("IdTrainee").Value,
                               //Gender Trainee ***i need to think how to work with enum
                               BirthDateTrainee = DateTime.Parse(tra.Element("BirthDateTrainee").Value),
                               PhoneNumberTrainee = tra.Element("PhoneNumberTrainee").Value,
                               AddressTrainee = new Address
                               {
                                   City = tra.Element("Address").Element("City").Value,
                                   Street = tra.Element("Address").Element("Street").Value,
                                   HouseNum = int.Parse(tra.Element("Address").Element("HouseNum").Value)
                               },
                               SchoolTrainee = tra.Element("SchoolTrainee").Value,
                               TeacherTrainee = tra.Element("TeacherTrainee").Value,
                               //car Type ***i need to think how to work with enum
                               //and Gear box ***i need to think how to work with enum
                               NumberOfLesson = int.Parse(tra.Element("NumberOfLesson").Value),
                               LastExamDate = DateTime.Parse(tra.Element("LastExamDate").Value)
                           }).ToList();
  
            return trainees;
            }

        public List<Test> getTests()
        {
            throw new NotImplementedException();
        }

      
    }

 
    }

    

