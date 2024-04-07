using Restaurant.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class MasterItemMenuModels : BaseEntity
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


        public string? MasterItemMenuImageUrl { get; set; }

        [Required]
        [Display(Name = "Item Date")]
        public DateTime? MasterItemMenuDate { get; set; }

        
        public MasterCategoryMenu? MasterCategoryMenu { get; set; }

        [Display(Name = "Item Image")]
        public IFormFile File { get; set; }
    }
}
