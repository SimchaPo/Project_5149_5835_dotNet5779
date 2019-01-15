using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FactoryDal
    {
        protected static Dal_xml myDal = null;

        public static Idal GetDal()
        {
            if (myDal == null)
            {
                myDal = new Dal_xml();
            }
            return myDal;
        }
    }
}
