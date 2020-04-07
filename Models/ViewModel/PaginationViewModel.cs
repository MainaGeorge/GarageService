using System.Collections.Generic;

namespace SparkAuto.Models.ViewModel
{
    public class PaginationViewModel
    {
        public IList<ApplicationUser> ListOfUsers { get; set; }
        public PaginationDetails PaginationDetails { get; set; }

    }
}
