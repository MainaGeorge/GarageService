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
        public UserModel ModelToBeEdited { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [TempData]
        public string Message { get; set; }

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

            ModelToBeEdited = new UserModel
            {
                Id = ApplicationUser.Id,
                Email = ApplicationUser.Email,
                City = ApplicationUser.City,
                PhoneNumber = ApplicationUser.PhoneNumber,
                PostalAddress = ApplicationUser.PostalAddress,
                Name = ApplicationUser.Name,
                Address = ApplicationUser.Address

            };
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var dbUser = await _db.ApplicationUser.FirstOrDefaultAsync(user => user.Id == ModelToBeEdited.Id);

            if (dbUser == null)
            {
                return NotFound();
            }
            else
            {
                dbUser.Name = ModelToBeEdited.Name;
                dbUser.PhoneNumber = ModelToBeEdited.PhoneNumber;
                dbUser.PostalAddress = ModelToBeEdited.PostalAddress;
                dbUser.Address = ModelToBeEdited.Address;
                dbUser.City = ModelToBeEdited.City;

                await _db.SaveChangesAsync();

                Message = "User information successfully updated.";

                return RedirectToPage("Index");
            }


        }

        public class UserModel
        {
            [Required]
            public string Name { get; set; }
            public string Id { get; set; }

            [Required]
            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Postal Address")]
            public string PostalAddress { get; set; }

            public string Address { get; set; }

            public string City { get; set; }

            public string Email { get; set; }
        }
    }
}