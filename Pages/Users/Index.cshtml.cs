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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public IList<ApplicationUser> Users { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGet()
        {
            Users = await _db.ApplicationUser.ToListAsync();
            return Page();
        }
    }
}