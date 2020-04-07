using System;

namespace SparkAuto.Models
{
    public class PaginationDetails
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int) Math.Ceiling((decimal) TotalItems / ItemsPerPage);

        public string Url { get; set; } 
    }
}
