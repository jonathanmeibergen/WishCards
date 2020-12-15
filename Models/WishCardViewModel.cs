using Microsoft.AspNetCore.Mvc.Rendering;
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
        public string Description { get => "We wish you a a Merry Christmas and a happy New Year"; set { } }
        public WishCard WishCard { get; set; }
        public string ImageName { 
            get {
                return $"{this.WishCard.Background}.{this.WishCard.Background.GetAttributeValue<FileTypeAttribute, string>(a => a.FileType)}";
            } 
        }

        public IEnumerable<SelectListItem> BackgroundSelectItems { 
            get {
                List<BackgroundsEnum> enumValues = Enum.GetValues<BackgroundsEnum>().ToList();
                List<SelectListItem> selectListItems = enumValues.Select(n => new SelectListItem
                {
                    Value = $"{n}.{n.GetAttributeValue<FileTypeAttribute, string>(a => a.FileType)}",
                    Text = n.ToString()
                }).ToList();
                var emptyField = new SelectListItem()
                {
                    Value = "0",
                    Text = "--- Choose ---"
                };
                selectListItems.Insert(0, emptyField);
                return new SelectList(selectListItems, "Value", "Text");
            }
        }

        public WishCardViewModel()
        {
            Description = "We wish you a Merry Christmas and a happy New Year";
        }

    }
}
