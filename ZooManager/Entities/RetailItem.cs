namespace ZooManager.Entities
{
    public class RetailItem : BaseEntity
    {
        public string Description { get; }

        public RetailCategory Category { get; }

        public decimal UnitPrice { get; }

        public bool IsValidForSnap { get; set; }

        public RetailItem(string name, decimal unitPrice)
                : this(name, unitPrice, categoryName: null)
        {
        }
        public RetailItem(string name, decimal unitPrice, string categoryName)
                : base(name)
        {
            UnitPrice = unitPrice;

            if (categoryName != null)
            {
                Category = new RetailCategory(categoryName);
            }
        }
    }
}
