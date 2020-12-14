using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishCards.Models;

namespace WishCards.Interfaces
{
    #region interface used for dependency inversion
    public interface IdataService
    {
        bool AddRecipient(Recipient recipient);
        bool AddSender(SenderData sender);
        bool AddWishCard(WishCard card);
        bool RemoveRecipient(string id);
        bool RemoveSender(string id);
        bool RemovewishCard(string id);
        List<Recipient> ReturnAllRecipients();
        List<SenderData> ReturnSenders();
        List<WishCard> ReturnWishCards();
        Recipient FindRecipient(string id);
        SenderData FindSender(string id);
        WishCard FindWishcard(string id);
    }

    #endregion
}
