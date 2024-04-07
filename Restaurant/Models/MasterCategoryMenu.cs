using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class MasterCategoryMenu: BaseEntity
    {
        [Required]
        public int MasterCategoryMenuId { get; set; }

        [Required(ErrorMessage ="Enter Category Name")]
        [Display(Name = "Category Name")]
        public string? MasterCategoryMenuName { get; set; }

    }
}
