using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SparkAuto.Data;
using SparkAuto.Models.ViewModel;

namespace SparkAuto.Pages.Cars
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [TempData]
        public string Message { get; set; }

        public CarAndOwnerViewModel CarAndOwnerViewModel { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGet(string userId = null)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                userId = claim.Value;
            }

            CarAndOwnerViewModel = new CarAndOwnerViewModel
            {
                Cars = await _db.Car.Where(c => c.UserId == userId).ToListAsync(),
                Owner = await _db.ApplicationUser.FirstOrDefaultAsync(u => u.Id == userId)

            };


            return Page();
        }
    }
}