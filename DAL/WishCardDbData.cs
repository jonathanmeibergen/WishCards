using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishCards.Data;
using WishCards.Models;
using WishCards.Users;

namespace WishCards.DAL
{
    #region actualDataBase
    public class WishCardDbData
    {
        private ApplicationDbContext _db;

        private static WishCardDbData _DataService;

        private WishCardDbData()
        {

        }

        public static WishCardDbData GetDataService()
        {
            if (_DataService == null)
            {
                _DataService = new WishCardDbData();
            }
            return _DataService;
        }

        public WishCardDbData(ApplicationDbContext db)
        {
            _db = db;
        }
        public WishCard GetWishCardById(string id)
        {
            return _db.WishCards.FirstOrDefault(w => w.Id == id);
        }

        public bool AddWishCard(WishCard card)
        {
            _db.WishCards.Add(card);
            return true;
        }

        public List<WishCard> GetWishCardByUser(ApplicationUser user)
        {
            return _db.WishCards.Select(w => w)
                                .Where(w => w.Author.Id == user.Id)
                                .ToList();
        }

        public WishCard Update(WishCard card)
        {
            var entity = _db.WishCards.Attach(card);
            entity.State = EntityState.Modified;
            return entity.Entity;
        }
    }
    #endregion
}
