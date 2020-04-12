using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparkAuto.Models.ViewModel
{
    public class CarServiceModelView
    {
        public Car Car { get; set; }
        public ServiceHeader ServiceHeader { get; set; }

        public ServiceDetails ServiceDetails { get; set; }

        public List<ServiceType> ServiceTypesList { get; set; }

        public List<ServiceShoppingCart> ServiceShoppingCartList { get; set; }
    }
}
