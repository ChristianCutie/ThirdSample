using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThirdSample.Data;
using ThirdSample.Models;

namespace ThirdSample.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDataContext data;
        public ItemController(ApplicationDataContext db)
        {
            data = db;
        }
        public IActionResult ItemView()
        {
            IEnumerable<Item> objItemList = data.items;
            return View(objItemList);
        }
    }
}