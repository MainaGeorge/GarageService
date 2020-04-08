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
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public ServiceType ServiceType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? serviceId)
        {
            if (serviceId == null)
            {
                return NotFound();
            }

            ServiceType = await _db.ServiceType.FirstOrDefaultAsync(s => s.Id == serviceId);

            if (ServiceType == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            ServiceType = await _db.ServiceType.FindAsync(ServiceType.Id);

            if (ServiceType == null) return RedirectToPage("./Index");

            _db.ServiceType.Remove(ServiceType);
            await _db.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
