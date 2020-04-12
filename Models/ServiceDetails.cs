using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SparkAuto.Models
{
    public class ServiceDetails
    {
        public int Id { get; set; }
        public int ServiceHeaderId { get; set; }
        public double ServicePrice { get; set; }
        public string ServiceName { get; set; }
        public int ServiceTypeId { get; set; }

        [ForeignKey("ServiceHeaderId")]
        public virtual ServiceHeader ServiceHeader { get; set; }

        [Display(Name = "Service")]
        [ForeignKey("ServiceTypeId")]
        public virtual ServiceType ServiceType { get; set; }
    }
}
