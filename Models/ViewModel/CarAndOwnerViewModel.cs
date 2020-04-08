using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparkAuto.Models.ViewModel
{
    public class CarAndOwnerViewModel
    {
        public IEnumerable<Car> Cars { get; set; }
        public ApplicationUser Owner { get; set; }
    }
}
