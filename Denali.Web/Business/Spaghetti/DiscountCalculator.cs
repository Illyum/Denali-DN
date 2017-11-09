using Denali.Web.Models;

using System;

namespace Denali.Business.Spaghetti
{
    public class DiscountCalculator : IDiscountCalculator
    {
        public decimal CalculateDiscountPercentage(Customer customer)
        {
            var discount = default(decimal);

            if (customer.Birthday < DateTime.Now.AddYears(-65))
            {
                // Senior discount 5%
                discount = 0.05m;
            }

            if (customer.FirstPurchaseDate.HasValue)
            {
                if (customer.FirstPurchaseDate.Value < DateTime.Now.AddYears(-1))
                {
                    // After 1 year, loyal customers get 10%
                    discount = Math.Max(discount, 0.10m);
                    if (customer.FirstPurchaseDate.Value < DateTime.Now.AddYears(-5))
                    {
                        // After 5 years, 12%
                        discount = Math.Max(discount, 0.12m);
                        if (customer.FirstPurchaseDate.Value < DateTime.Now.AddYears(-10))
                        {
                            // After 10 years, 20%
                            discount = Math.Max(discount, 0.20m);
                        }
                    }
                }

                if (customer.Birthday.Month == DateTime.Today.Month &&
                    customer.Birthday.Day == DateTime.Today.Day)
                {
                    // Happy birthday!
                    discount += 0.10m;
                }
            }
            else
            {
                // First time purchase discount of 15%
                discount = Math.Max(discount, 0.15m);
            }

            if (customer.Birthday.Month == DateTime.Today.Month &&
                customer.Birthday.Day == DateTime.Today.Day)
            {
                // Happy birthday!
                discount = Math.Max(discount, 0.10m);
            }

            if (customer.IsEmployee)
            {
                // Employees get 10%
                discount = Math.Max(discount, 0.10m);
            }

            return discount;
        }
    }
}
