using Restaurant.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class MasterSocialMediumModels : BaseEntity
    {
        [Required]
        public int MasterSocialMediumId { get; set; }

        
        public string MasterSocialMediumImageUrl { get; set; } = null!;

        [Required]
        [Display(Name = "Social Url")]
        public string MasterSocialMediumUrl { get; set; } = null!;


        [Display(Name = "Social Image")]
        public IFormFile File { get; set; }
    }
}
