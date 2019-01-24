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

        private List<Trainee> getTraineesBySelectedSchool(string SelectedScholl, bool IsOrdered)
        {
            List<Trainee> result;

            //var v = (from anyGroup in bl.GetTraineesGroupedBySchool(IsOrdered)
            //         where anyGroup.Key==SelectedScholl).ToList().FirstOrDefault();

            return null;
        }
    }
}
