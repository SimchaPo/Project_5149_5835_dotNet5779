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
            XElement BirthDateTester = new XElement("BirthDateTester", newTester.BirthDateTester.ToString());
            XElement GenderTester = new XElement("GenderTester", newTester.GenderTester.ToString());
            XElement PhoneNumberTester = new XElement("PhoneNumberTester", newTester.PhoneNumberTester);
            XElement Address = newTester.AddresTester.ToXElement();
            XElement SeniorityTester = new XElement("SeniorityTester", newTester.SeniorityTester);
            XElement MaxTestsTester = new XElement("MaxTestsTester", newTester.MaxTestsTester);
            XElement CarTypeTester = new XElement("CarTypeTester", newTester.CarTypeTester.ToString());
            XElement mat = new XElement("mat",newTester.mat.ToStringMat());
            XElement MaxFarFromTester = new XElement("MaxFarFromTester", newTester.MaxFarFromTester);
            TesterRoot.Add(new XElement("Tester", id, NameTester, BirthDateTester,GenderTester, PhoneNumberTester, Address, SeniorityTester,
                MaxTestsTester,CarTypeTester, mat,MaxFarFromTester));
            //*** I need to Add the other element that already i not did ********
            TesterRoot.Save(TesterPath);

            /*Tester some= GetTester("333333333");
           List<Tester> list= getTesters();
            removeTester("333333333");*/
            

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
                         where AnyTester.Element("IdTester").Value==updatedTester.IdTester select AnyTester).FirstOrDefault();
            ToChangeTester.Element("IdTester").Value = updatedTester.IdTester;


            ToChangeTester.Element("FullName").Element("FirstName").Value = updatedTester.NameTester.FirstName;
            ToChangeTester.Element("FullName").Element("LastName").Value = updatedTester.NameTester.LastName;



            ToChangeTester.Element("BirthDateTester").Value = updatedTester.BirthDateTester.ToString();
            ToChangeTester.Element("GenderTester").Value = updatedTester.GenderTester.ToString();
            ToChangeTester.Element("PhoneNumberTester").Value = updatedTester.PhoneNumberTester;

            ToChangeTester.Element("Address").Element("City").Value = updatedTester.AddresTester.City;
            ToChangeTester.Element("Address").Element("Street").Value = updatedTester.AddresTester.Street;
            ToChangeTester.Element("Address").Element("HouseNum").Value = updatedTester.AddresTester.HouseNum.ToString();

            ToChangeTester.Element("SeniorityTester").Value = updatedTester.SeniorityTester.ToString();
            ToChangeTester.Element("MaxTestsTester").Value = updatedTester.MaxTestsTester.ToString();
            ToChangeTester.Element("CarTypeTester").Value = updatedTester.CarTypeTester.ToString();
            
            ToChangeTester.Element("mat").Value = updatedTester.mat.ToStringMat();
            ToChangeTester.Element("MaxFarFromTester").Value = updatedTester.MaxFarFromTester.ToString();

            TesterRoot.Save(TesterPath);

        }

        public void addTrainee(Trainee newTrainee)
        {
            XElement NameTrainee = newTrainee.NameTrainee.ToXElement();
            XElement IdTrainee = new XElement("IdTrainee", newTrainee.IdTrainee);
            XElement BirthDateTrainee = new XElement("BirthDateTrainee", newTrainee.BirthDateTrainee.ToString());
            XElement GenderTrainee = new XElement("GenderTrainee", newTrainee.GenderTrainee.ToString());
            XElement PhoneNumberTrainee = new XElement("PhoneNumberTrainee", newTrainee.PhoneNumberTrainee);
            XElement AddressTrainee = newTrainee.AddressTrainee.ToXElement();
            XElement SchoolTrainee= new XElement("SchoolTrainee", newTrainee.SchoolTrainee);
            XElement TeacherTrainee = new XElement("TeacherTrainee", newTrainee.TeacherTrainee);
            XElement CarTypeTrainee = new XElement("CarTypeTrainee", newTrainee.CarTypeTrainee.ToString());
            XElement GearboxTrainee = new XElement("GearboxTrainee", newTrainee.GearboxTrainee.ToString());

            XElement NumberOfLesson = new XElement("NumberOfLesson", newTrainee.NumberOfLesson);
            XElement LastExamDate = new XElement("LastExamDate", newTrainee.LastExamDate.ToString());

            TraineeRoot.Add(new XElement("trainee", NameTrainee, IdTrainee,BirthDateTrainee,GenderTrainee, PhoneNumberTrainee,
                AddressTrainee,SchoolTrainee, TeacherTrainee,CarTypeTrainee,GearboxTrainee, NumberOfLesson,LastExamDate));
            
            TraineeRoot.Save(TraineePath);

         
            

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
            tra.Element("GenderTrainee").Value = updatedTrainee.GenderTrainee.ToString();
            tra.Element("BirthDateTrainee").Value = updatedTrainee.BirthDateTrainee.ToString();
            tra.Element("PhoneNumberTrainee").Value = updatedTrainee.PhoneNumberTrainee;

            tra.Element("Address").Element("City").Value = updatedTrainee.AddressTrainee.City;
            tra.Element("Address").Element("Street").Value = updatedTrainee.AddressTrainee.Street;
            tra.Element("Address").Element("HouseNum").Value = updatedTrainee.AddressTrainee.HouseNum.ToString();


            tra.Element("SchoolTrainee").Value = updatedTrainee.SchoolTrainee;
            tra.Element("TeacherTrainee").Value = updatedTrainee.TeacherTrainee;
            tra.Element("CarTypeTrainee").Value = updatedTrainee.CarTypeTrainee.ToString();
            tra.Element("GearboxTrainee").Value = updatedTrainee.GearboxTrainee.ToString();

            tra.Element("NumberOfLesson").Value = updatedTrainee.NumberOfLesson.ToString();
            tra.Element("LastExamDate").Value = updatedTrainee.LastExamDate.ToString();
            TraineeRoot.Save(TraineePath);
        }

        public void AddTest(Test newTest)
        {
            

            XElement TestNum = new XElement("TestNum", getExamIDNum().ToString()); //***we need to create function to create a test num****8
            XElement TesterId = new XElement("TesterId", newTest.TesterId); 
            XElement TraineeId = new XElement("TraineeId", newTest.TraineeId);
            XElement TestDate = new XElement("TestDate", newTest.TestDate.ToString());
            XElement AddressTest = newTest.AddressTest.ToXElement();
            XElement NoteTester = new XElement("NoteTester", newTest.NoteTester);

            XElement carType = new XElement("carType", newTest.carType.ToString());
            XElement gearbox = new XElement("gearbox", newTest.gearbox.ToString());
            XElement Result = newTest.Results.ToXElement();

            TestRoot.Add(new XElement("Test",TestNum, TesterId, TraineeId,TestDate, AddressTest, NoteTester,carType,gearbox,Result));

            TestRoot.Save(TestPath);
        }

        public void updateTest(Test updatedTest)
        {
            XElement ToChangeTest;

            ToChangeTest = (from anyTest in TestRoot.Elements()
                            where anyTest.Element("TestNum").Value == updatedTest.TestNum
                            select anyTest).FirstOrDefault();
            ToChangeTest.Element("TestNum").Value=updatedTest.TestNum; //***we need to create function to create a test num****8
            ToChangeTest.Element("TesterId").Value=updatedTest.TesterId;
            ToChangeTest.Element("TraineeId").Value=updatedTest.TraineeId;
            ToChangeTest.Element("TestDate").Value=updatedTest.TestDate.ToString();
            
             ToChangeTest.Element("Address").Element("City").Value = updatedTest.AddressTest.City;
            ToChangeTest.Element("Address").Element("Street").Value = updatedTest.AddressTest.Street;
            ToChangeTest.Element("Address").Element("HouseNum").Value = updatedTest.AddressTest.HouseNum.ToString();



            ToChangeTest.Element("NoteTester").Value=updatedTest.NoteTester;

            ToChangeTest.Element("carType").Value=updatedTest.carType.ToString();
            ToChangeTest.Element("gearbox").Value=updatedTest.gearbox.ToString();

            XElement toRemove = ToChangeTest.Element("Results");
            toRemove.Remove();
            ToChangeTest.Add(updatedTest.Results.ToXElement());
            TestRoot.Save(TestPath);
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
                throw new Exception("לא קיים מבחן כזה במערכת");
        }

        public Test GetTest(string id)
        {
            LoadDataTest();
            Test result;

            result = (from anyTest in TestRoot.Elements()
                      where anyTest.Element("TestNum").Value == id
                      select new Test()
                      {
                          TestNum = anyTest.Element("TestNum").Value,
                          TesterId = anyTest.Element("TesterId").Value,
                          TraineeId = anyTest.Element("TraineeId").Value,
                          TestDate = DateTime.Parse(anyTest.Element("TestDate").Value),
                          AddressTest = new Address
                          {
                              City = anyTest.Element("Address").Element("City").Value,
                              Street = anyTest.Element("Address").Element("Street").Value,
                              HouseNum = int.Parse(anyTest.Element("Address").Element("HouseNum").Value)
                          },
                          NoteTester = anyTest.Element("NoteTester").Value,
                          carType = (CarType)Enum.Parse(typeof(CarType),anyTest.Element("carType").Value),
                          gearbox=(Gearbox)Enum.Parse(typeof(Gearbox),anyTest.Element("gearbox").Value),
                          Results = anyTest.Element("Results").ToExamResults()
                      }).FirstOrDefault();

            return result;

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
                              FirstName = tra.Element("FullName").Element("FirstName").Value,
                              LastName = tra.Element("FullName").Element("LastName").Value
                          },
                          IdTrainee = tra.Element("IdTrainee").Value,
                          GenderTrainee = (Gender)Enum.Parse(typeof(Gender),tra.Element("GenderTrainee").Value),
                           BirthDateTrainee=DateTime.Parse(tra.Element("BirthDateTrainee").Value),
                           PhoneNumberTrainee =tra.Element("PhoneNumberTrainee").Value,
                           AddressTrainee= new Address
                           {
                               City = tra.Element("Address").Element("City").Value,
                               Street = tra.Element("Address").Element("Street").Value,
                               HouseNum = int.Parse(tra.Element("Address").Element("HouseNum").Value)
                           },
                           SchoolTrainee =tra.Element("SchoolTrainee").Value,
                           TeacherTrainee=tra.Element("TeacherTrainee").Value
                           ,

                          CarTypeTrainee = (CarType)Enum.Parse(typeof(CarType), tra.Element("CarTypeTrainee").Value),
                          GearboxTrainee = (Gearbox)Enum.Parse(typeof(Gearbox), tra.Element("GearboxTrainee").Value),

                          NumberOfLesson = int.Parse(tra.Element("NumberOfLesson").Value),
                          LastExamDate = DateTime.Parse(tra.Element("LastExamDate").Value)

                      }).FirstOrDefault();
            
                return rainee;
            
                

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
                          BirthDateTester = DateTime.Parse(anyTester.Element("BirthDateTester").Value),
                          GenderTester=(Gender)Enum.Parse(typeof(Gender),anyTester.Element("GenderTester").Value),
                          PhoneNumberTester = anyTester.Element("PhoneNumberTester").Value,
                          AddresTester = new Address
                          {
                              City = anyTester.Element("Address").Element("City").Value,
                              Street = anyTester.Element("Address").Element("Street").Value,
                              HouseNum = int.Parse(anyTester.Element("Address").Element("HouseNum").Value)
                          },
                          SeniorityTester = int.Parse(anyTester.Element("SeniorityTester").Value),
                          MaxTestsTester = int.Parse(anyTester.Element("MaxTestsTester").Value),
                          CarTypeTester=(CarType)Enum.Parse(typeof(CarType),anyTester.Element("CarTypeTester").Value),
                          mat = anyTester.Element("mat").Value.ToMatrix(),
                          MaxFarFromTester = int.Parse(anyTester.Element("MaxFarFromTester").Value)
                      }).FirstOrDefault();
            
                return result;
            
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
                              GenderTester=(Gender)Enum.Parse(typeof(Gender),anyTester.Element("GenderTester").Value),
                              PhoneNumberTester = anyTester.Element("PhoneNumberTester").Value,
                              AddresTester = new Address
                              {
                                  City = anyTester.Element("Address").Element("City").Value,
                                  Street = anyTester.Element("Address").Element("Street").Value,
                                  HouseNum = int.Parse(anyTester.Element("Address").Element("HouseNum").Value)
                              },
                              SeniorityTester = int.Parse(anyTester.Element("SeniorityTester").Value),
                              MaxTestsTester = int.Parse(anyTester.Element("MaxTestsTester").Value),
                              CarTypeTester=(CarType)Enum.Parse(typeof(CarType),anyTester.Element("CarTypeTester").Value),
                              mat = anyTester.Element("mat").Value.ToMatrix(),
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
                               GenderTrainee=(Gender)Enum.Parse(typeof(Gender),tra.Element("GenderTrainee").Value),
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
                               CarTypeTrainee=(CarType)Enum.Parse(typeof(CarType),tra.Element("CarTypeTrainee").Value),
                               GearboxTrainee=(Gearbox)Enum.Parse(typeof(Gearbox),tra.Element("GearboxTrainee").Value),
                               NumberOfLesson = int.Parse(tra.Element("NumberOfLesson").Value),
                               LastExamDate = DateTime.Parse(tra.Element("LastExamDate").Value)
                           }).ToList();
  
            return trainees;
            }

        public List<Test> getTests()
        {
            LoadDataTest();
            List<Test> tests;

            try
            {
                tests = (from anyTest in TestRoot.Elements()

                         select new Test()
                         {
                             TestNum = anyTest.Element("TestNum").Value,
                             TesterId = anyTest.Element("TesterId").Value,
                             TraineeId = anyTest.Element("TraineeId").Value,
                             TestDate = DateTime.Parse(anyTest.Element("TestDate").Value),
                             AddressTest = new Address
                             {
                                 City = anyTest.Element("Address").Element("City").Value,
                                 Street = anyTest.Element("Address").Element("Street").Value,
                                 HouseNum = int.Parse(anyTest.Element("Address").Element("HouseNum").Value)
                             },
                             NoteTester = anyTest.Element("NoteTester").Value,
                             carType= (CarType)Enum.Parse(typeof(CarType), anyTest.Element("carType").Value),
                             gearbox=(Gearbox)Enum.Parse(typeof(Gearbox),anyTest.Element("gearbox").Value),
                             Results=anyTest.Element("Results").ToExamResults()
                         }).ToList();
            }
            catch (Exception)
            {

                
                throw new Exception("לא קיימים מבחנים במערכת");
            }
            
                return tests;
      
        }
        //פונקציה האחראית על המספר הרץ
        
        public string getExamIDNum()
        {


            LoadDataTest();
            bool emptyTestList = false;
            int IdNum;
            try
            {
                List<Test> tests = getTests();
            }
            catch (Exception)
            {

                emptyTestList = true;
            }
            if (emptyTestList)
                IdNum = Configuration.minIDNum;
            else
            {
              IdNum = int.Parse
                    ((from Test t in getTests()
                         orderby t.TestNum
                         select t).Last().TestNum);
            }

            IdNum += 1;
            if (IdNum < 10000000) //reset IDnum - need to check what to do with old tests
            {
                return IdNum.ToString().PadLeft(8, '0'); //return examIDnum as a string and adds '0' to left of the number
            }
            return IdNum.ToString();
        }

    }



}

    

