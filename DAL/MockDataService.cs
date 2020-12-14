using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishCards.Interfaces;
using WishCards.Models;

namespace WishCards.DAL
{
    #region mockingOfData
    public class MockDataService :IdataService
    {
        private List<Recipient> _recipients;
        private List<SenderData> _sender;
        private List<WishCard> _Wishcard;

        private static MockDataService _mockDataService;

        private MockDataService()
        {

        }

        public static MockDataService GetMockDataService()
        {
            if (_mockDataService == null)
            {
                _mockDataService = new MockDataService();
                _mockDataService.InitData();
            }
            return _mockDataService;
        }

        private void InitData()
        {
            _recipients = new List<Recipient>()
            {
                new Recipient()
                {
                    Id= Guid.NewGuid().ToString(),
                    Email = "testmail@hotmail.com",
                    FirstName = "test",
                    LastName = "test"                     
                }
            };

            _sender = new List<SenderData>()
            {
                new SenderData()
                {
                 Id = Guid.NewGuid().ToString(),                 
                }
            };

            _Wishcard = new List<WishCard>()
            {
             new WishCard()
              {
                 Id = Guid.NewGuid().ToString()
              }
            };

        }

        public bool AddRecipient(Recipient recipient)
        {
            _recipients.Add(recipient);
            return true;
        }

        public bool AddSender(SenderData sender)
        {
            _sender.Add(sender);
            return true;
        }

        public bool AddWishCard(WishCard card)
        {
            _Wishcard.Add(card);
            return true;
        }

        public bool RemoveRecipient(string id)
        {
            Recipient recipient = _recipients.FirstOrDefault(a => a.Id == id);
            _recipients.Remove(recipient);
            return true;
        }

        public bool RemoveSender(string id)
        {
            SenderData sender = _sender.FirstOrDefault(a => a.Id == id);
            _sender.Remove(sender);
            return true;
        }

        public bool RemovewishCard(string id)
        {
            WishCard card = _Wishcard.FirstOrDefault(a => a.Id == id);
            _Wishcard.Remove(card);
            return true;
        }

        public List<Recipient> ReturnAllRecipients()
        {
            return _recipients;
        }

        public List<SenderData> ReturnSenders()
        {
            return _sender;
        }

        public List<WishCard> ReturnWishCards()
        {
            return _Wishcard;
        }

        public Recipient FindRecipient(string id)
        {
            return _recipients.FirstOrDefault(a => a.Id == id);
        }

        public SenderData FindSender(string id)
        {
            return _sender.FirstOrDefault(a => a.Id == id);
        }

        public WishCard FindWishcard(string id)
        {
            return _Wishcard.FirstOrDefault(a => a.Id == id);
        }
    }

    #endregion
}
