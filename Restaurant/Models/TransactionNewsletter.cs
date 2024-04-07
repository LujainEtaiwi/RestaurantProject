using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class TransactionNewsletter : BaseEntity
    {
        [Required]
        public int TransactionNewsletterId { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string? TransactionNewsletterEmail { get; set; }
    }
}
