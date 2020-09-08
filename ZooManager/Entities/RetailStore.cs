using System;
using System.Collections.Generic;
using System.Linq;
using ZooManager.Exceptions;
using ZooManager.Helpers;

namespace ZooManager.Entities
{
    public class RetailStore :BaseEntity
    {
        public List<RetailDepartment> Departments { get; } = new List<RetailDepartment>();

        public RetailStore(string name): base(name)
        {
        }

        public RetailItem GetItem(string deptName, string itemName)
        {
            Verify.NotNullOrEmpty(deptName, nameof(deptName));
            Verify.NotNullOrEmpty(itemName, nameof(itemName));

            RetailDepartment dept = Departments.FirstOrDefault(o => o.Name.Equals(deptName, StringComparison.OrdinalIgnoreCase));
            VerifyFound("Department", dept);

            RetailItem item = dept.Items.FirstOrDefault(o => o.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
            VerifyFound("Item", item);

            if (item.UnitPrice < 0)
            {
                throw new InvalidPriceException(item);
            }

            return item;
        }

        private void VerifyFound(string title, object item)
        {
            if (item== null)
            {
                throw new NotFoundException($"{title} not found: {item}");
            }

        }
    }
}
