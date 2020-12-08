using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WishCards.Enumerations;

namespace WishCards.Models
{
    public class WishCard
    {
        [Key]
        public string Id { get; set; }
        public TypeFacesEnum TypeFace { get; set; }
        public string Text { get; set; }
        public string ImagePath { get; set; }

    }
}
