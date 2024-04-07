using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class MasterOffer: BaseEntity
    {
        [Required]
        public int MasterOfferId { get; set; }

        [Required]
        [Display(Name = "Offer Title")]
        public string? MasterOfferTitle { get; set; }

        [Required]
        [Display(Name = "Offer Breef")]
        public string? MasterOfferBreef { get; set; }

        [Required]
        [Display(Name = "Offer Descreption")]
        public string? MasterOfferDesc { get; set; }

        [Required]
        [Display(Name = "Offer Image")]
        public string? MasterOfferImageUrl { get; set; }
    }
}
