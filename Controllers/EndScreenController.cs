using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WishCards.Controllers
{
    public class EndScreenController : Controller
    {
        // GET: EndScreenController
        public ActionResult EndScreen()
        {
            return View();
        }
    }
}
