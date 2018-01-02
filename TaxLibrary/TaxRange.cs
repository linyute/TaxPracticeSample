using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxLibrary
{
    public class TaxRange
    {
        public decimal Low { get; set; }

        public decimal? High { get; set; }

        public decimal Percentage { get; set; }
    }
}
