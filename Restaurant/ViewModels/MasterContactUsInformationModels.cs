using Restaurant.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class MasterContactUsInformationModels:BaseEntity
    {
        [Required]
        public int MasterContactUsInformationId { get; set; }

        [Required]
        [Display(Name = "Descreption")]
        public string? MasterContactUsInformationIdesc { get; set; }

        [Display(Name = "Image")]
        public string? MasterContactUsInformationImageUrl { get; set; }

        [Required]
        [Display(Name = "Redirect")]
        public string? MasterContactUsInformationRedirect { get; set; }

        [Display(Name = "Image")]
        public IFormFile File { get; set; }
    }
}
