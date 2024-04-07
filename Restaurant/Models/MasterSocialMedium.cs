using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class MasterSocialMedium: BaseEntity
    {
        [Required]
        public int MasterSocialMediumId { get; set; }

        [Required]
        [Display(Name = "Social Image")]
        public string MasterSocialMediumImageUrl { get; set; } = null!;

        [Required]
        [Display(Name = "Social Url")]
        public string MasterSocialMediumUrl { get; set; } = null!;
    }
}
