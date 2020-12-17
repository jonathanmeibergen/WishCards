using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WishCards.Enumerations;
using WishCards.Users;

namespace WishCards.Models
{
    #region christmas card model
    public class WishCard
    {

        [Key]
        public string Id { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public virtual Recipient Recipients { get; set; }
        public SenderData sender { get; set; }
        public TypeFacesEnum TypeFace { get; set; }
        public string Text { get; set; }
        public string ImagePath { get; set; }
        public BackgroundImageEnum background { get; set; }
        public Mp3Enum mp3 { get; set; }
        public FontsEnum font { get; set; }
        public ColorsEnum TextColor { get; set; }
        public BackgroundsEnum Background { get; set; }

    }

    #endregion
}
