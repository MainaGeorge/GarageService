using System.ComponentModel.DataAnnotations;
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
    public class EditModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGet(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                return NotFound();
            }

            ApplicationUser = await _db.ApplicationUser.FirstOrDefaultAsync(u => u.Id == userId);

            if (ApplicationUser == null)
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

            var dbUser = await _db.ApplicationUser.FirstOrDefaultAsync(user => user.Id == ApplicationUser.Id);

            if (dbUser == null)
            {
                return NotFound();
            }
            else
            {
                dbUser.Name = ApplicationUser.Name;
                dbUser.PhoneNumber = ApplicationUser.PhoneNumber;
                dbUser.PostalAddress = ApplicationUser.PostalAddress;
                dbUser.Address = ApplicationUser.Address;
                dbUser.City = ApplicationUser.City;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }


        }
    }
}