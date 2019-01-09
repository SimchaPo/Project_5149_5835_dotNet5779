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
};
   
}
