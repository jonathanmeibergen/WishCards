using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WishCards.Enumerations;
using WishCards.Models;

namespace WishCards.ViewModel
{
    #region viewmodel

    public class SenderAndRecieversTwoPersonsSingleChoice
    {
        [Display(Name = "Mp3 choice")]
        public Mp3Enum GeneralMp3Choice { get; set; }

        [Display(Name = "Background choice")]
        public BackgroundImageEnum GeneralBackgroundImageChoice { get; set; }

        [Display(Name = "Font choice")]
        public FontsEnum GeneralFontChoice { get; set; }

        public SenderData sender { get; set; }

        public Recipient Recipient1 { get; set; }

        public Recipient Recipient2 { get; set; }

        public string WrongDataInputError { get; set; }

        public string GeneralError { get; set; }

        //public string StoreFirstNameFirstPerson { get; set; }

        //public string StoreLastNameFirstPerson { get; set; }

        //public string StoreEmailFirstperson { get; set; }

        //public string StoreCardChoiceFirstPerson { get; set; }

        //public string StoreFirstNameSecondPerson { get; set; }

        //public string StoreLastNameSecondPerson { get; set; }

        //public string StoreEmailSecondperson { get; set; }

        //public string StoreCardChoiceSecondPerson { get; set; }



    }

    #endregion
}
