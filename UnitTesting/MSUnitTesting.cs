using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishCards.CSVToIEnumerableConverters;
using WishCards.Enumerations;

namespace WishCards.UnitTesting
{
    [TestClass]
    public class MSUnitTesting
    {
        [TestMethod]
        [TestCategory("Initalization")]
        [DynamicData(nameof(TestEnums.TestFonts),typeof(TestEnums))]
        public void FontTest(string value)
        {
            List<string> Fontcollection = new List<string>();
            Fontcollection.Add(FontsEnum.Courier.ToString());
            Fontcollection.Add(FontsEnum.Helvetica.ToString());
            Fontcollection.Add(FontsEnum.TimesNewRoman.ToString());
            CollectionAssert.Contains(Fontcollection,value);
        } 
    }
}
