using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparkAuto.Models.ViewModel
{
    public class ShoppingCartViewModel
    {
        public List<ServiceHeader> ServiceHeaders { get; set; }
        public Dictionary<int, List<ServiceDetails>> ServiceDetails { get; set; }

        public double TotalPrice { get; set; }
    }
}
