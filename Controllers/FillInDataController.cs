using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WishCards.Controllers
{
    public class FillInDataController : Controller
    {
        // GET: FillInDataController
        public ActionResult FillInData()
        {
            return View();
        }

        // POST: FillInDataController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FillInData(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

 
    }
}
