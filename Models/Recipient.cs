using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WishCards.Enumerations;

namespace WishCards.Models
{
    #region reciever of mail model
    public class Recipient
    {
        [Key]
        public string Id { get; set; }
        [Display(Name ="Recipient first name")]
        public string FirstName { get; set; }
        [Display(Name = "Recipient last name")]
        public string LastName { get; set; }
        [EmailAddress]
        [Display(Name = "Recipient email")]
        public string Email { get; set; }
        [Display(Name ="Message font")]
        public FontsEnum StoreFont {get;set; }
        [Display(Name = "Message jingle")]
        public Mp3Enum StoreMp3 { get; set; }
        [Display(Name = "Message background image")]
        public BackgroundImageEnum StoreBackgroundImage { get; set; }
    }

    #endregion
}
