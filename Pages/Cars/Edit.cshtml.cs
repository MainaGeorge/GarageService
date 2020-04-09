using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SparkAuto.Data;
using SparkAuto.Models;

namespace SparkAuto.Pages.Cars
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(int? carId)
        {
            if (carId == null)
            {
                return NotFound();
            }

            Car = await _db.Car.FirstOrDefaultAsync(car => car.Id == carId);

            if (Car == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var carDb = await _db.Car.FirstOrDefaultAsync(c => c.Id == Car.Id);

            if (carDb == null)
            {
                return NotFound("There is ");
            }

            carDb.RegistrationNumber = Car.RegistrationNumber;
            carDb.Make = Car.Make;
            carDb.Colour = Car.Colour;
            carDb.Model = Car.Model;
            carDb.Miles = Car.Miles;
            carDb.Year = Car.Year;
            carDb.Style = Car.Style;

            await _db.SaveChangesAsync();

            return RedirectToPage("Index", new { userId = Car.UserId });
        }
    }
}
