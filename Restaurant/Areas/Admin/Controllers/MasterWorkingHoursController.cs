using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.Repository;
using Restaurant.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterWorkingHoursController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting;
        private readonly IRepository<MasterWorkingHours> masterWorkingHours;

        public MasterWorkingHoursController(UserManager<AppUser> _userManager, Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting, IRepository<MasterWorkingHours> _MasterWorkingHours)
        {
            userManager = _userManager;
            hosting = _hosting;
            masterWorkingHours = _MasterWorkingHours;
        }
        public async Task<ActionResult> MasterWorkingHoursIndex(int idDelete)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            if (idDelete != 0)
            {
                var data = masterWorkingHours.Find(idDelete);
                MasterWorkingHours obj = new MasterWorkingHours
                {
                    EditDate = DateTime.Now,
                    EditUser = user.Id,
                };
                masterWorkingHours.Delete(idDelete, obj);
                return RedirectToAction(nameof(MasterWorkingHoursIndex));
            }
            var data2 = masterWorkingHours.View();
            return View(data2);
        }
        // GET: AdminController/Create
        public ActionResult MasterWorkingHoursCreate()
        {
            return View();
        }
        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MasterWorkingHoursCreate(MasterWorkingHours collection)
        {
            try
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                collection.CreateUser = user.Id;
                collection.CreateDate = DateTime.Now;
                collection.EditUser = "";
                collection.IsActive = true;
                masterWorkingHours.Add(collection);
                return RedirectToAction(nameof(MasterWorkingHoursIndex));
            }
            catch
            {
                return View();
            }
        }
        // GET: AdminController/Edit/5
        public ActionResult MasterWorkingHoursEdit(int id)
        {
            var data = masterWorkingHours.Find(id);
            return View(data);
        }
        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MasterWorkingHoursEdit(int id, MasterWorkingHours collection)
        {
            try
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                collection.EditUser = user.Id;
                collection.EditDate = DateTime.Now;
                masterWorkingHours.Update(id, collection);
                return RedirectToAction(nameof(MasterWorkingHoursIndex));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Active(int id)
        {
            masterWorkingHours.Active(id, new MasterWorkingHours()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(MasterWorkingHoursIndex));
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
