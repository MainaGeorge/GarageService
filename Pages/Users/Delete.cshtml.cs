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

        [BindProperty]
        public ApplicationUser User { get; set; }

        public async Task<IActionResult> OnGet(string emailAddress)
        {
            if (string.IsNullOrWhiteSpace(emailAddress))
            {
                return NotFound();
            }

            User = await _db.ApplicationUser.FirstOrDefaultAsync(user => user.Email == emailAddress);

            if (User == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var userDb = await _db.ApplicationUser.FirstOrDefaultAsync(u => u.Email == User.Email);

            if (userDb == null)
            {
                return NotFound();
            }

            _db.ApplicationUser.Remove(userDb);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}