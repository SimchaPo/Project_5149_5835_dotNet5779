using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    public interface IBL
    {
        void addTester(Tester newTester);
        void removeTester(string idTester);
        void changeTester(Tester updateTester);

        void addTrainee(Trainee newTrainee);
        void removeTrainee(string iTrainee);
        void changeTrainee(Trainee updateTrainee);

        void AddTest(Test newTest);
        void updateTest(Test updateTest);

        bool farFromAddress(Address traineeAddress);
        bool testerWorksAtDayAndHour(DateTime dateTime, Tester tester);

        int amountOfTests(string traineeID);
        bool pastTest(string traineeID);
        Test GetTest(string id);
        Trainee GetTrainee(string trainee);
        Tester GetTester(string id);

        List<Tester> getTestersAvailable(DateTime dateTime);

        List<Tester> getTesters();
        List<Trainee> getTrainees();
        List<Test> getTests();
    }
}
