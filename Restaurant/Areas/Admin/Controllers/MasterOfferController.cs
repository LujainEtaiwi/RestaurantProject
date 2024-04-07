using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Repository;
using Restaurant.ViewModels;
using System.Security.Claims;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterOfferController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting;
        private readonly IRepository<MasterOffer> masterOffer;

        public MasterOfferController(UserManager<AppUser> _userManager, Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting, IRepository<MasterOffer> _MasterOffer)
        {
            userManager = _userManager;
            hosting = _hosting;
            masterOffer = _MasterOffer;
        }
        public async Task<ActionResult> MasterOfferIndex(int idDelete)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            if (idDelete != 0)
            {
                var data = masterOffer.Find(idDelete);
                MasterOffer obj = new MasterOffer
                {
                    EditDate = DateTime.Now,
                    EditUser = user.Id,
                };
                masterOffer.Delete(idDelete, obj);
                return RedirectToAction(nameof(MasterOfferIndex));
            }
            var data2 = masterOffer.View();
            return View(data2);
        }
        // GET: AdminController/Create
        public ActionResult MasterOfferCreate()
        {
            return View();
        }
        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MasterOfferCreate(MasterOfferModels collection)
        {
            try
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                string ImageName = UploadFile(collection.File);
                var data = new MasterOffer
                {
                    MasterOfferId = collection.MasterOfferId,
                    MasterOfferTitle = collection.MasterOfferTitle,
                    MasterOfferBreef = collection.MasterOfferBreef,
                    MasterOfferDesc = collection.MasterOfferDesc,
                    MasterOfferImageUrl = ImageName,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    EditUser = "",
                    IsActive = true,
                    
                };
                masterOffer.Add(data);
                return RedirectToAction(nameof(MasterOfferIndex));
            }
            catch
            {
                return View();
            }
        }
        // GET: AdminController/Edit/5
        public ActionResult MasterOfferEdit(int id)
        {
            var data = masterOffer.Find(id);
            var result = new MasterOfferModels
            {
                MasterOfferId = data.MasterOfferId,
                MasterOfferTitle = data.MasterOfferTitle,
                MasterOfferBreef = data.MasterOfferBreef,
                MasterOfferDesc = data.MasterOfferDesc,
                MasterOfferImageUrl = data.MasterOfferImageUrl,
                CreateUser = data.CreateUser,
                CreateDate = data.CreateDate,
                IsActive = data.IsActive,

            };
            return View(result);
        }
        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MasterOfferEdit(int id, MasterOfferModels collection)
        {
            try
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                string ImageName = UploadFile(collection.File);
                var data = new MasterOffer
                {
                    MasterOfferId = collection.MasterOfferId,
                    MasterOfferTitle = collection.MasterOfferTitle,
                    MasterOfferBreef = collection.MasterOfferBreef,
                    MasterOfferDesc = collection.MasterOfferDesc,
                    MasterOfferImageUrl = (ImageName != "") ? ImageName : collection.MasterOfferImageUrl,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.EditDate,
                    IsActive = collection.IsActive,
                    EditUser = user.Id,
                    EditDate = DateTime.Now,
                };
                masterOffer.Update(id, data);
                return RedirectToAction(nameof(MasterOfferIndex));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Active(int id)
        {
            masterOffer.Active(id, new MasterOffer()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(MasterOfferIndex));
        }

        string UploadFile(IFormFile File)
        {
            string fileName = "";
            if (File != null)
            {
                string pathFile = Path.Combine(hosting.WebRootPath, "images");
                FileInfo fileInfo = new FileInfo(File.FileName);
                fileName = "Image_" + Guid.NewGuid() + fileInfo.Extension;
                string fullPath = Path.Combine(pathFile, fileName);
                File.CopyTo(new FileStream(fullPath, FileMode.Create));
            }
            return fileName;
        }
    }
}
