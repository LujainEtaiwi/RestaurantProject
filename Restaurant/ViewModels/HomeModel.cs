using Restaurant.Models;

namespace Restaurant.ViewModels
{
    public class HomeModel
    {
        public List<MasterCategoryMenu> ListMasterCategoryMenu { get; set; }

        public List<MasterContactUsInformation> ListMasterContactUsInformation { get; set; }

        public List<MasterItemMenu> ListMasterItemMenu { get; set; }

        public List<MasterMenu> ListMasterMenu { get; set; }

        public MasterOffer MasterOffer { get; set; }

        public List<MasterPartner> ListMasterPartner { get; set; }

        public List<MasterServices> ListMasterServices { get; set; }

        public List<MasterSlider> ListMasterSlider { get; set; }

        public List<MasterSocialMedium> ListMasterSocialMedium { get; set; }

        public List<MasterWorkingHours> ListMasterWorkingHours { get; set; }

        public List<Review> ListReview { get; set; }

        public SystemSetting SystemSetting { get; set; }

        public MasterItemMenu MasterItemMenu { get; set; }

        public TransactionBookTable TransactionBookTable { get; set; }

        public TransactionNewsletter TransactionNewsletter { get; set; }

        public TransactionContactUs TransactionContactUs { get; set; }

    }
}
