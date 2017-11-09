using Denali.Web.Models;

namespace Denali.Business.ArsScientia
{
    public class FirstPurchaseRule : IDiscountRule
    {
        public decimal CalculateCustomerDiscount(Customer customer)
        {
            var discount = default(decimal);

            if (!customer.FirstPurchaseDate.HasValue)
            {
                discount = 0.15m;
            }

            return discount;
        }
    }
}
