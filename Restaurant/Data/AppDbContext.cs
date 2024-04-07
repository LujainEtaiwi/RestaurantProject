using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant.Data
{
    public class AppDbContext: IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public virtual DbSet<MasterCategoryMenu> MasterCategoryMenus { get; set; } = null!;
        public virtual DbSet<MasterContactUsInformation> MasterContactUsInformations { get; set; } = null!;
        public virtual DbSet<MasterItemMenu> MasterItemMenus { get; set; } = null!;
        public virtual DbSet<MasterMenu> MasterMenus { get; set; } = null!;
        public virtual DbSet<MasterOffer> MasterOffers { get; set; } = null!;
        public virtual DbSet<MasterPartner> MasterPartners { get; set; } = null!;
        public virtual DbSet<MasterServices> MasterServices { get; set; } = null!;
        public virtual DbSet<MasterSlider> MasterSliders { get; set; } = null!;
        public virtual DbSet<MasterSocialMedium> MasterSocialMedium { get; set; } = null!;
        public virtual DbSet<MasterWorkingHours> MasterWorkingHours { get; set; } = null!;
        public virtual DbSet<SystemSetting> SystemSettings { get; set; } = null!;
        public virtual DbSet<TransactionBookTable> TransactionBookTables { get; set; } = null!;
        public virtual DbSet<TransactionContactUs> TransactionContactUs { get; set; } = null!;
        public virtual DbSet<TransactionNewsletter> TransactionNewsletters { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
    }
}
