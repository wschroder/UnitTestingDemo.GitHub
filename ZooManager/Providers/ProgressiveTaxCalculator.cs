using System;
using System.Collections.Generic;
using ZooManager.Entities;
using ZooManager.Providers;

namespace ZooManager.Managers
{
    public class ProgressiveTaxCalculator : ITaxCalculator
    {
        private List<(int, decimal)> _taxRateTable = new List<(int, decimal)>();

        public void AddTaxRate(int taxRate, Decimal upToAmount)
        {
            _taxRateTable.Add((taxRate, upToAmount));
        }

        public decimal GetTaxAmt(decimal saleAmt)
        {
            int taxRate = 0;

            foreach((int rate, decimal upToAmount) in _taxRateTable)
            {
                taxRate = rate;

                if (saleAmt > upToAmount)
                {
                    continue;
                }
                break;
            }
            Decimal taxAmt = saleAmt * ((decimal) taxRate / 100.00m);
            return Math.Round(taxAmt,2);
        }

        public bool QualifiesForSnap(RetailItem item)
        {
            return true;
        }
    }
}
