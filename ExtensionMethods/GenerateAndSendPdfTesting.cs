using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WishCards.ExtensionMethods
{
    public static class GenerateAndSendPdfTesting
    {
        #region testing extension method

#nullable enable
        public static Task<List<int?>> Working<T>(this GeneralFunctions.GeneratePdfAndSendToRecipients generatePdfAndSendToRecipients, Action<T, T>? execution, Task<List<int?>> checkingvalues) where T : Attribute
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
#nullable disable

        #endregion

    }
}
