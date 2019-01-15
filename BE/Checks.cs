using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public static class Checks
    {
        public static bool checkID(string myID)
        {
            return myID.Any(c => char.IsDigit(c)) && myID.Length == 9;
        }
        public static bool checkPhoneNumber(string myNumber)
        {
            return myNumber.Any(c => char.IsDigit(c)) && myNumber.Length == 10;
        }
        public static bool CheckForNullTester(Tester t)
        {
            foreach (bool? item in t.mat)
            {
                if (item == null)
                {
                    return true;
                }
            }
            return t.IdTester == null || t.NameTester.FirstName == null || t.NameTester.LastName == null
                || t.PhoneNumberTester == null || t.AddresTester.City == null ||
                t.AddresTester.Street == null;
        }
        public static bool CheckForNullTrainee(Trainee t)
        {
            return t.IdTrainee == null || t.NameTrainee.FirstName == null || t.NameTrainee.LastName == null
                || t.PhoneNumberTrainee == null || t.AddressTrainee.City == null ||
                t.AddressTrainee.Street == null || t.SchoolTrainee == null || t.TeacherTrainee == null;
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
                AddresTester = t.AddresTester,
                SeniorityTester = t.SeniorityTester,
                MaxTestsTester = t.MaxTestsTester,
                CarTypeTester = t.CarTypeTester,
                mat = (bool?[,])t.mat.Clone(), //i need to make the clone of mat*********
                MaxFarFromTester = t.MaxFarFromTester
            };
            return tester;
        }
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

        public static Trainee Clone(this Trainee t)
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
    }
}
