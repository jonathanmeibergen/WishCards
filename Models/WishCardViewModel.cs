using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        public string Description { get => "We wish You a Merry Christmas and a Happy New Year"; set { } }
        public string ImageName { 
            get {
                return $"{WishCard.Background}.{WishCard.Background.GetAttributeValue<FileTypeAttribute, string>(a => a.FileType)}";
            } 
        }

        [Required]
        [DisplayName("Recipient Email Addresses")]
        public string RecipientsCommaSeparated { 
            get
            {
                return string.Join(",", WishCard.Recipients.ToList());
            } 
        }

        //special case since the values of background needs the filetype added in the value attribute of <option> html tag
        public IEnumerable<SelectListItem> BackgroundSelectItems { 
            get {
                List<BackgroundsEnum> enumValues = Enum.GetValues<BackgroundsEnum>().ToList();
                List<SelectListItem> selectListItems = enumValues.Select(n => new SelectListItem
                {
                    Value = $"{n}.{n.GetAttributeValue<FileTypeAttribute, string>(a => a.FileType)}",
                    Text = n.ToString()
                }).ToList();
                return new SelectList(selectListItems, "Value", "Text");
            }
        }

    }
}
