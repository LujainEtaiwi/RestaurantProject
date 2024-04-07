using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class MasterContactUsInformation: BaseEntity
    {
        [Required]
        public int MasterContactUsInformationId { get; set; }

        [Required]
        [Display(Name = "Descreption")]
        public string? MasterContactUsInformationIdesc { get; set; }

        [Display(Name = "Image")]
        public string? MasterContactUsInformationImageUrl { get; set; }

        [Required]
        [Display(Name = "Redirect")]
        public string? MasterContactUsInformationRedirect { get; set; }
    }
}
