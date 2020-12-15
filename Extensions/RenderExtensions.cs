using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WishCards.Extensions
{
    public static class RenderExtensions
    {
        public static IEnumerable<SelectListItem>
           GetSelectListFor<T>(this IEnumerable<T> collection)
        {
            List<SelectListItem> selectListItems = collection.Select(n => new SelectListItem 
                { 
                    Value = n.ToString(), 
                    Text = n.ToString()
                }).ToList();
            var emptyField = new SelectListItem()
            {
                Value = "0",
                Text = "--- Choose ---"
            };
            selectListItems.Insert(0, emptyField);
            return new SelectList(selectListItems, "Value", "Text");
        }
    }
}
