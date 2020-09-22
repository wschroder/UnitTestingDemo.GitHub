using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZooManager.Entities;
using ZooManager.Factories;

namespace ZooManager.Tests
{
    [TestClass]
    public class RetailStoreTests
    {
        public void GetItem()
        {
            var sut = RetailStoreFactory.CreateGiftShop();

            RetailItem item = sut.GetItem(deptName: "Snacks", itemName: "Ice Cream");

            Assert.IsNotNull(item);
        }
    }
}
