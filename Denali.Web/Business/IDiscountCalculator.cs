using Denali.Web.Models;

namespace Denali.Business
{
    public interface IDiscountCalculator
    {
        decimal CalculateDiscountPercentage(Customer customer);
    }
}
