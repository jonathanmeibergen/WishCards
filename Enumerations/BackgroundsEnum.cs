using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using WishCards.Attributes;

namespace WishCards.Enumerations
{
    public enum BackgroundsEnum
    {
        [FileType("webp")]
        Rudolph,
        [FileType("jpg")]
        Christmastree,
        [FileType("jpg")]
        Green,
        [FileType("jpg")]
        Red,
        [FileType("jpg")]
        Wood
    }
}
