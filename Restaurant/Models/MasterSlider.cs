using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class MasterSlider: BaseEntity
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
        [Display(Name = "Slider Url")]
        public string? MasterSliderUrl { get; set; }
    }
}
