using System;
using System.Collections.Generic;
using WishCards.Models;
using WishCards.Users;

namespace WishCards.DAL
{
    public interface IWishCardDbData
    {
        void Commit(Guid id);
        WishCard Create(WishCard card);
        WishCard Delete(Guid id);
        WishCard GetById(Guid id);
        List<WishCard> GetByUser(ApplicationUser user);
        WishCard Update(WishCard card);
    }
}