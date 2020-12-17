using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishCards.Models;

namespace WishCards.ViewModel
{
    #region viewmodel

    public class SenderAndRecieverTwoPersonsMultipleChoice
    {
        public SenderData sender { get; set; }

        public Recipient Recipient1 { get; set; }

        public Recipient Recipient2 { get; set; }

        public string WrongDataInputError { get; set; }

        public string GeneralError { get; set; }

    }

    #endregion
}
