using System;

namespace Denali.Web.Models
{
    public class Customer
    {
        public DateTime Birthday { get; set; }
        public DateTime? FirstPurchaseDate { get; set; }
        public bool IsEmployee { get; set; }
    }
}
