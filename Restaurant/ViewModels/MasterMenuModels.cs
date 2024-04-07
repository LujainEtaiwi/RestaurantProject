using Restaurant.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class MasterMenuModels : BaseEntity
    {
        [Required]
        public int MasterMenuId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string MasterMenuName { get; set; } = null!;

        [Required]
        [Display(Name = "Url")]
        public string MasterMenuUrl { get; set; } = null!;
    }
}
