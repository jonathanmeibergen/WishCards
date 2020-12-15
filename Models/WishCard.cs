using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WishCards.Enumerations;
using WishCards.Users;

namespace WishCards.Models
{
    public class WishCard
    {

        [Key]
        public string Id { get; set; }
        public virtual ApplicationUser Author {get; set;}
        public virtual List<Recipient> Recipients { get; set; }
        public string Text { get; set; }
        public TypeFacesEnum TypeFace { get; set; }
        public ColorsEnum TextColor { get; set; }
        public BackgroundsEnum Background { get; set; }

    }
}
