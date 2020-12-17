using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishCards.Models;

namespace WishCards.ViewModel
{
    #region viewmodel

    public class SenderAndRecieverFivePersonsMultipleChoice
    {
        public SenderData sender { get; set; }

        public Recipient Recipient1 { get; set; }

        public Recipient Recipient2 { get; set; }

        public Recipient Recipient3 { get; set; }

        public Recipient Recipient4 { get; set; }

        public Recipient Recipient5 { get; set; }

        public string WrongDataInputError { get; set; }

        public string GeneralError {get;set;}
    }

    #endregion
}
