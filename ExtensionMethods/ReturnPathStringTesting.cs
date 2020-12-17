using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WishCards.ExtensionMethods
{
    public static class ReturnPathStringTesting
    {
        #region testing extension method
        public static Task<List<int?>> Working<T>(this GeneralFunctions.ReturnPathString returnpath, Action<T, T>? execution, Task<List<int?>> checkingvalues) where T : ICloneable
        {
            checkingvalues.Result.Add(execution?.Method.Name.Length ?? 0);
            checkingvalues.
                Result.
                GroupBy(a => a.Value).
                AsParallel().
                DefaultIfEmpty().
                OrderByDescending(a => a.Key).
                Reverse().
                Distinct().
                Cast<T>().
                Where(a => a.GetType() == typeof(int?));

            return Task.Run(() =>
            {
                return checkingvalues;
            });
        }

        #endregion
    }
}
