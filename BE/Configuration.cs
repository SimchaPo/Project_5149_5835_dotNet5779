﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Configuration
    {
        const int minLessons = 20; //the minimum amount of lesson for student to do a test
        const int daysPass = 7; // pass days from last test
        const int maxAgeTester = 75; // max age of tester
        const int minAgetester = 30; // min age of tester
        const int minAgeTrainee = 17; // min age of trainee
        public const int minIDNum = 1000; // min num for test id

    }
}
