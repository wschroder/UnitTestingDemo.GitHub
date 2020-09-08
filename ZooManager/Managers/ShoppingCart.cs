using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using ZooManager.Entities;
using ZooManager.Exceptions;
using ZooManager.Helpers;
using ZooManager.Providers;

namespace ZooManager.Managers
{
    public class ShoppingCart
    {
        private readonly ITaxCalculator _taxCalculator;
        private readonly List<RetailItem> _cartItems = new List<RetailItem>();
        private readonly int _maxItemCnt;
        private readonly ICreditAccount _customerCreditAccount;

        public ShoppingCart(ITaxCalculator taxCalculator, ICreditAccount customerCreditAccount, IConfiguration configuration)
        {
            _taxCalculator = Verify.NotNull(taxCalculator, nameof(taxCalculator));
            _customerCreditAccount = Verify.NotNull(customerCreditAccount, nameof(customerCreditAccount));

            Verify.NotNull(configuration, nameof(configuration));
            string maxItemCntSetting = configuration["Cart:MaxItems"];
            if (int.TryParse(maxItemCntSetting, out _maxItemCnt)==false)
            {
                throw new ArgumentException("Invalid setting for Cart.MaxItems");
            }
        }

        public void AddItem(RetailItem item)
        {
            if (_cartItems.Count >= _maxItemCnt)
            {
                throw new CartException($"Unable to add [{item.Name}] as cart is full");
            }

            if (item.Category?.Name == "BabySupplies")
            {
                try
                {
                    item.IsValidForSnap = _taxCalculator.QualifiesForSnap(item);
                }
                catch (Exception ex)
                {
                    throw new ComplianceException("Failure calling tax calculator", ex);
                }
            }
            _cartItems.Add(item);
        }

        public decimal CalculateTotal()
        {
            Decimal subTotalAmt = 0.00m;

            foreach (RetailItem item in _cartItems)
            {
                subTotalAmt += item.UnitPrice;
            }

            decimal taxAmt = _taxCalculator.GetTaxAmt(subTotalAmt);

            return subTotalAmt + taxAmt;
        }

        public void CompleteSale()
        {
            if (_cartItems.Count == 0)
            {
                throw new CartException($"Attempt to complete sale when cart is empty.");
            }

            decimal cartTotalAmt = CalculateTotal();

            _customerCreditAccount.AddCharge(cartTotalAmt);
        }
    }
}
