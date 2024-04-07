using Restaurant.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class MasterWorkingHoursModels : BaseEntity
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
