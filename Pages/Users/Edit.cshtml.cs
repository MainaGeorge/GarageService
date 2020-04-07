using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SparkAuto.Data;
using SparkAuto.Models;

namespace SparkAuto.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public ApplicationUser User { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGet(string emailAddress)
        {
            if (string.IsNullOrWhiteSpace(emailAddress))
            {
                return NotFound();
            }

            User = await _db.ApplicationUser.FirstOrDefaultAsync(u => u.Email == emailAddress);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var dbUser = await _db.ApplicationUser.FirstOrDefaultAsync(user => user.Email == User.Email);

            if (dbUser == null)
            {
                return NotFound();
            }

            dbUser.Name = User.Name;
            dbUser.PhoneNumber = User.PhoneNumber;
            dbUser.PostalAddress = User.PostalAddress;
            dbUser.Address = User.Address;
            dbUser.City = User.City;

            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}