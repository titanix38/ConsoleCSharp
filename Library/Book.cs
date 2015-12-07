using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationLibrary
{
    public class Book : Media
    {
        public int NbPage { get; set; }

        public override double VATPrice
        {
            get
            {
                return Price * 1.05;
            }
        }
    }
}
