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

        //we are not need to to clone to address bacause it is a struct and not a class
        
        public static bool?[,] Clone(this bool?[,] mat) //***********not complete*************
        {
            return new bool?[,]
            {

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
                AddressTrainee = t.AddressTrainee,//we not using a clone bacasue it is a struct
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
                AddresTest = t.AddresTest,
                TestTime = t.TestTime,//did datetime return reffence or copy???????????????????
                NoteTester = t.NoteTester

            };
        }
        public static Tester Clone(this Tester t)
        {
            return new Tester
            {
                IdTester = t.IdTester,
                NameTester = t.NameTester.Clone(),
                BirthDateTester = t.BirthDateTester,
                GenderTester = t.GenderTester,//did datetime return reffence or copy???????????????????
                PhoneNumberTester = t.PhoneNumberTester,
                AddresTester = t.AddresTester,
                SeniorityTester = t.SeniorityTester,
                MaxTestsTester = t.MaxTestsTester,
                CarTypeTester = t.CarTypeTester,
                //mat = t.mat.Clone(), //i need to make the clone of mat*********
                MaxFarFromTester = t.MaxFarFromTester
            };
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


        public static bool DidTraineeExamInRecentTime(this Trainee t)
        {
            if (t.LastExamDate == null) return false;

            return (t.LastExamDate.AddDays(-7) > DateTime.Now); //we need to check if it is correct

        }
        public static bool didTrainee20Lesson(this Trainee t)
        {
            return (t.NumberOfLesson > 19);
        }

#if false
        public static bool didTesterPassLimitExam(this Tester t)
        {
        }
        public static bool didTesterVacatedInThisDate(this Tester t, DateTime time)
        {

        }
#endif
        public static bool didStudentPassThisSortVehicle(this Trainee t, Gearbox gear, CarType carType)
        {
            return (t.GearboxTrainee == gear) & (t.CarTypeTrainee == carType);
        }

        public static bool didStudentsExist(this Trainee t)
        {
            throw new Exception("not implemnted");

        }
        public static bool didTesterExist(this Tester t)
        {
            throw new Exception("not implemnted");
        }

        public static bool didTestExist(this Test t)
        {
            throw new Exception("not implemnted");
        } 

        
    };
   
}
