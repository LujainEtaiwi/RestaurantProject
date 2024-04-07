using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.Repository;
using Restaurant.Models;
using Microsoft.AspNetCore.Authorization;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TransactionContactUsController : Controller
    {
        private readonly IRepository<TransactionContactUs> transactionContactUs;

        public TransactionContactUsController(IRepository<TransactionContactUs> _TransactionContactUs)
        {
            transactionContactUs = _TransactionContactUs;
        }
        public ActionResult TransactionContactUsIndex()
        {
            var data = transactionContactUs.View();
            return View(data);
        }
    }
}
