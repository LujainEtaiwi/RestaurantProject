using Restaurant.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class MasterSliderModels : BaseEntity
    {
        [Required]
        public int MasterSliderId { get; set; }

        [Required]
        [Display(Name = "Slider Title")]
        public string? MasterSliderTitle { get; set; }

        [Required]
        [Display(Name = "Slider Breef")]
        public string? MasterSliderBreef { get; set; }

        [Required]
        [Display(Name = "Slider Descreption")]
        public string? MasterSliderDesc { get; set; }

        [Required]
        [Display(Name = "Slider Image")]
        public string? MasterSliderUrl { get; set; }

        [Display(Name = "Slider Image")]
        public IFormFile File { get; set; }

    }
}
