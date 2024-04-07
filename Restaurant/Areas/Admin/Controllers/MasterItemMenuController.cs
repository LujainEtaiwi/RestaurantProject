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
    public class MasterItemMenuController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IRepository<MasterItemMenu> masterItemMenu;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting;
        private readonly IRepository<MasterCategoryMenu> masterCategoryMenu;

        public MasterItemMenuController(UserManager<AppUser> _userManager, IRepository<MasterItemMenu> _MasterItemMenu, Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting, IRepository<MasterCategoryMenu> _MasterCategoryMenu)
        {
            userManager = _userManager;
            masterItemMenu = _MasterItemMenu;
            hosting = _hosting;
            masterCategoryMenu = _MasterCategoryMenu;
        }
        public async Task<ActionResult> MasterItemMenuIndex(int idDelete)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            if (idDelete != 0)
            {
                var data = masterItemMenu.Find(idDelete);
                MasterItemMenu obj = new MasterItemMenu
                {
                    EditDate = DateTime.Now,
                    EditUser = user.Id,
                };
                masterItemMenu.Delete(idDelete, obj);
                return RedirectToAction(nameof(MasterItemMenuIndex));
            }
            var data2 = masterItemMenu.View();
            return View(data2);
        }
        // GET: AdminController/Create
        public ActionResult MasterItemMenuCreate()
        {
            var data = masterCategoryMenu.View();
            ViewBag.category = data;

            return View();
        }
        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MasterItemMenuCreate(MasterItemMenuModels collection)
        {
            try
            {
                string ImageName = UploadFile(collection.File);
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                var data = new MasterItemMenu
                {
                    MasterItemMenuId = collection.MasterItemMenuId,
                    MasterItemMenuTitle = collection.MasterItemMenuTitle,
                    MasterItemMenuBreef = collection.MasterItemMenuBreef,
                    MasterItemMenuDesc = collection.MasterItemMenuDesc,
                    MasterItemMenuPrice = collection.MasterItemMenuPrice,
                    MasterItemMenuDate = collection.MasterItemMenuDate,
                    MasterCategoryMenuId = collection.MasterCategoryMenuId,
                    MasterItemMenuImageUrl = ImageName,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    EditUser = "",
                    IsActive = true,
                    IsDelete = false
                };
                masterItemMenu.Add(data);
                return RedirectToAction(nameof(MasterItemMenuIndex));
            }
            catch
            {
                return View();
            }
        }
        // GET: AdminController/Edit/5
        public ActionResult MasterItemMenuEdit(int id)
        {
            var data = masterItemMenu.Find(id);
            var data2 = masterCategoryMenu.View();
            ViewBag.category = data2;
            var result = new MasterItemMenuModels
            {
                MasterItemMenuId = data.MasterItemMenuId,
                MasterItemMenuTitle = data.MasterItemMenuTitle,
                MasterItemMenuBreef = data.MasterItemMenuBreef,
                MasterItemMenuDesc = data.MasterItemMenuDesc,
                MasterItemMenuPrice = data.MasterItemMenuPrice,
                MasterItemMenuDate = data.MasterItemMenuDate,
                MasterCategoryMenuId = data.MasterCategoryMenuId,
                MasterItemMenuImageUrl = data.MasterItemMenuImageUrl,
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
        public async Task<ActionResult> MasterItemMenuEdit(int id, MasterItemMenuModels collection)
        {
            try
            {

                var user = await userManager.FindByNameAsync(User.Identity.Name);
                string ImageName = UploadFile(collection.File);
                var data = new MasterItemMenu
                {
                    MasterItemMenuId = collection.MasterItemMenuId,
                    MasterItemMenuTitle = collection.MasterItemMenuTitle,
                    MasterItemMenuBreef = collection.MasterItemMenuBreef,
                    MasterItemMenuDesc = collection.MasterItemMenuDesc,
                    MasterItemMenuPrice = collection.MasterItemMenuPrice,
                    MasterItemMenuDate = collection.MasterItemMenuDate,
                    MasterCategoryMenuId = collection.MasterCategoryMenuId,
                    MasterItemMenuImageUrl = (ImageName != "") ? ImageName : collection.MasterItemMenuImageUrl,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    EditDate = DateTime.Now,
                    IsActive = collection.IsActive,
                };
                masterItemMenu.Update(id, data);
                return RedirectToAction(nameof(MasterItemMenuIndex));
            }
            catch
            {
                return View();
            }
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

        public ActionResult Active(int id)
        {
            masterItemMenu.Active(id, new MasterItemMenu()
            {
                EditDate = DateTime.Now,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(MasterItemMenuIndex));
        }
    }
}
