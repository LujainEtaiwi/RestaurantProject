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
    public class MasterPartnerController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting;
        private readonly IRepository<MasterPartner> masterPartner;

        public MasterPartnerController(UserManager<AppUser> _userManager, Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting, IRepository<MasterPartner> _MasterPartner)
        {
            userManager = _userManager;
            hosting = _hosting;
            masterPartner = _MasterPartner;
        }
        public async Task<ActionResult> MasterPartnerIndex(int idDelete)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            if (idDelete != 0)
            {
                var data = masterPartner.Find(idDelete);
                MasterPartner obj = new MasterPartner
                {
                    EditDate = DateTime.Now,
                    EditUser = user.Id,
                };
                masterPartner.Delete(idDelete, obj);
                return RedirectToAction(nameof(MasterPartnerIndex));
            }
            var data2 = masterPartner.View();
            return View(data2);
        }
        // GET: AdminController/Create
        public ActionResult MasterPartnerCreate()
        {
            return View();
        }
        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MasterPartnerCreate(MasterPartnerModels collection)
        {
            try
            {

                string ImageName = UploadFile(collection.File);
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                var data = new MasterPartner
                {
                    MasterPartnerId = collection.MasterPartnerId,
                    MasterPartnerName = collection.MasterPartnerName,
                    MasterPartnerLogoImageUrl = ImageName,
                    MasterPartnerWebsiteUrl = collection.MasterPartnerWebsiteUrl,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    EditUser = "",
                    IsActive = true
                };
                masterPartner.Add(data);
                return RedirectToAction(nameof(MasterPartnerIndex));
            }
            catch
            {
                return View();
            }
        }
        // GET: AdminController/Edit/5
        public ActionResult MasterPartnerEdit(int id)
        {
            var data = masterPartner.Find(id);
            var result = new MasterPartnerModels
            {
                MasterPartnerId = data.MasterPartnerId,
                MasterPartnerName = data.MasterPartnerName,
                MasterPartnerLogoImageUrl = data.MasterPartnerLogoImageUrl,
                MasterPartnerWebsiteUrl = data.MasterPartnerWebsiteUrl,
                CreateUser = data.CreateUser,
                CreateDate = data.CreateDate,
                IsActive = data.IsActive,
                IsDelete = data.IsDelete
            };
            return View(result);
        }
        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MasterPartnerEdit(int id, MasterPartnerModels collection)
        {
            try
            {

                var user = await userManager.FindByNameAsync(User.Identity.Name);
                string ImageName = UploadFile(collection.File);
                var data = new MasterPartner
                {
                    MasterPartnerId = collection.MasterPartnerId,
                    MasterPartnerName = collection.MasterPartnerName,
                    MasterPartnerLogoImageUrl = (ImageName != "") ? ImageName : collection.MasterPartnerLogoImageUrl,
                    MasterPartnerWebsiteUrl = collection.MasterPartnerWebsiteUrl,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now,
                    IsActive = collection.IsActive,
                };
                masterPartner.Update(id, data);
                return RedirectToAction(nameof(MasterPartnerIndex));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Active(int id)
        {
            masterPartner.Active(id, new MasterPartner()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(MasterPartnerIndex));
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
