using Denali.Web.Models;

using System;
using System.Collections.Generic;

namespace Denali.Business.ArsScientia
{
    public class DiscountCalculator : IDiscountCalculator
    {
        List<IDiscountRule> _rules = new List<IDiscountRule>();

        public DiscountCalculator()
        {
            _rules.Add(new SeniorRule());
            _rules.Add(new BirthdayDiscountRule());
            _rules.Add(new FirstPurchaseRule());
            _rules.Add(new LoyalCustomerRule(1, 0.10m));
            _rules.Add(new LoyalCustomerRule(5, 0.12m));
            _rules.Add(new LoyalCustomerRule(10, 0.20m));
            _rules.Add(new EmployeeRule());
        }

        public decimal CalculateDiscountPercentage(Customer customer)
        {
            var discount = default(decimal);

            foreach (var rule in _rules)
            {
                discount = Math.Max(rule.CalculateCustomerDiscount(customer), discount);
            }

            return discount;
        }
    }
}
