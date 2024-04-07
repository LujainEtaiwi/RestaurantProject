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
    public class MasterServicesController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting;
        private readonly IRepository<MasterServices> masterServices;

        public MasterServicesController(UserManager<AppUser> _userManager, Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting, IRepository<MasterServices> _MasterServices)
        {
            userManager = _userManager;
            hosting = _hosting;
            masterServices = _MasterServices;
        }
        public async Task<ActionResult> MasterServicesIndex(int idDelete)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            if (idDelete != 0)
            {
                var data = masterServices.Find(idDelete);
                MasterServices obj = new MasterServices
                {
                    EditDate = DateTime.Now,
                    EditUser = user.Id,
                };
                masterServices.Delete(idDelete, obj);
                return RedirectToAction(nameof(MasterServicesIndex));
            }
            var data2 = masterServices.View();
            return View(data2);
        }
        // GET: AdminController/Create
        public ActionResult MasterServicesCreate()
        {
            return View();
        }
        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MasterServicesCreate(MasterServicesModels collection)
        {
            try
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                var data = new MasterServices
                {
                    MasterServicesId = collection.MasterServicesId,
                    MasterServicesTitle = collection.MasterServicesTitle,
                    MasterServicesDesc = collection.MasterServicesDesc,
                    MasterServicesImage = collection.MasterServicesImage,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    EditUser = "",
                    IsActive = true
                };
                masterServices.Add(data);
                return RedirectToAction(nameof(MasterServicesIndex));
            }
            catch
            {
                return View();
            }
        }
        // GET: AdminController/Edit/5
        public ActionResult MasterServicesEdit(int id)
        {
            var data = masterServices.Find(id);
            var result = new MasterServicesModels
            {
                MasterServicesId = data.MasterServicesId,
                MasterServicesTitle = data.MasterServicesTitle,
                MasterServicesDesc = data.MasterServicesDesc,
                MasterServicesImage = data.MasterServicesImage,
                CreateUser = data.CreateUser,
                CreateDate = data.CreateDate,
                IsActive = data.IsActive,
                IsDelete = data.IsDelete,
            };
            return View(result);
        }
        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MasterServicesEdit(int id, MasterServicesModels collection)
        {
            try
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                string ImageName = UploadFile(collection.File);
                var data = new MasterServices
                {
                    MasterServicesId = collection.MasterServicesId,
                    MasterServicesTitle = collection.MasterServicesTitle,
                    MasterServicesDesc = collection.MasterServicesDesc,
                    MasterServicesImage = collection.MasterServicesImage,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now,
                    IsActive = true,
                    IsDelete = false
                };
                masterServices.Update(id, data);
                return RedirectToAction(nameof(MasterServicesIndex));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Active(int id)
        {
            masterServices.Active(id, new MasterServices()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(MasterServicesIndex));
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
