using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FactoryDal
    {
        protected static Dal_imp myDal = null;


        public static Idal GetDal()
        {
            if (myDal == null)
            {
                myDal = new Dal_imp();
            }
            return myDal;
        }
    }
}
