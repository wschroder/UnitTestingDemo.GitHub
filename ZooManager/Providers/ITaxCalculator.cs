using System;
using ZooManager.Entities;

namespace ZooManager.Providers
{
    public interface ITaxCalculator
    {
        Decimal GetTaxAmt(decimal saleAmt);

        bool QualifiesForSnap(RetailItem item);
    }
}
