using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class BaseEntity
    {
        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }

        public string CreateUser { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreateDate { get; set; }

        public string EditUser { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EditDate { get; set; }
    }
}
