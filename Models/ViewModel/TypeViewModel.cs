using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ThirdSample.Models.ViewModel
{
    public class TypeViewModel
    {
        public Type Type { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public IEnumerable<SelectListItem> selectListItems(IEnumerable<Item>items)
        {
            List<SelectListItem> ItemList = new List<SelectListItem>();
           SelectListItem sleitem = new SelectListItem()
           {
                Text = "Select Item",
                Value = "0"
           };
           ItemList.Add(sleitem);
           foreach(Item itm in items)
           {
             sleitem = new SelectListItem()
             {
                 Text = itm.Name,
                 Value =itm.Id.ToString()
              };
              ItemList.Add(sleitem);
           }
           return ItemList;
        }
    }
}