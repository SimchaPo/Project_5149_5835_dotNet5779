using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BE
{
    public static class Checks
    {
        public static void CheckTesterInput(Tester newTester)
        {
            if(newTester.NameTester.FirstName == null || newTester.NameTester.LastName == null ||
                newTester.AddresTester.City == null || newTester.AddresTester.Street == null)
            {
                throw new Exception("אנא השלם את כל הפרטים");
            }
             else if (!(newTester.NameTester.FirstName.Length > 0 && newTester.NameTester.LastName.Length > 0
                 && newTester.AddresTester.City.Length > 0 && newTester.AddresTester.Street.Length > 0))
            {
                throw new Exception("אנא השלם את כל הפרטים");
            }
            CheckString(newTester.NameTester.FirstName, "השם הפרטי");
            CheckString(newTester.NameTester.LastName, "שם המשפחה");
            CheckID(newTester.IdTester);
            CheckPhoneNumber(newTester.PhoneNumberTester);
            CheckString(newTester.AddresTester.City, "שם העיר");
            CheckString(newTester.AddresTester.Street, "שם הרחוב");
            if (newTester.AddresTester.HouseNum == 0)
                throw new Exception("מספר בית לא תקין");
            if (newTester.BirthDateTester.AddYears(Configuration.minAgetester) > DateTime.Now)
            {
                throw new Exception("צעיר מדי להיות בוחן");
            }
            if (newTester.BirthDateTester.AddYears(Configuration.maxAgeTester) < DateTime.Now)
            {
                throw new Exception("מבוגר מדי להיות בוחן");
            }
        }
        public static void CheckTraineeInput(Trainee newTrainee)
        {
            if(newTrainee.NameTrainee.FirstName == null || newTrainee.NameTrainee.LastName == null ||
                newTrainee.AddressTrainee.City == null || newTrainee.AddressTrainee.Street == null ||
                newTrainee.SchoolTrainee == null || newTrainee.TeacherTrainee == null)
            {
                throw new Exception("אנא השלם את כל הפרטים");
            }
            else if(!(newTrainee.NameTrainee.FirstName.Length > 0 && newTrainee.NameTrainee.LastName.Length > 0 &&
                newTrainee.AddressTrainee.City.Length > 0 && newTrainee.AddressTrainee.Street.Length > 0 &&
                newTrainee.SchoolTrainee.Length > 0 && newTrainee.TeacherTrainee.Length > 0))
            {
                throw new Exception("אנא השלם את כל הפרטים");
            }
            CheckString(newTrainee.NameTrainee.FirstName, "השם הפרטי");
            CheckString(newTrainee.NameTrainee.LastName, "שם המשפחה");
            CheckID(newTrainee.IdTrainee);
            CheckPhoneNumber(newTrainee.PhoneNumberTrainee);
            CheckString(newTrainee.AddressTrainee.City, "שם העיר");
            CheckString(newTrainee.AddressTrainee.Street, "שם הרחוב");
            if (newTrainee.AddressTrainee.HouseNum == 0)
                throw new Exception("מספר בית לא תקין");
            CheckString(newTrainee.SchoolTrainee, "שם בית הספר");
            CheckString(newTrainee.TeacherTrainee, "שם המורה");
            if (newTrainee.BirthDateTrainee.AddYears(Configuration.minAgeTrainee) > DateTime.Now)
            {
                throw new Exception("תלמיד צעיר מדי");
            }
        }
        public static void CheckID(string myID)
        {
            if (!(myID.Any(c => char.IsDigit(c)) && myID.Length == 9))
            throw new Exception("מספר זהות לא תקין");
            int sum = 0, j;
            int[] arr = new int[8];
            for(int i = 0; i <= 6; i += 2)
            {
                sum += int.Parse(myID[i].ToString());
                j = 2*int.Parse(myID[i + 1].ToString());
                if (j > 9)
                {
                    j = 1 + j % 10;
                }
                sum += j;
            }
            if (10 - (sum % 10) != int.Parse(myID[8].ToString()))
                throw new Exception ("מספר זהות לא חוקי");
        }
        public static void CheckPhoneNumber(string myNumber)
        {
            if(!(myNumber.Any(c => char.IsDigit(c)) && myNumber[0] == '0' &&
                ((myNumber.Length == 10 && myNumber[1] == '5')  || (myNumber.Length == 9 && myNumber[1] != '5'))))
            throw new Exception("מספר טלפון לא תקין");
        }

        public static void CheckString(string myString, string item)
        {
            if (myString.Any(c => !(char.IsLetter(c) || char.IsWhiteSpace(c))))
                throw new Exception(item + " לא תקין");
        }

        //***************CLONES*************
        //********clone for address
        public static Address Clone(this Address address)
        {
            if (address != null)
            {
                return new Address
                {
                    City = address.City,
                    Street = address.City,
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
                    TeacherTrainee = t.TeacherTrainee
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
                    HourTest = t.HourTest,
                    AddressTest = t.AddressTest.Clone(),
                    TestTime = t.TestTime,//did datetime return reffence or copy???????????????????
                    NoteTester = t.NoteTester
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
                    GenderTester = t.GenderTester,//did datetime return reffence or copy???????????????????
                    PhoneNumberTester = t.PhoneNumberTester,
                    AddresTester = t.AddresTester.Clone(),
                    SeniorityTester = t.SeniorityTester,
                    MaxTestsTester = t.MaxTestsTester,
                    CarTypeTester = t.CarTypeTester,
                    mat = (bool[,])t.mat.Clone(), //i need to make the clone of mat*********
                    MaxFarFromTester = t.MaxFarFromTester
                };
            }
            return null;
        }
        public static string ToString(bool[,]mat)
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
        public static bool[,] ToMatrix(string work)
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

        public static void DidTraineeExamInRecentTime(this Trainee t)
        {

            if (t.LastExamDate.AddDays(-Configuration.minDaysPassFromLastTest) > DateTime.Now) //we need to check if it is correct
                throw new Exception("The studenet did exam in the last " + Configuration.minDaysPassFromLastTest + " days, please wait to correct time");//*** I need to change this
        }
        public static bool didTraineeMinLessons(this Trainee t)
        {
            return t.NumberOfLesson > Configuration.minLessons;
        }


        public static void didTesterPassLimitExam(this Tester t)
        {
            throw new Exception("not implemented func");
        }
        public static void didTesterVacatedInThisDate(this Tester t, DateTime time)
        {
            throw new Exception("not implemented func");
        }

        private static void checkAdress(Address Address1) //this function to check integrity of the address, 
                                                          //for the check, I operate the query between the current address and a permanent address and check the response of the server
        {

            int NetErrorCounter = 0;
            Address address2 = new Address { City = "beit shemesh", Street = "nachal ein gedi", HouseNum = 40 };
            string origin = Address1.ToString();
            string destination = address2.ToString();
            string KEY = "I9bGtjvRjpNi6GmzMWqcPHb0ACEnGjKx";
            string url = @"https://www.mapquestapi.com/directions/v2/route" +
            @"?key=" + KEY +
            @"&from=" + origin +
            @"&to=" + destination +
            @"&outFormat=xml" +
            @"&ambiguities=ignore&routeType=fastest&doReverseGeocode=false" +
            @"&enhancedNarrative=false&avoidTimedConditions=false";
            for (int i = 0; i < 3; i++)
            {
                //request from MapQuest service the distance between the 2 addresses
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                WebResponse response;
                try
                {
                    response = request.GetResponse();
                }
                catch (Exception)
                {

                    throw new Exception("שגיאה בחיבור לרשת");
                }
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                response.Close();
                //the response is given in an XML format
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(responsereader);
                if (xmldoc.GetElementsByTagName("statusCode")[0].ChildNodes[0].InnerText == "0")
                //we have the expected answer
                {
                    //display the returned distance
                    XmlNodeList distance = xmldoc.GetElementsByTagName("distance");
                    double distInMiles = Convert.ToDouble(distance[0].ChildNodes[0].InnerText);
                    // Console.WriteLine("Distance In KM: " + distInMiles * 1.609344);
                    Console.WriteLine(distInMiles * 1.609344);
                    if ((distInMiles == 3.162) || (distInMiles * 1.609344 > 550)) //3.162 miles is usualy when there is some error,
                        //and 550 Km is most long route that can a be in israel
                        throw new Exception("הכתובת אינה תקינה או שאינה קיימת \n נא וודא שאכן הכתובת כתובה באופן תקין ובאותיות אנגליות");



                    //display the returned driving time
                    // XmlNodeList formattedTime = xmldoc.GetElementsByTagName("formattedTime");
                    // string fTime = formattedTime[0].ChildNodes[0].InnerText;
                    //  Console.WriteLine("Driving Time: " + fTime);
                }
                else if (xmldoc.GetElementsByTagName("statusCode")[0].ChildNodes[0].InnerText == "402")
                //we have an answer that an error occurred, one of the addresses is not found
                {
                    // Console.WriteLine("an error occurred, one of the addresses is not found. try again.");
                    throw new Exception("הכתובת אינה תקינה או שאינה קיימת \n נא וודא שאכן הכתובת כתובה באופן תקין ובאותיות אנגליות");
                }
                else //busy network or other error...
                {
                    // Console.WriteLine("We have'nt got an answer, maybe the net is busy...");
                    if (NetErrorCounter <= 3)
                        NetErrorCounter++;
                    else
                        throw new Exception("שגיאה בשרת");
                }

            }
        }


    }
}
