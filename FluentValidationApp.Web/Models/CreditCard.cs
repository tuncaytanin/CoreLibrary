using System;

namespace FluentValidationApp.Web.Models
{
    public class CreditCard
    {
        public string Number { get; set; }
        public DateTime ValidatDate { get; set; }
    }
}
