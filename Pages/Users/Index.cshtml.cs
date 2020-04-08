using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SparkAuto.Data;
using SparkAuto.Models;
using SparkAuto.Models.ViewModel;
using SparkAuto.StaticDetailsUtilities;

namespace SparkAuto.Pages.Users
{
    [Authorize(Roles = StaticDetails.AdminEndUser)]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public PaginationViewModel ViewModel { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGet(int pageNumber = 1, string searchPhone = null, string searchName = null, string searchEmail = null)
        {
            ViewModel = new PaginationViewModel
            {
                ListOfUsers = await _db.ApplicationUser.ToListAsync()
            };

            var currentUrl = new StringBuilder();
            currentUrl.Append("/Users/Index?pageNumber=:");

            if (searchEmail != null)
            {
                currentUrl.Append($"&searchEmail={searchEmail}");
                ViewModel.ListOfUsers = ViewModel.ListOfUsers
                    .Where(user => user.Email.ToLower().Contains(searchEmail.ToLower()))
                    .ToList();
            }
            else
            {
                if (searchName != null)
                {
                    currentUrl.Append($"&searchName={searchName}");
                    ViewModel.ListOfUsers = ViewModel.ListOfUsers
                        .Where(user => user.Name.ToLower().Contains(searchName.ToLower()))
                        .ToList();
                }
                else
                {
                    if (searchPhone != null)
                    {
                        currentUrl.Append($"&searchPhone={searchPhone}");
                        ViewModel.ListOfUsers = ViewModel.ListOfUsers
                            .Where(user => user.PhoneNumber.ToLower().Contains(searchPhone))
                            .ToList();
                    }
                }
            }


            ViewModel.PaginationDetails = new PaginationDetails
            {
                CurrentPage = pageNumber,
                TotalItems = ViewModel.ListOfUsers.Count,
                ItemsPerPage = StaticDetails.UsersPerPage,
                Url = currentUrl.ToString()
            };


            ViewModel.ListOfUsers = ViewModel.ListOfUsers.OrderBy(u => u.Email)
                .Skip((pageNumber - 1) * StaticDetails.UsersPerPage)
                .Take(StaticDetails.UsersPerPage)
                .ToList();

            return Page();
        }
    }
}