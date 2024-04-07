using Restaurant.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class MasterCategoryMenuModels: BaseEntityModels
    {
        [Required]
        public int MasterCategoryMenuId { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string? MasterCategoryMenuName { get; set; }


        public List<MasterCategoryMenu>? MasterCategoryMenuList { get; set; }
    }
}
