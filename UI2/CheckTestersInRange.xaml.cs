using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BE;
using System.ComponentModel;

namespace UI2
{
    public class inputMap
    {
        public Tester tester;
        public Address address;
    }

    public class outputMap
    {
        public Tester tester;
        public double distance;
    }

    class WorkerHelp
    {
        public BackgroundWorker worker;
        public inputMap input_map;
        public WorkerHelp(inputMap INAPUTMAP)
        {
            worker = new BackgroundWorker();
            input_map = INAPUTMAP;
        }

    }

        /// <summary>
        /// Interaction logic for CheckTestersInRange.xaml
        /// </summary>
        public partial class CheckTestersInRange : Window
    {
        List<Tester> TestersInRange;
        List<WorkerHelp> listOfWorkers;


        public CheckTestersInRange(Address traineeAddress, List<Tester> listOfTesters)
        {
            InitializeComponent();
            TestersInRange = new List<Tester>();
            listOfWorkers= new List<WorkerHelp>();

            myPrgressBar.Maximum = listOfTesters.Count();
            myPrgressBar.Value = 0;

            listOfWorkers = (listOfTesters.Select(t => new WorkerHelp(new inputMap() { address = traineeAddress, tester = t }))).ToList();

            foreach(WorkerHelp item in listOfWorkers)
            {
                item.worker.DoWork += Worker_DoWork;
                item.worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
                item.worker.WorkerSupportsCancellation = true;

                item.worker.RunWorkerAsync(item.input_map);
            }

        }


        public void Worker_DoWork(object sender, DoWorkEventArgs e)
        {

            inputMap input = (inputMap)e.Argument;

            double dist;
            try
            {
                dist = map.GetDist(input.address, input.tester.AddresTester);
            }
            catch (Exception) //אם ישנה שגיאה נשים ערך ברירת מחדל במרחק
            {
                dist = 20;
            }

            e.Result = new outputMap() { tester = input.tester, distance = dist };

        }
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {


            outputMap output = (outputMap)e.Result;

            if (output.tester.MaxFarFromTester > output.distance)
                TestersInRange.Add(output.tester);
            myPrgressBar.Value += 1;
        }
    }
}
