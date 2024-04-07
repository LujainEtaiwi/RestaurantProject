using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.Repository;
using Restaurant.Models;
using Microsoft.AspNetCore.Authorization;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TransactionNewsletterController : Controller
    {
        private readonly IRepository<TransactionNewsletter> transactionNewsletter;

        public TransactionNewsletterController(IRepository<TransactionNewsletter> _TransactionNewsletter)
        {
            transactionNewsletter = _TransactionNewsletter;
        }
        public ActionResult TransactionNewsletterIndex()
        {
            var data = transactionNewsletter.View();
            return View(data);
        }
    }
}
