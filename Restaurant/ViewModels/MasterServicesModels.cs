using Restaurant.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class MasterServicesModels : BaseEntity
    {
        [Required]
        public int MasterServicesId { get; set; }

        [Required]
        [Display(Name = "Service Title")]
        public string? MasterServicesTitle { get; set; }

        [Required]
        [Display(Name = "Service Descreption")]
        public string? MasterServicesDesc { get; set; }

        
        public string? MasterServicesImage { get; set; }

        [Display(Name = "Service Icon")]
        public IFormFile File { get; set; }
    }
}
