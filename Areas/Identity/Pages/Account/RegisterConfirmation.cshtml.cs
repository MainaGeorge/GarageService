using Microsoft.AspNetCore.Authorization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using SparkAuto.Data;
using SparkAuto.EmailServices;
using SparkAuto.Models;

namespace SparkAuto.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterConfirmationModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _sender;
        private readonly ApplicationDbContext _db;

        public RegisterConfirmationModel(UserManager<IdentityUser> userManager, IEmailSender sender, ApplicationDbContext db)
        {
            _userManager = userManager;
            _sender = sender;
            _db = db;
        }

        public string Email { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public string EmailConfirmationUrl { get; set; }

        public async Task<IActionResult> OnGetAsync(string email)
        {
            if (email == null)
            {
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound($"Unable to load user with email '{email}'.");
            }

            Email = email;
            ApplicationUser = await _db.ApplicationUser.FirstOrDefaultAsync(u => u.Email == Email);



            var userId = await _userManager.GetUserIdAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            EmailConfirmationUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { area = "Identity", userId = userId, code = code },
                protocol: Request.Scheme);

            var content = MessageTemplate.ConfirmEmail(ApplicationUser, EmailConfirmationUrl);
            await _sender.SendEmailAsync(new EmailMessage(Email, content, "Confirm Email"));



            return Page();
        }
    }
}
