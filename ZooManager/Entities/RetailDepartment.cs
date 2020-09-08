using System.Collections.Generic;

namespace ZooManager.Entities
{
    public class RetailDepartment : BaseEntity
    {
        public List<RetailItem> Items { get; } = new List<RetailItem>();

        public RetailDepartment(string name) : base(name)
        {
        }

        internal void AddItem(string name, decimal unitPrice)
        {
            var newItem = new RetailItem(name, unitPrice);
            Items.Add(newItem);            
        }
    }
}
