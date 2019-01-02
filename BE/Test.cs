using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Test
    {
        public Test(string TesterId, string TraineeId)
        {
            testNum = test_num.ToString();
            testerId = TesterId;
            traineeId = TraineeId;
        }
        static int test_num = 0;
        string testNum;
        string testerId;
        string traineeId;
        string testDate;
        string hourTest;
        Addres addresTest;
        testChecks distance;
        testChecks parking;
        testChecks mirrors;
        testChecks blinker;
        bool passTest;
        string noteTester;
        DateTime testTime;
    }
}
