using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SparkAuto.Data;
using SparkAuto.Models;
using SparkAuto.Models.ViewModel;

namespace SparkAuto.Pages.ShoppingCart
{
    [Authorize]
    public class ShoppingCartModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public ShoppingCartViewModel ShoppingCartViewModel { get; set; }

        public ShoppingCartModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var userId = claim.Value;

            var unpaidServices = new List<ServiceHeader>();
            var cars = await _db.Car.Where(c => c.UserId == userId).Select(c => c.Id).ToListAsync();

            foreach (var car in cars)
            {
                var serviceHeaders = await _db.ServiceHeader.Where(c => c.CarId == car && !c.IsPaid)
                    .ToListAsync();
                unpaidServices.AddRange(serviceHeaders);
            }

            ShoppingCartViewModel = new ShoppingCartViewModel()
            {
                ServiceHeaders = unpaidServices,
                ServiceDetails = new Dictionary<int, List<ServiceDetails>>()
            };

            foreach (var serviceHeader in ShoppingCartViewModel.ServiceHeaders)
            {
                var details = await _db.ServiceDetails.Where(s => s.ServiceHeaderId == serviceHeader.Id).ToListAsync();
                ShoppingCartViewModel.ServiceDetails[serviceHeader.Id] = details;
            }

            ShoppingCartViewModel.TotalPrice = ShoppingCartViewModel.ServiceHeaders.Sum(c => c.TotalPrice);

            return Page();
        }
    }
}