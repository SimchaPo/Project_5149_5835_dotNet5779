﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNum { get; set; }

        public string ToString()
        {
            return Street + " " + HouseNum + " " + City + " israel";
        }
    }

}
