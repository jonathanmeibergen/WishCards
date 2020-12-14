using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WishCards.Enumerations
{
    #region FontsUsed
    public enum FontsEnum
    {
        Courier,
        [Display(Name = "Times New Roman")]
        TimesNewRoman,
        Helvetica
    }

    #endregion
}
