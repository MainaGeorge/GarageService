using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SparkAuto.Data;
using SparkAuto.Models;
using SparkAuto.Models.ViewModel;
using SparkAuto.StaticDetailsUtilities;

namespace SparkAuto.Pages.Services
{
    [Authorize(Roles = StaticDetails.AdminEndUser)]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public CarServiceModelView CarServiceModelView { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGet(int carId)
        {
            CarServiceModelView = new CarServiceModelView
            {
                Car = await _db.Car.Include(c => c.ApplicationUser).FirstOrDefaultAsync(c => c.Id == carId),
                ServiceHeader = new ServiceHeader()
            };

            var serviceTypesInCart = _db.ServiceShoppingCart
                .Include(c => c.ServiceType)
                .Where(c => c.CarId == carId)
                .Select(c => c.ServiceType.Name)
                .ToList();

            var allServiceTypesNotInCart = from s in _db.ServiceType
                                           where !(serviceTypesInCart.Contains(s.Name))
                                           select s;

            CarServiceModelView.ServiceTypesList = allServiceTypesNotInCart.ToList();

            CarServiceModelView.ServiceShoppingCartList = _db.ServiceShoppingCart
                .Include(c => c.ServiceType)
                .Where(c => c.CarId == carId)
                .ToList();

            CarServiceModelView.ServiceHeader.TotalPrice = CarServiceModelView.ServiceShoppingCartList.Sum(c => c.ServiceType.Price);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                CarServiceModelView.ServiceHeader.DateAdded = DateTime.Now;

                CarServiceModelView.ServiceShoppingCartList =
                    _db.ServiceShoppingCart.Include(c => c.ServiceType)
                        .Where(c => c.CarId == CarServiceModelView.Car.Id)
                        .ToList();

                CarServiceModelView.ServiceHeader.TotalPrice = CarServiceModelView.ServiceShoppingCartList
                    .Sum(s => s.ServiceType.Price);

                CarServiceModelView.ServiceHeader.CarId = CarServiceModelView.Car.Id;

                _db.ServiceHeader.Add(CarServiceModelView.ServiceHeader);

                await _db.SaveChangesAsync();

                foreach (var service in CarServiceModelView.ServiceShoppingCartList)
                {
                    var serviceDetails = new ServiceDetails
                    {
                        ServiceHeaderId = CarServiceModelView.ServiceHeader.Id,
                        ServicePrice = service.ServiceType.Price,
                        ServiceName = service.ServiceType.Name,
                        ServiceTypeId = service.ServiceTypeId
                    };
                    _db.ServiceDetails.Add(serviceDetails);

                }

                _db.ServiceShoppingCart.RemoveRange(CarServiceModelView.ServiceShoppingCartList);

                await _db.SaveChangesAsync();

                return RedirectToPage("../Cars/Index", new { userId = CarServiceModelView.Car.UserId });
            }

            return Page();


        }

        public async Task<IActionResult> OnPostAddToCart()
        {
            var serviceToBeAdded = new ServiceShoppingCart
            {
                CarId = CarServiceModelView.Car.Id,
                ServiceTypeId = CarServiceModelView.ServiceDetails.ServiceTypeId
            };

            await _db.ServiceShoppingCart.AddAsync(serviceToBeAdded);

            await _db.SaveChangesAsync();

            return RedirectToPage("Create", new { carId = CarServiceModelView.Car.Id });
        }

        public async Task<IActionResult> OnPostRemoveServiceFromCart(int serviceTypeId)
        {
            var serviceToBeDeleted = await _db.ServiceShoppingCart
                .FirstOrDefaultAsync(s => s.CarId == CarServiceModelView.Car.Id && s.ServiceTypeId == serviceTypeId);

            _db.ServiceShoppingCart.Remove(serviceToBeDeleted);

            await _db.SaveChangesAsync();

            return RedirectToPage("Create", new { carId = CarServiceModelView.Car.Id });
        }
    }
}