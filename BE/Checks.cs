using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Checks
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

    }
}
