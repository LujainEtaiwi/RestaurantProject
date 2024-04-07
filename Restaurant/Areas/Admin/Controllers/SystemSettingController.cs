using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.Repository;
using Restaurant.Models;
using Restaurant.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SystemSettingController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting;
        private readonly IRepository<SystemSetting> systemSetting;

        public SystemSettingController(UserManager<AppUser> _userManager, Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting, IRepository<SystemSetting> _SystemSetting)
        {
            userManager = _userManager;
            hosting = _hosting;
            systemSetting = _SystemSetting;
        }
        public async Task<ActionResult> SystemSettingIndex(int idDelete)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            if (idDelete != 0)
            {
                var data = systemSetting.Find(idDelete);
                SystemSetting obj = new SystemSetting
                {
                    EditDate = DateTime.Now,
                    EditUser = user.Id,
                };
                systemSetting.Delete(idDelete, obj);
                return RedirectToAction(nameof(SystemSettingIndex));
            }
            var data2 = systemSetting.View();
            return View(data2);
        }
        // GET: AdminController/Create
        public ActionResult SystemSettingCreate()
        {
            return View();
        }
        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SystemSettingCreate(SystemSettingModels collection)
        {
            try
            {
                string ImageName = UploadFile(collection.File);
                string ImageName2 = UploadFile(collection.File2);
                string ImageName3 = UploadFile(collection.File3);
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                var data = new SystemSetting
                {
                    SystemSettingId = collection.SystemSettingId,
                    SystemSettingLogoImageUrl = ImageName,
                    SystemSettingLogoImageUrl2 = ImageName2,
                    SystemSettingCopyright = collection.SystemSettingCopyright,
                    SystemSettingWelcomeNoteTitle = collection.SystemSettingWelcomeNoteTitle,
                    SystemSettingWelcomeNoteBreef = collection.SystemSettingWelcomeNoteBreef,
                    SystemSettingWelcomeNoteDesc = collection.SystemSettingWelcomeNoteDesc,
                    SystemSettingWelcomeNoteUrl = collection.SystemSettingWelcomeNoteUrl,
                    SystemSettingWelcomeNoteImageUrl = ImageName3,
                    SystemSettingMapLocation = collection.SystemSettingMapLocation,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    EditUser = "",
                    IsActive = true
                };
                systemSetting.Add(data);
                return RedirectToAction(nameof(SystemSettingIndex));
            }
            catch
            {
                return View();
            }
        }
        // GET: AdminController/Edit/5
        public ActionResult SystemSettingEdit(int id)
        {
            var data = systemSetting.Find(id);
            var result = new SystemSettingModels
            {
                SystemSettingId = data.SystemSettingId,
                SystemSettingLogoImageUrl = data.SystemSettingLogoImageUrl,
                SystemSettingLogoImageUrl2 = data.SystemSettingLogoImageUrl2,
                SystemSettingCopyright = data.SystemSettingCopyright,
                SystemSettingWelcomeNoteTitle = data.SystemSettingWelcomeNoteTitle,
                SystemSettingWelcomeNoteBreef = data.SystemSettingWelcomeNoteBreef,
                SystemSettingWelcomeNoteDesc = data.SystemSettingWelcomeNoteDesc,
                SystemSettingWelcomeNoteUrl = data.SystemSettingWelcomeNoteUrl,
                SystemSettingWelcomeNoteImageUrl = data.SystemSettingWelcomeNoteImageUrl,
                SystemSettingMapLocation = data.SystemSettingMapLocation,
                CreateUser = data.CreateUser,
                CreateDate = data.CreateDate
            };
            return View(result);
        }
        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SystemSettingEdit(int id, SystemSettingModels collection)
        {
            try
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                string ImageName = UploadFile(collection.File);
                string ImageName2 = UploadFile(collection.File2);
                string ImageName3 = UploadFile(collection.File3);
                var data = new SystemSetting
                {
                    SystemSettingId = collection.SystemSettingId,
                    SystemSettingLogoImageUrl = (ImageName != "") ? ImageName : collection.SystemSettingLogoImageUrl,
                    SystemSettingLogoImageUrl2 = (ImageName2 != "") ? ImageName2 : collection.SystemSettingLogoImageUrl2,
                    SystemSettingCopyright = collection.SystemSettingCopyright,
                    SystemSettingWelcomeNoteTitle = collection.SystemSettingWelcomeNoteTitle,
                    SystemSettingWelcomeNoteBreef = collection.SystemSettingWelcomeNoteBreef,
                    SystemSettingWelcomeNoteDesc = collection.SystemSettingWelcomeNoteDesc,
                    SystemSettingWelcomeNoteUrl = collection.SystemSettingWelcomeNoteUrl,
                    SystemSettingWelcomeNoteImageUrl = (ImageName3 != "") ? ImageName3 : collection.SystemSettingWelcomeNoteImageUrl,
                    SystemSettingMapLocation = collection.SystemSettingMapLocation,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now,
                };
                systemSetting.Update(id, data);
                return RedirectToAction(nameof(SystemSettingIndex));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Active(int id)
        {
            systemSetting.Active(id, new SystemSetting()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(SystemSettingIndex));
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
