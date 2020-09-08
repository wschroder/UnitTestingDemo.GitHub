using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ZooManager.Entities;
using ZooManager.Exceptions;
using ZooManager.Managers;

namespace ZooManager.Tests.Managers
{
    [TestClass]
    public class ShoppingCartTests
    {

        [TestMethod]
        public void CalculateTotal()
        {
            var testHelper = ShoppingCartTestHelper.Create();

            ShoppingCart cart = testHelper.CreateShoppingCart();

            cart.AddItem(new RetailItem("apple", 1.00m));
            cart.AddItem(new RetailItem("banana", 2.00m));
            cart.AddItem(new RetailItem("carrot", 3.00m));

            testHelper.Setup_TaxCalculator_GetTaxAmt(0.23m);

            Decimal salePrice = cart.CalculateTotal();

            Assert.AreEqual(6.23m, salePrice);
        }

        [TestMethod]
        public void AddItem_WhenCartFull()
        {
            var testHelper = ShoppingCartTestHelper.Create();

            ShoppingCart cart = testHelper.CreateShoppingCart(2);

            cart.AddItem(new RetailItem("apple", 1.00m));
            cart.AddItem(new RetailItem("banana", 2.00m));

            Assert.ThrowsException<CartException>(() =>
            {
                cart.AddItem(new RetailItem("donut", 1.00m));
            });
        }

        [TestMethod]
        public void CompleteSale_WhenHappyPath()
        {
            var testHelper = ShoppingCartTestHelper.Create();

            ShoppingCart cart = testHelper.CreateShoppingCart();

            cart.AddItem(new RetailItem("apple", 1.00m));
            cart.AddItem(new RetailItem("banana", 2.00m));
            cart.AddItem(new RetailItem("carrot", 3.00m));

            cart.CompleteSale();

            testHelper.Verify_CustomerAccount_AddCharge(callExpected: true);
        }

        [TestMethod]
        public void CompleteSale_WhenCartEmpty()
        {
            var testHelper = ShoppingCartTestHelper.Create();

            ShoppingCart cart = testHelper.CreateShoppingCart();

            Assert.ThrowsException<CartException>(() =>
            {
                cart.CompleteSale();
            });
            testHelper.Verify_CustomerAccount_AddCharge(callExpected: false);
        }


        [TestMethod]
        public void AddItem_WhenCheckForSnap()
        {
            var testHelper = ShoppingCartTestHelper.Create();

            ShoppingCart cart = testHelper.CreateShoppingCart();

            testHelper.Setup_TaxCalculator_QualifiesForSnap();

            cart.AddItem(new RetailItem("apple", 1.00m, categoryName: "Fruit"));
            cart.AddItem(new RetailItem("diapars", 2.00m, categoryName: "BabySupplies"));
            cart.AddItem(new RetailItem("M&Ms", 3.00m, categoryName: "Candy"));

            testHelper.Verify_TaxCalculator_QualifiesForSnap("diapars");
        }


        [TestMethod]
        public void AddItem_WhenProblemWithSnapCheck()
        {
            var testHelper = ShoppingCartTestHelper.Create();

            ShoppingCart cart = testHelper.CreateShoppingCart();

            testHelper.Setup_TaxCalculator_QualifiesForSnap();

            cart.AddItem(new RetailItem("apple", 1.00m, categoryName: "Fruit"));
            cart.AddItem(new RetailItem("diapars", 2.00m, categoryName: "BabySupplies"));

            Assert.ThrowsException<ComplianceException>(() =>
            {
                cart.AddItem(new RetailItem("designer baby jeans", 150.00m, categoryName: "BabySupplies"));
            });
        }
    }
}
