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
            RetailStore giftShop = RetailStoreFactory.CreateGiftShop();
        }
    }
}
