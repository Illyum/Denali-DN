using Denali.Web.Models;

namespace Denali.Business.ArsScientia
{
    public class EmployeeRule : IDiscountRule
    {
        public decimal CalculateCustomerDiscount(Customer customer)
        {
            var discount = default(decimal);

            if (customer.IsEmployee)
            {
                discount = 0.1m;
            }

            return discount;
        }
    }
}
