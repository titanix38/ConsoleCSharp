using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationEF
{
    public partial class Book
    {
        public decimal VATPrice
        {
            get { return ((Price ?? 0m) * 1.05); }
        }
    }
}
