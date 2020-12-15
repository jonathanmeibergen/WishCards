using System.Collections.Generic;
using WishCards.Models;
using WishCards.Users;

namespace WishCards.DAL
{
    public interface IWishCardDbData
    {
        void Commit();
        WishCard Create(WishCard card);
        WishCard Delete(string id);
        WishCard GetById(string id);
        List<WishCard> GetByUser(ApplicationUser user);
        WishCard Update(WishCard card);
    }
}