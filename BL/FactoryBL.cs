using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class FactoryBL
    {
        protected static BL_imp myBL = null;

        public static IBL GetBL()
        {
            if (myBL == null)
            {
                myBL = new BL_imp();
            }
            return myBL;
        }
    }
}
