using Denali.Web.Models;

namespace Denali.Business.ArsScientia
{
    public interface IDiscountRule
    {
        decimal CalculateCustomerDiscount(Customer customer);
    }
}
