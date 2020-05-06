using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SparkAuto.Data;
using SparkAuto.Models;
using Stripe;

namespace SparkAuto.Pages.ShoppingCart
{
    public class StripeCheckoutModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public long? AmountToBePaid { get; set; }

        public string TransactionId { get; set; }

        public string Description { get; set; }

        public List<ServiceHeader> UnpaidServices { get; set; } = new List<ServiceHeader>();

        public StripeCheckoutModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult OnGet()
        {

            return Page();

        }



        public async Task<IActionResult> OnPost(string stripeEmail, string stripeToken)
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var userId = claim.Value;

            var cars = await _db.Car.Where(c => c.UserId == userId).Select(c => c.Id).ToListAsync();

            foreach (var car in cars)
            {
                var serviceHeaders = await _db.ServiceHeader.Where(c => c.CarId == car && !c.IsPaid)
                    .ToListAsync();
                UnpaidServices.AddRange(serviceHeaders);
            }
            AmountToBePaid = (long?)UnpaidServices.Sum(c => c.TotalPrice);


            Console.WriteLine(AmountToBePaid);
            Console.WriteLine(UnpaidServices.Count);

            var customers = new CustomerService();
            var charges = new ChargeService();


            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken

            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = AmountToBePaid,
                Description = "Payment to SparkAuto garage",
                Currency = "pln",
                Customer = customer.Id
            });


            if (charge.Status == "succeeded")
            {
                //store the transactionid, amount, customerId, transactiondescription, currency in a new table
                TransactionId = charge.BalanceTransactionId;
                Description = charge.Description;


                //change the status of paid in serviceHeader to true;


                return RedirectToPage("../Index");
            }
            else
            {
                return RedirectToPage("Error");
            }

        }
    }


}