using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SparkAuto.Data;
using SparkAuto.Models;

namespace SparkAuto.ViewComponents
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;

        public ShoppingCartViewComponent(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var userId = claim.Value;

            var unpaidServices = new List<ServiceHeader>();
            var cars = await _db.Car.Where(c => c.UserId == userId).Select(c => c.Id).ToListAsync();

            foreach (var car in cars)
            {
                var serviceHeaders = await _db.ServiceHeader.Where(c => c.CarId == car && !c.IsPaid).ToListAsync();
                unpaidServices.AddRange(serviceHeaders);
            }

            return View(unpaidServices.Count);
        }
    }
}
