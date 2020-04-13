using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SparkAuto.StaticDetailsUtilities;

namespace SparkAuto.Pages
{
    public class IndexModel : PageModel
    {

        [TempData]
        public string Message { get; set; }


        public IActionResult OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim == null)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            return RedirectToPage(User.IsInRole(StaticDetails.AdminEndUser) ? "/Users/Index" : "/Cars/Index");
        }
    }
}
