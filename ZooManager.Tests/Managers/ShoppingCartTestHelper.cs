using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using ZooManager.Entities;
using ZooManager.Managers;
using ZooManager.Providers;

namespace ZooManager.Tests.Managers
{
    public class ShoppingCartTestHelper
    {
        private readonly Mock<ITaxCalculator> _mockTaxCalculator = new Mock<ITaxCalculator>();
        private readonly Mock<IConfiguration> _mockConfig = new Mock<IConfiguration>();
        private readonly Mock<ICreditAccount> _mockCustomerAccount = new Mock<ICreditAccount>();
        private readonly List<RetailItem> itemsChecked = new List<RetailItem>();

        private ShoppingCartTestHelper()
        {
        }

        public static ShoppingCartTestHelper Create()
        {
            return new ShoppingCartTestHelper();
        }

        public void Setup_TaxCalculator_GetTaxAmt(decimal taxAmt)
        {
            _mockTaxCalculator.Setup(o => o
                                .GetTaxAmt(It.IsAny<decimal>()))
                                .Returns(taxAmt);
        }

        public void Setup_Config_Get(string name, string value)
        {
            _mockConfig.Setup(o => o[name]).Returns(value);
        }

        public ShoppingCart CreateShoppingCart(int maxItems = 10)
        {
            Setup_Config_Get("Cart:MaxItems", maxItems.ToString());

            var cart = new ShoppingCart(_mockTaxCalculator.Object, _mockCustomerAccount.Object, _mockConfig.Object);
            return cart;
        }

        public void Verify_CustomerAccount_AddCharge(bool callExpected)
        {
            Func<Times> timesCalled;
            if (callExpected)
            {
                timesCalled = Times.Once;
            }
            else
            {
                timesCalled = Times.Never;
            }

            _mockCustomerAccount.Verify(o => o.AddCharge(It.IsAny<decimal>()), timesCalled);
        }

        public void Setup_TaxCalculator_QualifiesForSnap()
        {
            Action<RetailItem> snapCheckCallback = (item) =>
            {
                if (item.UnitPrice > 100)
                {
                    throw new Exception("Expensive baby stuff");
                }
                itemsChecked.Add(item);
            };

            _mockTaxCalculator.Setup(o => o
                                .QualifiesForSnap(It.IsAny<RetailItem>()))
                                .Callback(snapCheckCallback);
        }

        public void Verify_TaxCalculator_QualifiesForSnap(params string[] itemsExpected)
        {
            Assert.AreEqual(itemsExpected.Length, itemsChecked.Count);

            foreach(string item in itemsExpected)
            {
                itemsChecked.Exists(o => o.Name == item);
            }
        }
    }
}
