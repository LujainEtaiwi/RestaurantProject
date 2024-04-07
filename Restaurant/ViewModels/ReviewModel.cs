using Restaurant.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class ReviewModel:BaseEntity
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

        [Display(Name = "Image")]
        public IFormFile File { get; set; }
    }
}
