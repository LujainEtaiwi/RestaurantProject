using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class TransactionContactUs : BaseEntity
    {
        [Required]
        public int TransactionContactUsId { get; set; }

        [Required]
        [Display(Name = "FullName")]
        public string? TransactionContactUsFullName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string? TransactionContactUsEmail { get; set; }

        [Required]
        [Display(Name = "Subject")]
        public string? TransactionContactUsSubject { get; set; }

        [Required]
        [Display(Name = "Message")]
        public string? TransactionContactUsMessage { get; set; }
    }
}
