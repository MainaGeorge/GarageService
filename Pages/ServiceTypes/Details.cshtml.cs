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

namespace SparkAuto.Pages.ServiceTypes
{
    [Authorize(Roles = StaticDetails.AdminEndUser)]
    public class DetailsModel : PageModel
    {
        private readonly SparkAuto.Data.ApplicationDbContext _db;

        public DetailsModel(SparkAuto.Data.ApplicationDbContext db)
        {
            _db = db;
        }

        public ServiceType ServiceType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? serviceId)
        {
            if (serviceId == null)
            {
                return NotFound();
            }

            ServiceType = await _db.ServiceType.FirstOrDefaultAsync(m => m.Id == serviceId);

            if (ServiceType == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
