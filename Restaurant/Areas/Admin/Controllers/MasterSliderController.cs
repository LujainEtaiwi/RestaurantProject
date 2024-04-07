using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.Repository;
using Restaurant.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Restaurant.ViewModels;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterSliderController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting;
        private readonly IRepository<MasterSlider> masterSlider;

        public MasterSliderController(UserManager<AppUser> _userManager, Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting, IRepository<MasterSlider> _MasterSlider)
        {
            userManager = _userManager;
            hosting = _hosting;
            masterSlider = _MasterSlider;
        }
        public async Task<ActionResult> MasterSliderIndex(int idDelete)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            if (idDelete != 0)
            {
                var data = masterSlider.Find(idDelete);
                MasterSlider obj = new MasterSlider
                {
                    EditDate = DateTime.Now,
                    EditUser = user.Id,
                };
                masterSlider.Delete(idDelete, obj);
                return RedirectToAction(nameof(MasterSliderIndex));
            }
            var data2 = masterSlider.View();
            return View(data2);
        }
        // GET: AdminController/Create
        public ActionResult MasterSliderCreate()
        {
            return View();
        }
        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MasterSliderCreate(MasterSliderModels collection)
        {
            try
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                string ImageName = UploadFile(collection.File);
                var obj = new MasterSlider
                {
                    MasterSliderId = collection.MasterSliderId,
                    MasterSliderTitle = collection.MasterSliderTitle,
                    MasterSliderBreef = collection.MasterSliderBreef,
                    MasterSliderDesc = collection.MasterSliderDesc,
                    MasterSliderUrl = ImageName,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    EditUser = "",
                    IsActive = true,
                };
                masterSlider.Add(obj);
                return RedirectToAction(nameof(MasterSliderIndex));
            }
            catch
            {
                return View();
            }
        }
        // GET: AdminController/Edit/5
        public ActionResult MasterSliderEdit(int id)
        {
            var data = masterSlider.Find(id);
            var obj = new MasterSliderModels
            {
                MasterSliderId = data.MasterSliderId,
                MasterSliderTitle = data.MasterSliderTitle,
                MasterSliderBreef = data.MasterSliderBreef,
                MasterSliderDesc = data.MasterSliderDesc,
                CreateUser = data.CreateUser,
                CreateDate = data.CreateDate,
                IsActive = data.IsActive,
            };
            return View(obj);
        }
        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MasterSliderEdit(int id, MasterSliderModels collection)
        {
            try
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                string ImageName = UploadFile(collection.File);
                var obj = new MasterSlider
                {
                    MasterSliderId = collection.MasterSliderId,
                    MasterSliderTitle = collection.MasterSliderTitle,
                    MasterSliderBreef = collection.MasterSliderBreef,
                    MasterSliderDesc = collection.MasterSliderDesc,
                    MasterSliderUrl = (ImageName != "") ? ImageName : collection.MasterSliderUrl,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.EditDate,
                    IsActive = collection.IsActive,
                    EditUser = user.Id,
                    EditDate = DateTime.Now,
                };
                masterSlider.Update(id, obj);
                return RedirectToAction(nameof(MasterSliderIndex));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Active(int id)
        {
            masterSlider.Active(id, new MasterSlider()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(MasterSliderIndex));
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
