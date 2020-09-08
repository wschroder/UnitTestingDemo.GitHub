using System.Collections.Generic;
using ZooManager.Providers;

namespace ZooManager.Entities
{
    public class RetailCategory : BaseEntity
    {
        public RetailCategory ParentCategory { get; }

        public List<RetailCategory> SubCategories { get; } = new List<RetailCategory>();

        public RetailCategory(string name) : base(name)
        {
        }
    }
}
