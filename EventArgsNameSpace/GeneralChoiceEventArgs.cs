using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WishCards.EventArgsNameSpace
{
    #region eventargs for use base eventhandler
    public class GeneralChoiceEventArgs : EventArgs
    {
        public int value { get; set; }
    }

    #endregion
}
