using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Repository;
using System.Security.Claims;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterMenuController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IRepository<MasterMenu> masterMenu;

        public MasterMenuController(UserManager<AppUser> _userManager, IRepository<MasterMenu> _masterMenu)
        {
            userManager = _userManager;
            masterMenu = _masterMenu;
        }
        public async Task<ActionResult> MasterMenuIndex(int idDelete)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            if (idDelete != 0)
            {
                var data = masterMenu.Find(idDelete);
                MasterMenu obj = new MasterMenu
                {
                    EditDate = DateTime.Now,
                    EditUser = user.Id,
                };
                masterMenu.Delete(idDelete, obj);
                return RedirectToAction(nameof(MasterMenuIndex));
            }
            var data2 = masterMenu.View();
            return View(data2);
        }
        // GET: AdminController/Create
        public ActionResult MasterMenuCreate()
        {
            return View();
        }
        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MasterMenuCreate(MasterMenu collection)
        {
            try
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                collection.CreateUser = user.Id;
                collection.CreateDate = DateTime.Now;
                collection.EditUser = "";
                collection.IsActive = true;
                collection.IsDelete = false;
                masterMenu.Add(collection);
                return RedirectToAction(nameof(MasterMenuIndex));
            }
            catch
            {
                return View();
            }
        }
        // GET: AdminController/Edit/5
        public ActionResult MasterMenuEdit(int id)
        {
            var data = masterMenu.Find(id);
            return View(data);
        }
        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MasterMenuEdit(int id, MasterMenu collection)
        {
            try
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                collection.EditUser = user.Id;
                collection.EditDate = DateTime.Now;
                masterMenu.Update(id, collection);
                return RedirectToAction(nameof(MasterMenuIndex));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Active(int id)
        {
            masterMenu.Active(id, new MasterMenu()
            {
                EditDate = DateTime.Now,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(MasterMenuIndex));
        }
    }
}
