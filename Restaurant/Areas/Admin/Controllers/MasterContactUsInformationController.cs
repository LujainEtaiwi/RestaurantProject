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
    public class MasterContactUsInformationController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IRepository<MasterContactUsInformation> masterContactUsInformation;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting;

        public MasterContactUsInformationController(UserManager<AppUser> _userManager, IRepository<MasterContactUsInformation> _MasterContactUsInformation, Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting)
        {
            userManager = _userManager;
            masterContactUsInformation = _MasterContactUsInformation;
            hosting = _hosting;
        }
        public async Task<ActionResult> MasterContactUsInformationIndex(int idDelete)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            if (idDelete != 0)
            {
                var data = masterContactUsInformation.Find(idDelete);
                MasterContactUsInformation obj = new MasterContactUsInformation
                {
                    EditDate = DateTime.Now,
                    EditUser = user.Id,
                };
                masterContactUsInformation.Delete(idDelete, obj);
                return RedirectToAction(nameof(MasterContactUsInformationIndex));
            }
            var data2 = masterContactUsInformation.View();
            return View(data2);
        }
        // GET: AdminController/Create
        public ActionResult MasterContactUsInformationCreate()
        {
            return View();
        }
        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MasterContactUsInformationCreate(MasterContactUsInformationModels collection)
        {
            try
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);

                var data = new MasterContactUsInformation
                {
                    MasterContactUsInformationId = collection.MasterContactUsInformationId,
                    MasterContactUsInformationIdesc = collection.MasterContactUsInformationIdesc,
                    MasterContactUsInformationRedirect = collection.MasterContactUsInformationRedirect,
                    MasterContactUsInformationImageUrl = collection.MasterContactUsInformationImageUrl,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    EditUser = "",
                    IsActive = true,
                    IsDelete = false
                };
                masterContactUsInformation.Add(data);
                return RedirectToAction(nameof(MasterContactUsInformationIndex));
            }
            catch
            {
                return View();
            }
        }
        // GET: AdminController/Edit/5
        public ActionResult MasterContactUsInformationEdit(int id)
        {
            var data = masterContactUsInformation.Find(id);
            var result = new MasterContactUsInformationModels
            {
                MasterContactUsInformationId = data.MasterContactUsInformationId,
                MasterContactUsInformationIdesc = data.MasterContactUsInformationIdesc,
                MasterContactUsInformationRedirect = data.MasterContactUsInformationRedirect,
                MasterContactUsInformationImageUrl = data.MasterContactUsInformationImageUrl,
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
        public async Task<ActionResult> MasterContactUsInformationEdit(int id, MasterContactUsInformationModels collection)
        {
            try
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);

                string ImageName = UploadFile(collection.File);
                var data = new MasterContactUsInformation
                {
                    MasterContactUsInformationId = collection.MasterContactUsInformationId,
                    MasterContactUsInformationIdesc = collection.MasterContactUsInformationIdesc,
                    MasterContactUsInformationRedirect = collection.MasterContactUsInformationRedirect,
                    MasterContactUsInformationImageUrl = collection.MasterContactUsInformationImageUrl,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    EditDate = DateTime.Now,
                    IsActive = collection.IsActive
                };
                masterContactUsInformation.Update(id, data);
                return RedirectToAction(nameof(MasterContactUsInformationIndex));
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
            masterContactUsInformation.Active(id, new MasterContactUsInformation()
            {
                EditDate = DateTime.Now,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(MasterContactUsInformationIndex));
        }
    }
}
