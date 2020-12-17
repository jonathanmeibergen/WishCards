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
using WishCards.Data;
using WishCards.DAL;
using System.IO;
using Microsoft.EntityFrameworkCore;
using WishCards.Users;

namespace WishCards.Controllers
{
    public class WishCardController : Controller
    {
        private ApplicationDbContext _context;
        private IWishCardDbData _cards;

        public WishCardController(ApplicationDbContext context, IWishCardDbData cards)
        {
            _context = context;
            _cards = cards;
        }

        // GET: Recipients
        public async Task<IActionResult> Index()
        {
            return View(await _context.WishCards.ToListAsync());
        }

        // GET: FillInDataController
        public async Task<IActionResult> Create()
        {
            WishCardViewModel cardVM = new WishCardViewModel();
            cardVM.WishCard = new WishCard();
            cardVM.WishCard.Author = new ApplicationUser();
            cardVM.WishCard.Background = BackgroundsEnum.Red;
            return View(cardVM);
        }

        // POST: FillInDataController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection)
        {

            //return RedirectToAction(nameof(Index));
            ICollection<string> keys = collection.Keys;

            WishCard wishCard = new WishCard()
            {
                Author = (Users.ApplicationUser)_context
                    .Users
                    .FirstOrDefault(u =>
                                    u.UserName == HttpContext.User.Identity.Name),

                Text = collection[keys.Select(k => k)
                                      .Where(v =>
                                             v.Contains("Text"))
                                              .FirstOrDefault()],

                TextColor = (ColorsEnum)Enum.Parse(typeof(ColorsEnum),
                                                   collection[keys
                                                                  .Where(v =>
                                                                         v.Contains("Color"))
                                                                          .FirstOrDefault()]),

                TypeFace = (TypeFacesEnum)Enum.Parse(typeof(TypeFacesEnum),
                                                     collection[keys
                                                                    .Where(v =>
                                                                           v.Contains("Type"))
                                                                            .FirstOrDefault()]),

                Background = (BackgroundsEnum)Enum.Parse(typeof(BackgroundsEnum),
                                              Path.GetFileNameWithoutExtension(collection[keys
                                                                                              .Where(v =>
                                                                                                     v.Contains("Background"))
                                                                                                      .FirstOrDefault()])),

                Recipients = collection[keys.Where(k => 
                                                   k.Contains("Comma"))
                                                   .FirstOrDefault()].ToString()
                                                                     .Split(";")
                                                                     .ToList<string>()
                                                                     .Select(r => 
                                                                             new Recipient { Email = r.ToString(), Id = Guid.NewGuid() }).ToList()
            };

            wishCard = _cards.Create(wishCard);
            _cards.Commit(wishCard.Id);
            return View();
        }

 
    }
}
