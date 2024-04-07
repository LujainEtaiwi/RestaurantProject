using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class TransactionBookTable:BaseEntity
    {
        [Required]
        public int TransactionBookTableId { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string? TransactionBookTableFullName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string? TransactionBookTableEmail { get; set; }

        [Required]
        [Display(Name = "Mobile Number")]
        public string? TransactionBookTableMobileNumber { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? TransactionBookTableDate { get; set; }
    }
}
