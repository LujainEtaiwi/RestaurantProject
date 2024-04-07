using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.Repository;
using Restaurant.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TransactionBookTableController : Controller
    {
        private readonly IRepository<TransactionBookTable> transactionBookTable;

        public TransactionBookTableController(IRepository<TransactionBookTable> _TransactionBookTable)
        {
            transactionBookTable = _TransactionBookTable;
        }
        public ActionResult TransactionBookTableIndex()
        {
            var data = transactionBookTable.View();
            return View(data);
        }
      
    }
}
