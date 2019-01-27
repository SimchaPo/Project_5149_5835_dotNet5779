using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Xml.Linq; //*******delete this?????

namespace DAL
{
    internal static class BE_ex
    {
        //***************CLONES*************
        //********clone for address
        public static Address Clone(this Address address)
        {
            if (address != null) {
                return new Address
                {
                    City = address.City,
                    Street = address.Street,
                    HouseNum = address.HouseNum
                };
            }
            return null;
        }
        //*********clone for name**********
        public static FullName Clone(this FullName name)
        {
            if (name != null)
            {
                return new FullName
                {
                    FirstName = name.FirstName,
                    LastName = name.LastName
                };
            }
            return null;
        }

        public static examResults Clone(this examResults results)
        {
            if(results != null)
            {
                return new examResults
                {
                    mirrors = results.mirrors,
                    blinker = results.blinker,
                    distance = results.distance,
                    passTest = results.passTest
                };
            }
            return null;
        }
        //clone for Trainee

        public static Trainee Clone(this Trainee t)
        {
            if (t != null)
            {
                return new Trainee
                {
                    IdTrainee = t.IdTrainee,
                    NameTrainee = t.NameTrainee.Clone(),
                    GenderTrainee = t.GenderTrainee,
                    PhoneNumberTrainee = t.PhoneNumberTrainee,
                    AddressTrainee = t.AddressTrainee.Clone(),
                    BirthDateTrainee = t.BirthDateTrainee, //did datetime return reffence or copy???????????????????
                    CarTypeTrainee = t.CarTypeTrainee,
                    GearboxTrainee = t.GearboxTrainee,
                    SchoolTrainee = t.SchoolTrainee,
                    TeacherTrainee = t.TeacherTrainee,
                    NumberOfLesson = t.NumberOfLesson
                };
            }
            return null;
        }
        public static Test Clone(this Test t)
        {
            if (t != null)
            {
                return new Test
                {
                    TestNum = t.TestNum,
                    TesterId = t.TesterId,
                    TraineeId = t.TraineeId,
                    TestDate = t.TestDate,//did datetime return reffence or copy???????????????????
                    AddressTest = t.AddressTest.Clone(),
                    NoteTester = t.NoteTester,
                    Results = t.Results
                };
            }
            return null;
        }
        public static Tester Clone(this Tester t)
        {
            if (t != null)
            {
                return new Tester
                {
                    IdTester = t.IdTester,
                    NameTester = t.NameTester.Clone(),
                    BirthDateTester = t.BirthDateTester,
                    GenderTester = t.GenderTester,
                    PhoneNumberTester = t.PhoneNumberTester,
                    AddresTester = t.AddresTester.Clone(),
                    SeniorityTester = t.SeniorityTester,
                    MaxTestsTester = t.MaxTestsTester,
                    CarTypeTester = t.CarTypeTester,
                    mat = (bool[,])t.mat.Clone(),
                    MaxFarFromTester = t.MaxFarFromTester
                };
            }
            return null;
        }

        //this function for Dal_xml class
        public static XElement ToXElement(this FullName fullName)
        {
            XElement FirstName = new XElement("FirstName", fullName.FirstName);
            XElement LastName = new XElement("LastName", fullName.LastName);
            return new XElement("FullName", FirstName, LastName);
        }

        public static XElement ToXElement(this examResults results)
        {
            if (results != null)
            {
                XElement mirrors = new XElement("mirrors", results.mirrors.ToString());
                XElement blinker = new XElement("blinker", results.blinker.ToString());
                XElement distance = new XElement("distance", results.distance.ToString());
                XElement passTest = new XElement("passTest", results.passTest.ToString());
                return new XElement("Results", mirrors, blinker, distance, passTest);
            }
            else
                return new XElement("Results", "null");
        }

        public static examResults ToExamResults(this XElement Result)
        {
            if (Result.Value != "null")
                return new examResults()
                {                   
                    mirrors = bool.Parse(Result.Element("mirrors").Value),
                    blinker = bool.Parse(Result.Element("blinker").Value),
                    distance = bool.Parse(Result.Element("distance").Value),
                    passTest = bool.Parse(Result.Element("passTest").Value)
                };
            else
                return null;
        }

        public static XElement ToXElement(this Address address)
        {
            XElement City = new XElement("City", address.City);
            XElement Street = new XElement("Street", address.Street);
            XElement HouseNum = new XElement("HouseNum", address.HouseNum);
            return new XElement("Address", City, Street, HouseNum);
        }

        public static string ToStringMat(this bool[,] mat)
        {
            string time = "";
            for (int i = 0; i < 5; ++i)
            {
                time += "d " + i;
                for (int j = 0; j < 7; ++j)
                {
                    if (mat[i, j] == true)
                    {
                        time += " h " + j;
                    }
                }
                time += "\n";
            }
            return time;
        }

        public static bool[,] ToMatrix(this string work)
        {
            bool[,] mat = new bool[5, 7] { { false, false, false, false, false, false, false},
                { false, false, false, false, false, false, false },
                { false, false, false, false, false, false, false },
                { false, false, false, false, false, false, false }, { false, false, false, false, false, false, false } };
            int i = -1;
            bool flag = false;
            foreach (char a in work)
            {
                if (a == 'd')
                {
                    ++i;
                    flag = false;
                }
                if (char.IsDigit(a))
                {
                    if (flag == true)
                    {
                        mat[i, int.Parse(a.ToString())] = true;
                    }
                    flag = true;
                }
            }
            return mat;
        }       
    };   
}