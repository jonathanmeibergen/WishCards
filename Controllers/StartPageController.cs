using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WishCards.Controllers
{
    public class StartPageController : Controller
    {
        #region startingPage
        public IActionResult StartPage()
        {
            return View();
        }

        #endregion
    }
}
