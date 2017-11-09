using Denali.Web.Models;

using System;

namespace Denali.Business.ArsScientia
{
    public class SeniorRule : IDiscountRule
    {
        public decimal CalculateCustomerDiscount(Customer customer)
        {
            var discount = default(decimal);

            if (customer.Birthday < DateTime.Now.AddYears(-65))
            {
                discount = .05m;
            }

            return discount;
        }
    }
}
