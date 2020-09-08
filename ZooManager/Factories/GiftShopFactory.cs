using ZooManager.Entities;

namespace ZooManager.Factories
{
    public class GiftShopFactory : RetailFactory
    {
        public override string Name => "Gift Shop";

        public override void PopulateDepartments(RetailStore store)
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
