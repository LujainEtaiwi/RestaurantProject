using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class SystemSetting: BaseEntity
    {
        [Required]
        public int SystemSettingId { get; set; }

        [Required]
        [Display(Name = "NLogo")]
        public string? SystemSettingLogoImageUrl { get; set; }

        [Required]
        [Display(Name = "DLogo")]
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

        [Display(Name = "Welcome Url")]
        public string? SystemSettingWelcomeNoteUrl { get; set; }

        [Display(Name = "Welcome Image")]
        public string? SystemSettingWelcomeNoteImageUrl { get; set; }

        [Display(Name = "Map Location")]
        public string? SystemSettingMapLocation { get; set; }
    }
}
