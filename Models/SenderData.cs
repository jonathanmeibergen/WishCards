using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WishCards.Models
{
    #region sender data
    public class SenderData
    {
        [Key]
        public string Id { get; set; }

        [Display(Name ="Sender first name")]
        public string firstname { get; set; }

        [Display(Name = "Sender addition")]
        public string addition { get; set; }

        [Display(Name = "Sender last name")]
        public string lastname { get; set; }

        [EmailAddress]
        [Display(Name = "Sender email")]
        public string emailadress { get; set; }

        [Display(Name = "Message to show on greeting card")]
        public string messagetoshow { get; set; }
    }

    #endregion
}
