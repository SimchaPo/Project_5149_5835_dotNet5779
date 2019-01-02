using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    interface Idal
    {
        void addTester(Tester newTester);
        void removeTester();
        void changeTester();

        void addTrainee(Trainee newTrainee);
        void removeTrainee();
        void changeTrainee();

        void AddTest(Test newTest);
        void updateTest();

        List<Tester> getTesters();
        List<Trainee> getTrainees();
        List<Test> getTests();
    }
}
