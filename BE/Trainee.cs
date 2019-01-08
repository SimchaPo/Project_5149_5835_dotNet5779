using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Trainee
    {
        public Trainee()
        {
            NameTrainee = new FullName();
            AddressTrainee = new Address();
        }
        public string IdTrainee { get; set; }
        public FullName NameTrainee { get; set; }
        public Gender GenderTrainee { get; set; }
        public string PhoneNumberTrainee { get; set; }
        public Address AddressTrainee { get; set; }
        public DateTime BirthDateTrainee { get; set; }
        public CarType CarTypeTrainee { get; set; }
        public Gearbox GearboxTrainee { get; set; }
        public string SchoolTrainee { get; set; }
        public string TeacherTrainee { get; set; }
    }
}
