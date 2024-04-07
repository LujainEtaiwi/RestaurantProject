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
    public class MasterSocialMediumController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting;
        private readonly IRepository<MasterSocialMedium> masterSocialMedium;

        public MasterSocialMediumController(UserManager<AppUser> _userManager, Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting, IRepository<MasterSocialMedium> _MasterSocialMedium)
        {
            userManager = _userManager;
            hosting = _hosting;
            masterSocialMedium = _MasterSocialMedium;
        }
        public async Task<ActionResult> MasterSocialMediumIndex(int idDelete)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            if (idDelete != 0)
            {
                var data = masterSocialMedium.Find(idDelete);
                MasterSocialMedium obj = new MasterSocialMedium
                {
                    EditDate = DateTime.Now,
                    EditUser = user.Id,
                };
                masterSocialMedium.Delete(idDelete, obj);
                return RedirectToAction(nameof(MasterSocialMediumIndex));
            }
            var data2 = masterSocialMedium.View();
            return View(data2);
        }
        // GET: AdminController/Create
        public ActionResult MasterSocialMediumCreate()
        {
            return View();
        }
        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MasterSocialMediumCreate(MasterSocialMediumModels collection)
        {
            try
            {

                var user = await userManager.FindByNameAsync(User.Identity.Name);
                string ImageName = UploadFile(collection.File);
                var data = new MasterSocialMedium
                {
                    MasterSocialMediumId = collection.MasterSocialMediumId,
                    MasterSocialMediumImageUrl = ImageName,
                    MasterSocialMediumUrl = collection.MasterSocialMediumUrl,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    EditUser = "",
                    IsActive = true
                };
                masterSocialMedium.Add(data);
                return RedirectToAction(nameof(MasterSocialMediumIndex));
            }
            catch
            {
                return View();
            }
        }
        // GET: AdminController/Edit/5
        public ActionResult MasterSocialMediumEdit(int id)
        {
            var data = masterSocialMedium.Find(id);
            var result = new MasterSocialMediumModels
            {
                MasterSocialMediumId = data.MasterSocialMediumId,
                MasterSocialMediumImageUrl = data.MasterSocialMediumImageUrl,
                MasterSocialMediumUrl = data.MasterSocialMediumUrl,
                CreateUser = data.CreateUser,
                CreateDate = data.CreateDate
            };
            return View(result);
        }
        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MasterSocialMediumEdit(int id, MasterSocialMediumModels collection)
        {
            try
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                string ImageName = UploadFile(collection.File);
                var data = new MasterSocialMedium
                {
                    MasterSocialMediumId = collection.MasterSocialMediumId,
                    MasterSocialMediumImageUrl = (ImageName != "") ? ImageName : collection.MasterSocialMediumImageUrl,
                    MasterSocialMediumUrl = collection.MasterSocialMediumUrl,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now
                };
                masterSocialMedium.Update(id, data);
                return RedirectToAction(nameof(MasterSocialMediumIndex));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Active(int id)
        {
            masterSocialMedium.Active(id, new MasterSocialMedium()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(MasterSocialMediumIndex));
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
