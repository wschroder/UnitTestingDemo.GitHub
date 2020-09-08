using System;
using ZooManager.Entities;

namespace ZooManager.Providers
{
    public class FlatTaxCalculator : ITaxCalculator
    {
        private readonly Decimal _taxRate;

        public FlatTaxCalculator(decimal taxRate)
        {
            _taxRate = taxRate;
        }

        public bool QualifiesForSnap(RetailItem item)
        {
            return true;
        }

        public decimal GetTaxAmt(decimal saleAmt)
        {
            return saleAmt * _taxRate;
        }
        
    }
}
