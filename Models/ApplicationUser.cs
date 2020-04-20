using Microsoft.AspNetCore.Identity;

namespace SparkAuto.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostalAddress { get; set; }
        public string City { get; set; }
    }
}
