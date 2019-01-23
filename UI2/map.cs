using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Xml;
using BE;

namespace UI2
{
    class map
    {
        public static double GetDist(Address address1, Address address2)
        {
            string origin = address1.ToString();
            string dest = address2.ToString();
            string KEY = "I9bGtjvRjpNi6GmzMWqcPHb0ACEnGjKx";
            string url = @"https://www.mapquestapi.com/directions/v2/route" +
            @"?key=" + KEY +
            @"&from=" + origin +
            @"&to=" + dest +
            @"&outFormat=xml" +
            @"&ambiguities=ignore&routeType=fastest&doReverseGeocode=false" +
            @"&enhancedNarrative=false&avoidTimedConditions=false";
            //request from MapQuest service the distance between the 2 addresses
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            WebResponse response;
            try
            {
                response = request.GetResponse();
            }
            catch (Exception)
            {

                throw new Exception("שגיאה בחיבור לרשת");
            }
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();
            //the response is given in an XML format
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(responsereader);

            if (xmldoc.GetElementsByTagName("statusCode")[0].ChildNodes[0].InnerText == "0")
            //we have the expected answer
            {
                //display the returned distance
                XmlNodeList distance = xmldoc.GetElementsByTagName("distance");
                double distInMiles = Convert.ToDouble(distance[0].ChildNodes[0].InnerText);
                return (distInMiles * 1.609344);
            }
            else if (xmldoc.GetElementsByTagName("statusCode")[0].ChildNodes[0].InnerText == "402")
            //we have an answer that an error occurred, one of the addresses is not found
            {
                // Console.WriteLine("an error occurred, one of the addresses is not found. try again.");
                throw new Exception("הכתובת אינה תקינה או שאינה קיימת \n נא וודא שאכן הכתובת כתובה באופן תקין ובאותיות אנגליות");
            }
            else //busy network or other error...
            {
                throw new Exception(" שגיאה בשרת");
            }
        }

    }
}
