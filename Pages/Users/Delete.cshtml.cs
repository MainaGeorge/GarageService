using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SparkAuto.Data;
using SparkAuto.Models;
using SparkAuto.StaticDetailsUtilities;

namespace SparkAuto.Pages.Users
{
    [Authorize(Roles = StaticDetails.AdminEndUser)]
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
        public ApplicationUser ApplicationUser { get; set; }

        public async Task<IActionResult> OnGet(string emailAddress)
        {
            if (string.IsNullOrWhiteSpace(emailAddress))
            {
                return NotFound();
            }

            ApplicationUser = await _db.ApplicationUser.FirstOrDefaultAsync(user => user.Email == emailAddress);

            if (User == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {


            var userDb = await _db.ApplicationUser.FirstOrDefaultAsync(u => u.Email == ApplicationUser.Email);

            if (userDb == null)
            {
                return NotFound();
            }

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var loggedAdminId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (loggedAdminId == userDb.Id)
            {
                Message = "Error! You can not delete yourself!";

                return RedirectToPage("Index");
            }

            var userCars = _db.Car.Where(car => car.UserId == userDb.Id);

            if (userCars.Any())
            {
                foreach (var car in userCars)
                {
                    _db.Car.Remove(car);
                }

            }

            _db.ApplicationUser.Remove(userDb);

            await _db.SaveChangesAsync();

            Message = "User successfully deleted.";

            return RedirectToPage("Index");
        }
    }
}