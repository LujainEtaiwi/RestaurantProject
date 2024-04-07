using Restaurant.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class SystemSettingModels : BaseEntity
    {
        [Required]
        public int SystemSettingId { get; set; }

        
        public string? SystemSettingLogoImageUrl { get; set; }

        
        public string? SystemSettingLogoImageUrl2 { get; set; }

        [Required]
        [Display(Name = "Copyright")]
        public string? SystemSettingCopyright { get; set; }

        [Required]
        [Display(Name = "Welcome Title")]
        public string? SystemSettingWelcomeNoteTitle { get; set; }

        [Required]
        [Display(Name = "Welcome Breef")]
        public string? SystemSettingWelcomeNoteBreef { get; set; }

        [Required]
        [Display(Name = "Welcome Desc")]
        public string? SystemSettingWelcomeNoteDesc { get; set; }

        [Required]
        [Display(Name = "Welcome Url")]
        public string? SystemSettingWelcomeNoteUrl { get; set; }

        
        public string? SystemSettingWelcomeNoteImageUrl { get; set; }

        [Required]
        [Display(Name = "Map Location")]
        public string? SystemSettingMapLocation { get; set; }

        [Display(Name = "NLogo")]
        public IFormFile File { get; set; }

        [Display(Name = "DLogo")]
        public IFormFile File2 { get; set; }

        [Display(Name = "Welcome Image")]
        public IFormFile File3 { get; set; }
    }
}
