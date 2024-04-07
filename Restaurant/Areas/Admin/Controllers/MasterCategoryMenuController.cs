using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.Repository;
using Restaurant.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterCategoryMenuController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IRepository<MasterCategoryMenu> masterCategoryMenu;

        public MasterCategoryMenuController(UserManager<AppUser> _userManager, IRepository<MasterCategoryMenu> _MasterCategoryMenu)
        {
            userManager = _userManager;
            masterCategoryMenu = _MasterCategoryMenu;
        }
        public ActionResult MasterCategoryMenuIndex(int idDelete)
        {

            //var user = await userManager.FindByNameAsync(User.Identity.Name);
            if (idDelete != 0)
            {
                var data = masterCategoryMenu.Find(idDelete);
                MasterCategoryMenu obj = new MasterCategoryMenu
                {
                    EditDate = DateTime.Now,
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
                };
                masterCategoryMenu.Delete(idDelete, obj);
                return RedirectToAction(nameof(MasterCategoryMenuIndex));
            }
            var data2 = masterCategoryMenu.View();
            return View(data2);
        }

        // GET: AdminController/Create
        public ActionResult MasterCategoryMenuCreate()
        {
            return View();
        }
        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MasterCategoryMenuCreate(MasterCategoryMenu collection)
        {
            try
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                collection.CreateUser = user.Id;
                collection.CreateDate = DateTime.Now;
                collection.EditUser = "";
                collection.IsActive = true;
                collection.IsDelete = false;
                masterCategoryMenu.Add(collection);
                return RedirectToAction(nameof(MasterCategoryMenuIndex));
            }
            catch
            {
                return View();
            }
        }
        // GET: AdminController/Edit/5
        public ActionResult MasterCategoryMenuEdit(int id)
        {
            var data = masterCategoryMenu.Find(id);
            return View(data);
        }
        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MasterCategoryMenuEdit(int id, MasterCategoryMenu collection)
        {
            try
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                collection.EditUser = user.Id;
                collection.EditDate = DateTime.Now;
                masterCategoryMenu.Update(id, collection);
                return RedirectToAction(nameof(MasterCategoryMenuIndex));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Active(int id)
        {
            masterCategoryMenu.Active(id, new MasterCategoryMenu()
            {
                EditDate = DateTime.Now,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(MasterCategoryMenuIndex));
        }
    }
}
