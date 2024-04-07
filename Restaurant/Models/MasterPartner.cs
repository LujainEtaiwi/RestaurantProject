using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class MasterPartner: BaseEntity
    {
        [Required]
        public int MasterPartnerId { get; set; }

        [Required]
        [Display(Name = "Partner Name")]
        public string? MasterPartnerName { get; set; }

        [Required]
        [Display(Name = "Partner Image")]
        public string? MasterPartnerLogoImageUrl { get; set; }

        [Required]
        [Display(Name = "Partner WebsiteUrl")]
        public string? MasterPartnerWebsiteUrl { get; set; }
    }
}
