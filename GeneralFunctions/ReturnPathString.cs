using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WishCards.GeneralFunctions
{
    #region generate unique file name
    public class ReturnPathString
    {
        public static string ReturnUniqueFileName()
        {
            string filename = Guid.NewGuid().ToString();
            return filename;
        }

    }

    #endregion
}
