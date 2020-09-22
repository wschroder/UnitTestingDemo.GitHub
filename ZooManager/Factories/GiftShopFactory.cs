using ZooManager.Entities;

namespace ZooManager.Factories
{
    public static class RetailStoreFactory
    {
        public static RetailStore CreateGiftShop()
        {
            var store = new RetailStore("Gift Shop");
            PopulateDepartments(store);
            return store;
        }
         
        private static void PopulateDepartments(RetailStore store)
        {
            var dept = new RetailDepartment("Snacks");
            dept.AddItem("Ice cream", 1.25m);
            dept.AddItem("Soft drink", 0.50m);
            dept.AddItem("Water bottle", 0.95m);
            dept.AddItem("BadPriceCandy", -0.05m);            
            store.Departments.Add(dept);

            dept = new RetailDepartment("Merchandise");
            dept.AddItem("T-Shirt", 9.95m);
            dept.AddItem("Magazine", 1.50m);
            store.Departments.Add(dept);
        }
    }
}
