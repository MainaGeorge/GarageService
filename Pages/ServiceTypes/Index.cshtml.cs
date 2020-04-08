using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SparkAuto.Data;
using SparkAuto.Models;
using SparkAuto.StaticDetailsUtilities;

namespace SparkAuto.Pages.ServiceTypes
{
    [Authorize(Roles = StaticDetails.AdminEndUser)]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IList<ServiceType> Services { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGet()
        {
            Services = await _db.ServiceType.ToListAsync();

            return Page();
        }
    }
}