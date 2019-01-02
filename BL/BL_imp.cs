using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    class BL_imp : IBL
    {
        public void addTest(Test newTest)
        {
            //בדיקה שעברו 7 ימים מטסט קודם
            throw new NotImplementedException();
        }

        public void addTester(Tester newTester)
        {
          //  if(newTester.)
            //בדיקת גיל הטסטר מינימום 40
            // טסטר זמין
            throw new NotImplementedException();
        }

        public void addTrainee(Trainee newTrainee)
        {
            //בדיקת גיל תלמיד, מינימום 18
            // מינימום 20 שיעורים
            throw new NotImplementedException();
        }

        public void changeTester()
        {
            throw new NotImplementedException();
        }

        public void changeTrainee()
        {
            throw new NotImplementedException();
        }

        public List<Tester> getTesters()
        {
            throw new NotImplementedException();
        }

        public List<Tester> getTestersFilter(Func<Tester, bool> filter =null)
        {
            throw new NotImplementedException();
        }

        public List<Test> getTests()
        {
            throw new NotImplementedException();
        }

        public List<Trainee> getTrainees()
        {
            throw new NotImplementedException();
        }

        public void removeTester()
        {
            throw new NotImplementedException();
        }

        public void removeTrainee()
        {
            throw new NotImplementedException();
        }

        public void updateTest()
        {
            throw new NotImplementedException();
        }
    }
}
