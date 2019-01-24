using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BE;
using BL;

namespace UI2
{
    public partial class groups : Window
    {
        //********************* help functions for comboBox*********************************

        private List<string> getListOfCarTypeTesterForComboBox()
        {
            return (from anyGroup in bl.GetTestersGroupedByCarType(true)
                     select anyGroup.Key.ToString()).ToList();
        }

        private List<Tester> getTestersBySelectedCarType(string SelectedCarType,bool IsOrdred)
        {
            List<Tester> result = new List<Tester>();
            var v = (from anyGroup in bl.GetTestersGroupedByCarType(IsOrdred)
                     where anyGroup.Key.ToString() == SelectedCarType
                     select anyGroup).ToList().FirstOrDefault();
            foreach(Tester tester in v)
            {
                result.Add(tester);
            }


            return result;
        }

        private List<Trainee> getTraineesBySelectedSchool(string SelectedSchool, bool IsOrdered)
        {
            List<Trainee> result = new List<Trainee>();


            var v = (from anyGroup in bl.GetTraineesGroupedBySchool(IsOrdered)
                    where anyGroup.Key==SelectedSchool
                     select anyGroup).ToList().FirstOrDefault();
            foreach(Trainee trainee in v)
            {
                result.Add(trainee);
            }

            return result;
        }
        private List<Trainee> getTraineeBySelectedNumOfTests(int numOfTests,bool IsOrdered)
        {
            List<Trainee> result = new List<Trainee>();


            var v = (from anyGroup in bl.GetTraineesGroupedByNumOfTests(IsOrdered)
                     where anyGroup.Key == numOfTests
                     select anyGroup).ToList().FirstOrDefault();
            foreach (Trainee trainee in v)
            {
                result.Add(trainee);
            }

            return result;
        }

        private List<Trainee> getTraineeBySelectedTeacher(string teacher,bool IsOrdered)
        {
            List<Trainee> result = new List<Trainee>();


            var v = (from anyGroup in bl.GetTreineesGroupedByTeacher(IsOrdered)
                     where anyGroup.Key == teacher
                     select anyGroup).ToList().FirstOrDefault();
            foreach (Trainee trainee in v)
            {
                result.Add(trainee);
            }

            return result;
        }

        private List<string> getListForComboBoxBySChool()
        {
            return (from g in bl.GetTraineesGroupedBySchool(true)
                     select g.Key.ToString()).ToList();
        }
        private List<string> getListForComboBoxByTeacher()
        {
            return (from g in bl.GetTreineesGroupedByTeacher(true)
                    select g.Key.ToString()).ToList();
        }

        private List<int> getListForComboBoxByNumOfTests()
        {
            return (from g in bl.GetTraineesGroupedByNumOfTests(true)
                    select g.Key).ToList();
            
        }
    }
}
