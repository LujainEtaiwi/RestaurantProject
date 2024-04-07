using Restaurant.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class MasterPartnerModels : BaseEntity
    {
        [Required]
        public int MasterPartnerId { get; set; }

        [Required]
        [Display(Name = "Partner Name")]
        public string? MasterPartnerName { get; set; }

        
        public string? MasterPartnerLogoImageUrl { get; set; }

        [Required]
        [Display(Name = "Partner WebsiteUrl")]
        public string? MasterPartnerWebsiteUrl { get; set; }

        [Display(Name = "Partner Image")]
        public IFormFile File { get; set; }
    }
}
