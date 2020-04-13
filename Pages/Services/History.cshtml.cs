using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SparkAuto.Data;
using SparkAuto.Models;

namespace SparkAuto.Pages.Services
{
    [Authorize]
    public class HistoryModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public HistoryModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public string UserId { get; set; }

        [BindProperty]
        public List<ServiceHeader> ServiceHeaderList { get; set; }

        public ServiceHeader ServiceHeader { get; set; }

        public async Task OnGet(int carId)
        {
            ServiceHeaderList = await _db.ServiceHeader
                .Include(c => c.Car)
                .Include(c => c.Car.ApplicationUser)
                .Where(c => c.CarId == carId)
                .ToListAsync();

            UserId = _db.Car.Where(car => car.Id == carId).ToList().FirstOrDefault()?.UserId;

            ServiceHeader = ServiceHeaderList.FirstOrDefault();
        }
    }
}