using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SparkAuto.Data;
using SparkAuto.Models;

namespace SparkAuto.Pages.Cars
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public Car Car { get; set; }
        public async Task<IActionResult> OnGet(int? carId)
        {
            if (!carId.HasValue)
            {
                return NotFound("There is no such car");
            }

            Car = await _db.Car.FirstOrDefaultAsync(c => c.Id == carId);

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var dbCar = await _db.Car.FirstOrDefaultAsync(c => c.Id == Car.Id);

            if (dbCar == null)
            {
                return NotFound("NO such car found in the database");
            }

            _db.Car.Remove(dbCar);

            await _db.SaveChangesAsync();

            Message = "Car deleted successfully";

            return RedirectToPage("Index", new
            {
                userId = Car.UserId
            });
        }
    }
}