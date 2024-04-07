using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class MasterServices : BaseEntity
    {
        [Required]
        public int MasterServicesId { get; set; }

        [Required]
        [Display(Name = "Service Title")]
        public string? MasterServicesTitle { get; set; }

        [Required]
        [Display(Name = "Service Descreption")]
        public string? MasterServicesDesc { get; set; }


        [Display(Name = "Service Icon")]
        public string? MasterServicesImage { get; set; }
    }
}
