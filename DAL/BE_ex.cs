using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;


namespace DAL
{
    internal static class BE_ex
    {
       //***************CLONES*************
        //********clone for address
        public static Address Clone(this Address address)
        {
            return new Address
            {
                City = address.City,
                Street = address.City,
                HouseNum = address.HouseNum

            };
        }
        //*********clone for name**********
        public static FullName Clone(this FullName name)
        {
            return new FullName
            {
                FirstName = name.FirstName,
                LastName = name.LastName
            };
        }
            
        //clone for Trainee

        public static  Trainee Clone(this Trainee t)
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
        public static Test Clone(this Test t)
        {
            return new Test
            {
                TestNum = t.TestNum,
                TesterId = t.TesterId,
                TraineeId = t.TraineeId,
                TestDate = t.TestDate,//did datetime return reffence or copy???????????????????
                HourTest = t.HourTest,
                AddresTest = t.AddresTest.Clone(),
                TestTime = t.TestTime,//did datetime return reffence or copy???????????????????
                NoteTester = t.NoteTester

            };
        }
        public static Tester Clone(this Tester t)
        {
            Tester tester = new Tester
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
                mat = (bool?[,])t.mat.Clone(), //i need to make the clone of mat*********
                MaxFarFromTester = t.MaxFarFromTester
            };
            return tester;
        }


        //************************checks
        public static void CheckCorrectAgeTester(this Tester t)
        {
            if (t.BirthDateTester.AddYears(Configuration.minAgetester) > DateTime.Now)
            {
                throw new Exception("can't be a tester, you are to young");
            }
            if (t.BirthDateTester.AddYears(Configuration.maxAgeTester) < DateTime.Now)
            {
                throw new Exception("can't be a tester, you are to old");
            }
        }

        public static void isCorrectAgeTrainee(this Trainee t)
        {
        if (t.BirthDateTrainee.AddYears(Configuration.minAgeTrainee) > DateTime.Now)
                throw new Exception("This student can't do a test, he is too young");
        }


        public static void DidTraineeExamInRecentTime(this Trainee t)
        {
            
            if (t.LastExamDate.AddDays(-Configuration.minDaysPassFromLastTest) > DateTime.Now); //we need to check if it is correct
            throw new Exception("The studenet did exam in the last " + Configuration.minDaysPassFromLastTest + " days, please wait to correct time");//*** I need to change this
        }
        public static bool didTraineeMinLessons(this Trainee t)
        {
            return (t.NumberOfLesson >Configuration.minLessons);
        }


        public static void didTesterPassLimitExam(this Tester t)
        {
            throw new Exception("not implemented func");
        }
        public static void didTesterVacatedInThisDate(this Tester t, DateTime time)
        {
            throw new Exception("not implemented func");
        }

#if false
        public static bool didStudentPassThisSortVehicle(this Trainee t, Test test)
        {

            return ((t.GearboxTrainee == gear) || (t.GearboxTrainee == Gearbox.גיר_ידני)) //if the student pass exam on manual gear it also good for automatic gear
                & (t.CarTypeTrainee == carType);
        } 
#endif

        public static bool didStudentsExist(this Trainee t)//***IF I MOVE THIS CHECK FUNCTION TO CLASS OF CHEECK, I NEED TO CHANGE THIS FUNCTION
        {
            return DS.DataSource.Trainees.Exists(item => item.IdTrainee == t.IdTrainee);
        }
        public static bool didTesterExist(this Tester t)//***IF I MOVE THIS CHECK FUNCTION TO CLASS OF CHEECK, I NEED TO CHANGE THIS FUNCTION
        {
            return DS.DataSource.Testers.Exists(item => item.IdTester == t.IdTester);
        }

        public static bool didTestExist(this Test t)//***IF I MOVE THIS CHECK FUNCTION TO CLASS OF CHEECK, I NEED TO CHANGE THIS FUNCTION
        {
            return DS.DataSource.Tests.Exists(item => item.TestNum == t.TestNum);
        } 

        public static void DidtesterFitToTrainee(this Tester tester, Trainee trainee)
        {
            if (tester.CarTypeTester != trainee.CarTypeTrainee)
                 throw new Exception("התמחות הבוחן אינה מתאימה לרכב עליו למד הנבחן");
        }
        
    };
   
}
