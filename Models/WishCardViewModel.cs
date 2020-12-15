using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishCards.Attributes;
using WishCards.Enumerations;
using WishCards.Extensions;

namespace WishCards.Models
{
    public class WishCardViewModel
    {
        public WishCard WishCard { get; set; }
        public string ImageName { 
            get {
                return $"{this.WishCard.Background}.{this.WishCard.Background.GetAttributeValue<FileTypeAttribute, string>(a => a.FileType)}";
            } 
        }

    }
}
