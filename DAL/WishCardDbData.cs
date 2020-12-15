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
    public class WishCardDbData : IWishCardDbData
    {
        private ApplicationDbContext _db;

        public WishCardDbData(ApplicationDbContext db)
        {
            _db = db;
        }
        public WishCard GetById(Guid id)
        {
            return _db.WishCards.FirstOrDefault(w => w.Id == id);
        }

        public List<WishCard> GetByUser(ApplicationUser user)
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

        public WishCard Create(WishCard card)
        {
            if (card is not null)
            {
                var entry = _db.WishCards.Add(card);
                return entry.Entity;
            }
            return null;
        }

        public void Commit(Guid id) => _db.SaveChangesAsync();

        public WishCard Delete(Guid id)
        {
            var card = GetById(id);

            if (card != null)
            {
                _db.WishCards.Remove(card);
            }
            return card;
        }
    }
}
