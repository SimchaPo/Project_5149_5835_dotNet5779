using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    interface IBL
    {
        void addTester(Tester newTester);
        void removeTester();
        void changeTester();

        void addTrainee(Trainee newTrainee);
        void removeTrainee();
        void changeTrainee();

        void addTest(Test newTest);
        void updateTest();

        List<Tester> getTestersFilter(Func<Tester,bool> filter);
        List<Tester> getTesters();
        List<Trainee> getTrainees();
        List<Test> getTests();
    }
}
