using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SparkAuto.Data;
using SparkAuto.Models;

namespace SparkAuto.Pages.Services
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DetailsModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public ServiceDetails ServiceDetails { get; set; }
        public ServiceHeader ServiceHeader { get; set; }
        public List<ServiceDetails> ServiceDetailsList { get; set; }

        public void OnGet(int serviceHeaderId)
        {
            ServiceHeader = _db.ServiceHeader.Include(c => c.Car)
                .Include(c => c.Car.ApplicationUser)
                .FirstOrDefault(s => s.Id == serviceHeaderId);

            ServiceDetailsList = _db.ServiceDetails.Where(c => c.ServiceHeaderId == serviceHeaderId).ToList();
            ServiceDetails = ServiceDetailsList.FirstOrDefault();
        }
    }
}