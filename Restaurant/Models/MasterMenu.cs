using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public partial class MasterMenu: BaseEntity
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
