using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ZooManager.Managers;

namespace ZooManager.Tests.Providers
{
    [TestClass]
    public class ProgressiveTaxCalculatorTests
    {
        [TestMethod]
        public void GetTaxAmt()
        {
            var taxProvider = new ProgressiveTaxCalculator();
            taxProvider.AddTaxRate(10, 10.00m);
            taxProvider.AddTaxRate(5, 100.00m);
            taxProvider.AddTaxRate(1, 999999999.99m);

            (decimal, decimal)[] testData =
            {
                (0.00m, 0.00m),
                (1.00m, 0.10m),
                (2.00m, 0.20m),
                (9.00m, 0.90m),
                (10.00m, 1.00m),
                (50.00m, 2.50m),
                (100.00m, 5.00m)
            };

            foreach((decimal saleAmt, decimal expectedTaxAmt) in testData)
            {
                Decimal actualTaxAmt = taxProvider.GetTaxAmt(saleAmt);
                Assert.AreEqual(expectedTaxAmt, actualTaxAmt, $"Error calculating tax on {saleAmt}.");
            }
        }
    }
}
