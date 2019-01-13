using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace DAL
{
    class Dal_xml
    {
        XElement TesterRoot;
        string TesterPath = @"TesterXml.xml"; //did i need property in the path????
        XElement TraineeRoot;
        string TraineePath = @"TraineeXml.xml"; //did i need property in the path????
        XElement TestRoot;
        string TestPath = @"TestXml.xml"; //did i need property in the path????

        public Dal_xml()
        {
            if (!File.Exists(TesterPath))
                CreateFileTester();
            else
                LoadDataTester();

            if (!File.Exists(TraineePath))
                CreateFileTrainee();
            else
                LoadDateTrainee();

            if (!File.Exists(TestPath))
                CreateFileTest();
            else
                LoadDataTest();
        }

        private void CreateFileTester()
        {
            TesterRoot = new XElement("Testers");
            TesterRoot.Save(TesterPath);
        }

        private void LoadDataTester()
        {
            try
            {
                TesterRoot = XElement.Load(TesterPath);
            }
            catch
            {
                throw new Exception("שגיאה בטעינת קובץ הבוחנים");
            }
        }

        private void CreateFileTrainee()
        {
            TraineeRoot = new XElement("Trainees");
            TraineeRoot.Save(TraineePath);
        }

        private void LoadDateTrainee()
        {
            try
            {
                TraineeRoot = XElement.Load(TraineePath);
            }
            catch
            {
                throw new Exception("שגיאה בטעינת קובץ התלמידים");
            }
        }

        private void CreateFileTest()
        {
            TestRoot = new XElement("Tests");
            TestRoot.Save(TestPath);
        }

        private void LoadDataTest()
        {
            try
            {
                TestRoot = XElement.Load(TestPath);
            }
            catch
            {
                throw new Exception("שגיאה בטעינת קובץ המבחנים");
            }
        }
    }
}
