using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace WishCards.GeneralFunctions
{
    #region deepclone of reference values
    public static class DeepCloning
    {
        public static T DeepClone<T>(this T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                formatter.Serialize(ms, obj);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
                ms.Position = 0;

#pragma warning disable SYSLIB0011 // Type or member is obsolete
                return (T)formatter.Deserialize(ms);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
            }
        }
    }
    #endregion
}
