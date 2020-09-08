using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ZooManager.Entities;
using ZooManager.Exceptions;
using ZooManager.Factories;

namespace ZooManager.Tests.Entities
{
    [TestClass]
    public class RetailStoreTests
    {

        [TestMethod]
        public void GetItem_WhenItemFound()
        {
            RetailStore store = RetailFactory.CreateGiftShop();

            RetailItem item = store.GetItem(deptName: "Merchandise", itemName: "T-Shirt");

            Assert.IsNotNull(item);

            Assert.AreEqual("T-Shirt", item.Name);
        }

        [TestMethod]
        public void GetItem_WhenInvalidDepartmentName()
        {
            RetailStore store = RetailFactory.CreateGiftShop();

            Assert.ThrowsException<NotFoundException>(() =>
            {
                store.GetItem(deptName: "___", itemName: "T-Shirt");
            });
        }

        [TestMethod]
        public void GetItem_WhenInvalidItemName()
        {
            RetailStore store = RetailFactory.CreateGiftShop();

            Assert.ThrowsException<NotFoundException>(() =>
            {
                store.GetItem(deptName: "Merchandise", itemName: "____");
            });
        }

        [TestMethod]
        public void GetItem_WhenMissingDepartmentName()
        {
            RetailStore store = RetailFactory.CreateGiftShop();

            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                store.GetItem(deptName: null, itemName: "T-Shirt");
            });
        }

        [TestMethod]
        public void GetItem_WhenMissingItemName()
        {
            RetailStore store = RetailFactory.CreateGiftShop();

            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                store.GetItem(deptName: "Merchandise", itemName: null);
            });
        }

        [TestMethod]
        public void GetItem_WhenInvalidPrice()
        {
            RetailStore store = RetailFactory.CreateGiftShop();

            Assert.ThrowsException<InvalidPriceException>(() =>
            {
                store.GetItem(deptName: "Snacks", itemName: "BadPriceCandy");
            });
        }
    }
}
