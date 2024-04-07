using Restaurant.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class MasterOfferModels : BaseEntity
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

        
        public string? MasterOfferImageUrl { get; set; }

        [Display(Name = "Offer Image")]
        public IFormFile File { get; set; }
    }
}
