using Denali.Business;
using Denali.Web.Models;

using Microsoft.AspNetCore.Mvc;

namespace Denali.Web.Controllers
{
    public class PurchaseController : Controller
    {
        readonly IDiscountCalculator _discountCalculator;

        public PurchaseController(IDiscountCalculator discountCalculator)
        {
            _discountCalculator = discountCalculator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Discount(Customer customer)
        {
            ViewBag.DiscountPercentage = _discountCalculator.CalculateDiscountPercentage(customer);

            return View(customer);
        }
    }
}