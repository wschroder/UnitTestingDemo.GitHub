using ZooManager.Entities;
using ZooManager.Factories;

namespace UnitTestingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            RetailStore giftShop = RetailStoreFactory.CreateGiftShop();

            RetailItem item = giftShop.GetItem("Merchandise", "T-Shirt");
            
        }
    }
}
