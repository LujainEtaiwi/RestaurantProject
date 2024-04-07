using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Review:BaseEntity
    {
        [Required]
        public int ReviewId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string ReviewTitle { get; set; }

        [Required]
        [Display(Name = "Desc")]
        public string ReviewDesc { get; set; }

        [Display(Name = "Image")]
        public string ReviewImage { get; set; }
    }
}
