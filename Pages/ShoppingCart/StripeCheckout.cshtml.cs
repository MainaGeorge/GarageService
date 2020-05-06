using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stripe;

namespace SparkAuto.Pages.ShoppingCart
{
    public class StripeCheckoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();

        }



        public IActionResult OnPost(string stripeEmail, string stripeToken)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();



            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken

            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 500,
                Description = "Sample Charge",
                Currency = "usd",
                Customer = customer.Id
            });


            if (charge.Status == "succeeded")
            {
                return RedirectToPage("Index");
            }

            return Page();
        }
    }


}