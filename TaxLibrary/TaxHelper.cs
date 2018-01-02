using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxLibrary
{
    public class TaxHelper
    {
        private static List<TaxRange> _taxRanges;

        public static List<TaxRange> TaxRanges
        {
            get
            {
                if (_taxRanges == null || _taxRanges.Count == 0)
                {
                    _taxRanges = new List<TaxRange>()
                    {
                        new TaxRange() { Low = 0m,        High = 540000m,   Percentage = 0.05m },
                        new TaxRange() { Low = 540001m,   High = 1210000m,  Percentage = 0.12m },
                        new TaxRange() { Low = 1210001m,  High = 2420000m,  Percentage = 0.2m },
                        new TaxRange() { Low = 2420001m,  High = 4530000m,  Percentage = 0.3m },
                        new TaxRange() { Low = 4530001m,  High = 10310000m, Percentage = 0.4m },
                        new TaxRange() { Low = 10310001m, Percentage = 0.5m }
                    };
                }

                return _taxRanges;
            }
        }

        public static decimal GetTaxResult(decimal income)
        {
            var ranges = TaxRanges.Where(x => income >= x.Low);

            var results = ranges.Sum(range =>
            {
                var realHigh = range.High ?? income;

                var maxIncome = income >= realHigh ? realHigh : income;

                var realRow = range.Low > 0m ? range.Low - 1 : 0m;

                return (maxIncome - realRow) * range.Percentage;
            });

            return results;
        }
    }
}
