using Denali.Web.Models;

using System;

namespace Denali.Business.ArsScientia
{
    public class LoyalCustomerRule : IDiscountRule
    {
        private readonly decimal _discount;
        private readonly int _yearsAsCustomer;

        public LoyalCustomerRule(int yearsAsCustomer, decimal discount)
        {
            _yearsAsCustomer = yearsAsCustomer;
            _discount = discount;
        }

        public decimal CalculateCustomerDiscount(Customer customer)
        {
            var discount = default(decimal);

            if (customer.FirstPurchaseDate.HasValue)
            {
                if (customer.FirstPurchaseDate.Value.AddYears(_yearsAsCustomer) <= DateTime.Today)
                {
                    var birthdayRule = new BirthdayDiscountRule();

                    discount = _discount + birthdayRule.CalculateCustomerDiscount(customer);
                }
            }

            return discount;
        }
    }
}
