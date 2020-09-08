using System.Collections.Generic;

namespace ZooManager.Entities
{
    public class CreditAccount : BaseEntity, ICreditAccount
    {
        private readonly List<decimal> _chargeList = new List<decimal>();

        public CreditAccount(string name): base(name)
        {
        }

        public void AddCharge(decimal chargeAmt)
        {
            _chargeList.Add(chargeAmt);
        }
    }
}
