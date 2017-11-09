using Denali.Web.Models;

using System;

namespace Denali.Business.ArsScientia
{
    public class BirthdayDiscountRule : IDiscountRule
    {
        public decimal CalculateCustomerDiscount(Customer customer)
        {
            var discount = default(decimal);

            if (customer.Birthday.Month == DateTime.Today.Month &&
                customer.Birthday.Day == DateTime.Today.Day)
            {
                discount = 0.10m;
            }

            return discount;
        }
    }
}
