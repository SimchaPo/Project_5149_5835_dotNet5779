using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DS
{
    public class DataSource
    {
        //******exam list**********
        private static List<Test> tests = new List<Test>();  //list of all of the exams
        public static List<Test> Tests//property
        {
            get { return tests; } //return refferece of the tests list
        }
        //********testers list**********
        private static List<Tester> testers = new List<Tester>(); //list of all of the testers
        public static List<Tester> Testers//property
        {
            get { return testers; }//return refferece of the testers list
        }

        //******trainee list******
        private static List<Trainee> trainees = new List<Trainee>(); //list of all of the students that signed to the tests
        public static List<Trainee> Trainees
        { //propterty
            get { return trainees; }
        } //return refference of the trainee list
    }
}
