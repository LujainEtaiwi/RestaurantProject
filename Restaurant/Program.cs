using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Restaurant.Data;
using Restaurant.Models;
using Restaurant.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(x=>x.EnableEndpointRouting=false);
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon")));
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddScoped<IRepository<MasterCategoryMenu>, dbMasterCategoryMenuRepo>();
builder.Services.AddScoped<IRepository<MasterContactUsInformation>, dbMasterContactUsInformationRepo>();
builder.Services.AddScoped<IRepository<MasterItemMenu>, dbMasterItemMenuRepo>();
builder.Services.AddScoped<IRepository<MasterMenu>, dbMasterMenuRepo>();
builder.Services.AddScoped<IRepository<MasterOffer>, dbMasterOfferRepo>();
builder.Services.AddScoped<IRepository<MasterPartner>, dbMasterPartnerRepo>();
builder.Services.AddScoped<IRepository<MasterServices>, dbMasterServicesRepo>();
builder.Services.AddScoped<IRepository<MasterSlider>, dbMasterSliderRepo>();
builder.Services.AddScoped<IRepository<MasterSocialMedium>, dbMasterSocialMediumRepo>();
builder.Services.AddScoped<IRepository<MasterWorkingHours>, dbMasterWorkingHoursRepo>();
builder.Services.AddScoped<IRepository<SystemSetting>, dbSystemSettingRepo>();
builder.Services.AddScoped<IRepository<TransactionBookTable>, dbTransactionBookTableRepo>();
builder.Services.AddScoped<IRepository<TransactionContactUs>, dbTransactionContactUsRepo>();
builder.Services.AddScoped<IRepository<TransactionNewsletter>, dbTransactionNewsletterRepo>();
builder.Services.AddScoped<IRepository<Review>, dbReviewRepo>();


builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Admin/Account/Login";
});
var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
 

    app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Account}/{action=Login}/{id?}"
            );

    app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"
            );

});
app.Run();
