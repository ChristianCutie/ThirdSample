using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThirdSample.Data;
using ThirdSample.Models.ViewModel;

namespace ThirdSample.Controllers
{
    public class TypeController : Controller
    {
        private readonly ApplicationDataContext data;
        [BindProperty]
        public TypeViewModel TypeVM { get; set; }
        public TypeController(ApplicationDataContext db)
        {
            data = db;
            TypeVM = new TypeViewModel()
            {
                Items = data.items.ToList(),
                Type = new Models.Type()
            };
            
        }
        [HttpGet]
        public IActionResult TypeView()
        {
            var type = data.types.Include(x=>x.Item);
            return View(type);
        }
        [HttpGet]
          public IActionResult CreateView()
        {
            return View(TypeVM);
        }
        [HttpPost]
        [ActionName("CreateView")]
          public IActionResult CreateViewPost()
        {
            if(ModelState.IsValid)
            {
                data.types.Add(TypeVM.Type);
                data.SaveChanges();
                return RedirectToAction("TypeView");
           
            }  
            return View(TypeVM);
        }
    }
}