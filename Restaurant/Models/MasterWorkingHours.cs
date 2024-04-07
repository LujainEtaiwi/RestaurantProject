using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class MasterWorkingHours: BaseEntity
    {
        [Required]
        public int MasterWorkingHoursId { get; set; }

        [Required]
        [Display(Name = "Working Name")]
        public string? MasterWorkingHoursIdName { get; set; }

        [Required]
        [Display(Name = "Working Time")]
        public string? MasterWorkingHoursIdTimeFormTo { get; set; }
    }
}
