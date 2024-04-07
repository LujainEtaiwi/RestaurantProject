using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.Repository;
using Restaurant.Models;
using System.Security.Claims;
using Restaurant.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ReviewController : Controller
    {
        private readonly IRepository<Review> review;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting;

        public ReviewController(IRepository<Review> _Review, Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting)
        {
            review = _Review;
            hosting = _hosting;
        }
        // GET: ReviewController
        public ActionResult Index(int idDelete)
        {
            if (idDelete != 0)
            {
                var data = review.Find(idDelete);
                Review obj = new Review
                {
                    EditDate = DateTime.Now,
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
                };
                review.Delete(idDelete, obj);
                return RedirectToAction(nameof(Index));
            }
            var data2 = review.View();
            return View(data2);
        }


        // GET: ReviewController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReviewController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReviewModel collection)
        {
            try
            {
                string ImageName = UploadFile(collection.File);
                var data = new Review
                {
                    ReviewId = collection.ReviewId,
                    ReviewTitle = collection.ReviewTitle,
                    ReviewDesc = collection.ReviewDesc,
                    ReviewImage = ImageName,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    CreateDate = DateTime.Now,
                    EditUser = "",
                    IsActive = true,
                };
                review.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReviewController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = review.Find(id);
            var result = new ReviewModel
            {
                ReviewId = data.ReviewId,
                ReviewTitle = data.ReviewTitle,
                ReviewDesc = data.ReviewDesc,
                ReviewImage = data.ReviewImage,
                CreateUser = data.CreateUser,
                CreateDate = data.CreateDate,
                IsActive = data.IsActive
            };
            return View(result);
        }

        // POST: ReviewController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ReviewModel collection)
        {
            try
            {
                string ImageName = UploadFile(collection.File);
                var data = new Review
                {
                    ReviewId = collection.ReviewId,
                    ReviewTitle = collection.ReviewTitle,
                    ReviewDesc = collection.ReviewDesc,
                    ReviewImage = (ImageName != "") ? ImageName : collection.ReviewImage,
                    EditDate = DateTime.Now,
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    IsActive = collection.IsActive,
                };
                return RedirectToAction(nameof(Index));
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
            review.Active(id, new Review()
            {
                EditDate = DateTime.Now,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }
    }
}
