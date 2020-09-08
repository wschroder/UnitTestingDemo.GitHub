using ZooManager.Entities;

namespace ZooManager.Factories
{
    public abstract class RetailFactory
    {
        public static RetailStore CreateGiftShop() => new GiftShopFactory().Create();

        public abstract string Name { get; }

        public abstract void PopulateDepartments(RetailStore store);

        public RetailStore Create()
        {
            var store = new RetailStore(Name);
            PopulateDepartments(store);
            return store;
        }
    }
}
