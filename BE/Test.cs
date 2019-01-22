using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Test
    {
        public Test()
        {
            AddressTest = new Address();
        }
        public string TestNum { get; set; }
        public string TesterId { get; set; }
        public string TraineeId { get; set; }
        public DateTime TestDate { get; set; }
        public Address AddressTest { get; set; }
        public string NoteTester { get; set; }
        public CarType carType { get; set; }
        public Gearbox gearbox { get; set; }
        public examResults Results { get; set; }
    }
}
