using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.Repository;
using Restaurant.Models;
using Restaurant.ViewModels;
using System.Security.Claims;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<TransactionBookTable> transactionBookTable;
        private readonly IRepository<TransactionNewsletter> transactionNewsletter;
        private readonly IRepository<TransactionContactUs> transactionContactUs;
        private readonly IRepository<MasterCategoryMenu> category;
        private readonly IRepository<MasterContactUsInformation> info;
        private readonly IRepository<MasterItemMenu> item;
        private readonly IRepository<MasterMenu> menu;
        private readonly IRepository<MasterOffer> offer;
        private readonly IRepository<MasterPartner> partner;
        private readonly IRepository<MasterServices> service;
        private readonly IRepository<MasterSlider> slider;
        private readonly IRepository<MasterSocialMedium> social;
        private readonly IRepository<MasterWorkingHours> hours;
        private readonly IRepository<Review> review;
        private readonly IRepository<SystemSetting> setting;

        public HomeController(
             IRepository<TransactionBookTable> _TransactionBookTable
            ,IRepository<TransactionNewsletter> _TransactionNewsletter
            ,IRepository<TransactionContactUs> _TransactionContactUs
            ,IRepository<MasterCategoryMenu> _category
            ,IRepository<MasterContactUsInformation> _info
            ,IRepository<MasterItemMenu> _item
            ,IRepository<MasterMenu> _menu
            ,IRepository<MasterOffer> _offer
            ,IRepository<MasterPartner> _partner
            ,IRepository<MasterServices> _service
            ,IRepository<MasterSlider> _slider
            ,IRepository<MasterSocialMedium> _social
            ,IRepository<MasterWorkingHours> _hours
            ,IRepository<Review> _review
            ,IRepository<SystemSetting> _setting)
        {
            transactionBookTable = _TransactionBookTable;
            transactionNewsletter = _TransactionNewsletter;
            transactionContactUs = _TransactionContactUs;
            category = _category;
            info = _info;
            item = _item;
            menu = _menu;
            offer = _offer;
            partner = _partner;
            service = _service;
            slider = _slider;
            social = _social;
            hours = _hours;
            review = _review;
            setting = _setting;
        }


        public IActionResult Index()
        {
            HomeModel obj= new HomeModel();

            obj.ListMasterMenu = menu.ViewFromClient().ToList();
            obj.ListMasterSlider = slider.ViewFromClient().ToList();
            obj.SystemSetting = setting.Find(5);
            obj.ListMasterItemMenu = item.ViewFromClient().ToList();
            obj.MasterOffer = offer.Find(3);
            obj.ListReview = review.ViewFromClient().ToList();
            obj.ListMasterPartner = partner.ViewFromClient().ToList();
            obj.ListMasterSocialMedium = social.ViewFromClient().ToList();
            obj.ListMasterContactUsInformation = info.ViewFromClient().ToList();
            obj.ListMasterWorkingHours = hours.ViewFromClient().ToList();

            return View(obj);
        }


        public IActionResult About()
        {
            HomeModel obj = new HomeModel();


            obj.ListMasterMenu = menu.ViewFromClient().ToList();
            obj.SystemSetting = setting.Find(5);
            obj.ListReview = review.ViewFromClient().ToList();
            obj.ListMasterSocialMedium = social.ViewFromClient().ToList();
            obj.ListMasterContactUsInformation = info.ViewFromClient().ToList();
            obj.ListMasterWorkingHours = hours.ViewFromClient().ToList();
            obj.ListMasterServices = service.ViewFromClient().ToList();

            return View(obj);
        }


        public IActionResult Menu()
        {
            HomeModel obj = new HomeModel();

            obj.ListMasterCategoryMenu = category.ViewFromClient().ToList();
            obj.ListMasterMenu = menu.ViewFromClient().ToList();
            obj.SystemSetting = setting.Find(5);
            obj.ListMasterItemMenu = item.ViewFromClient().ToList();
            obj.ListMasterPartner = partner.ViewFromClient().ToList();
            obj.ListMasterSocialMedium = social.ViewFromClient().ToList();
            obj.ListMasterContactUsInformation = info.ViewFromClient().ToList();
            obj.ListMasterWorkingHours = hours.ViewFromClient().ToList();
            obj.ListMasterServices = service.ViewFromClient().ToList();

            return View(obj);
        }


        public IActionResult ContactUs()
        {
            HomeModel obj = new HomeModel();

            obj.ListMasterMenu = menu.ViewFromClient().ToList();
            obj.SystemSetting = setting.Find(5);
            obj.ListMasterSocialMedium = social.ViewFromClient().ToList();
            obj.ListMasterContactUsInformation = info.ViewFromClient().ToList();
            obj.ListMasterWorkingHours = hours.ViewFromClient().ToList();

            return View(obj);
        }


        public IActionResult ProductDetails1(int idDetails)
        {
            HomeModel obj = new HomeModel();

            obj.ListMasterMenu = menu.ViewFromClient().ToList();
            obj.SystemSetting = setting.Find(5);
            obj.ListMasterSocialMedium = social.ViewFromClient().ToList();
            obj.MasterItemMenu = item.Find(idDetails);
            obj.ListMasterContactUsInformation = info.ViewFromClient().ToList();
            obj.ListMasterWorkingHours = hours.ViewFromClient().ToList();
            obj.ListMasterItemMenu = item.ViewFromClient().ToList();
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BookTable(HomeModel collection)
        {
            try
            {
                collection.TransactionBookTable.CreateDate = DateTime.Now;
                collection.TransactionBookTable.IsActive = true;
                collection.TransactionBookTable.IsDelete = false;
                transactionBookTable.Add(collection.TransactionBookTable);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewsTable(HomeModel collection)
        {
            try
            {
                collection.TransactionNewsletter.CreateDate = DateTime.Now;
                collection.TransactionNewsletter.IsActive = true;
                collection.TransactionNewsletter.IsDelete = false;
                transactionNewsletter.Add(collection.TransactionNewsletter);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ContactTable(HomeModel collection)
        {
            try
            {
                collection.TransactionContactUs.CreateDate = DateTime.Now;
                collection.TransactionContactUs.IsActive = true;
                collection.TransactionContactUs.IsDelete = false;
                transactionContactUs.Add(collection.TransactionContactUs);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



    }

}
