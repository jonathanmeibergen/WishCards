using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WishCards.Enumerations
{
    #region backgroundimages
    public enum BackgroundImageEnum
    {
        [Display(Name = "Background 1")]
        Background1,
        [Display(Name = "Background 2")]
        Background2,
        [Display(Name = "Background 3")]
        Background3
    }

    #endregion
}
