﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SparkAuto.Data;
using SparkAuto.Models;
using Stripe;

namespace SparkAuto.Pages.ShoppingCart
{
    [Authorize]
    public class StripeCheckoutModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        private readonly PaymentDetails _paymentDetails;

        [TempData]
        public string Message { get; set; }

        public List<ServiceHeader> UnpaidServices { get; set; }

        public StripeCheckoutModel(ApplicationDbContext db)
        {
            _db = db;
            _paymentDetails = new PaymentDetails();
            UnpaidServices = new List<ServiceHeader>();
        }
        public IActionResult OnGet()
        {

            return Page();

        }



        public async Task<IActionResult> OnPost(string stripeEmail, string stripeToken)
        {

            UnpaidServices = await GetUnpaidServices();

            _paymentDetails.Amount = (long?)UnpaidServices.Sum(c => c.TotalPrice);

            var charge = await GetCharges(stripeEmail, stripeToken);

            if (charge.Status == "succeeded")
            {
                _paymentDetails.TransactionId = charge.BalanceTransactionId;
                _paymentDetails.Description = charge.Description;
                _paymentDetails.Currency = charge.Currency;


                foreach (var unpaidService in UnpaidServices)
                {
                    var serviceFromDb = await _db.ServiceHeader.FindAsync(unpaidService.Id);
                    serviceFromDb.IsPaid = true;
                }

                await _db.PaymentDetails.AddAsync(_paymentDetails);

                await _db.SaveChangesAsync();

                Message = "Payment Successful";

                return RedirectToPage("../Index");
            }
            else
            {
                Message = "Error, Something went wrong while processing your payment";
                return RedirectToPage("../Index");
            }

        }

        private async Task<List<ServiceHeader>> GetUnpaidServices()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            _paymentDetails.CustomerId = claim.Value;

            var cars = await _db.Car.Where(c => c.UserId == _paymentDetails.CustomerId).Select(c => c.Id).ToListAsync();

            foreach (var car in cars)
            {
                var serviceHeaders = await _db.ServiceHeader.Where(c => c.CarId == car && !c.IsPaid)
                    .ToListAsync();
                UnpaidServices.AddRange(serviceHeaders);
            }

            return UnpaidServices;

        }

        private async Task<Charge> GetCharges(string stripeEmail, string stripeToken)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();


            var customer = await customers.CreateAsync(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken

            });

            var charge = await charges.CreateAsync(new ChargeCreateOptions
            {
                Amount = _paymentDetails.Amount * 100, //stripe takes amounts in cents, multiply by 100 to bring it to the right amount;
                Description = "Payment to SparkAuto garage",
                Currency = "usd",
                Customer = customer.Id
            });

            return charge;
        }
    }


}