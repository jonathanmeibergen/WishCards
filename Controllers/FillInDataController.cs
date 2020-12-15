using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishCards.Enumerations;
using WishCards.Models;
using WishCards.Extensions;
using System.ComponentModel;
using WishCards.Attributes;

namespace WishCards.Controllers
{
    public class FillInDataController : Controller
    {
        // GET: FillInDataController
        public async Task<IActionResult> Index()
        {
            WishCardViewModel cardVM = new WishCardViewModel();
            cardVM.WishCard = new WishCard();
            cardVM.WishCard.Background = BackgroundsEnum.Red;
            return View(cardVM);
        }

        // POST: FillInDataController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection)
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
