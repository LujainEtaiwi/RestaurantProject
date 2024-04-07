using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class MasterItemMenu: BaseEntity
    {
        [Required]
        public int MasterItemMenuId { get; set; }

        [Required]
        [Display(Name = "Item Category")]
        public int MasterCategoryMenuId { get; set; }


        [Required]
        [Display(Name = "Item Title")]
        public string? MasterItemMenuTitle { get; set; }

        [Required]
        [Display(Name = "Item Breef")]
        public string? MasterItemMenuBreef { get; set; }

        [Required]
        [Display(Name = "Item Descreption")]
        public string? MasterItemMenuDesc { get; set; }

        [Required]
        [Display(Name = "Item Price")]
        public decimal? MasterItemMenuPrice { get; set; }

        [Required]
        [Display(Name = "Item Image")]
        public string? MasterItemMenuImageUrl { get; set; }

        [Required]
        [Display(Name = "Item Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? MasterItemMenuDate { get; set; }

        
        public MasterCategoryMenu? MasterCategoryMenu { get; set; }
    }
}
