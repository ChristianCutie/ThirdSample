using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThirdSample.Data;
using ThirdSample.Models.ViewModel;

namespace ThirdSample.Controllers
{
    public class InstrumentController : Controller

    {
        [BindProperty]
        public InstrumentViewModel InstrumentVM { get; set; }
        private readonly IWebHostEnvironment _hostenvironment;
        private readonly ApplicationDataContext data;
        public InstrumentController(ApplicationDataContext db, IWebHostEnvironment hostenvironment)
        {
            data = db;
            _hostenvironment = hostenvironment;
            InstrumentVM = new InstrumentViewModel()
            {
                Items = data.items.ToList(),
                Types = data.types.ToList(),
                Instrument = new Models.Instrument()
            };
        }
        [HttpGet]
        public IActionResult InstrumentView()
        {
            var instru = data.instruments.Include(x => x.Item).Include(x => x.Type);
            return View(instru);
        }
        private void Saved()
        {
            var instrumentID = InstrumentVM.Instrument.Id;
            string rootpath = _hostenvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var save = data.instruments.Find(instrumentID);

            if (files.Count() != 0)
            {
                var imagepath = @"image\AllImages\";
                var extn = Path.GetExtension(files[0].FileName);
                var relativeimgPath = imagepath + instrumentID + extn;
                var AbsPathImage = Path.Combine(rootpath, relativeimgPath);

                using (var FileStreams = new FileStream(AbsPathImage, FileMode.Create))
                {
                    files[0].CopyTo(FileStreams);
                }
                save.imgpath = relativeimgPath;
            }
        }
        [HttpGet]
        public IActionResult EditView(int ID)
        {
            InstrumentVM.Instrument = data.instruments.Include(x => x.Item).Include(x => x.Type).SingleOrDefault(x => x.Id == ID);

            if (InstrumentVM.Instrument == null)
            {
                return NotFound();
            }
            return View(InstrumentVM);
        }
        [HttpPost]
        [ActionName("EditView")]
        public IActionResult EditViewPost()
        {
            if (ModelState.IsValid)
            { 
                data.Update(InstrumentVM.Instrument);
                Saved();
                data.SaveChanges();  
                return RedirectToAction("InstrumentView");
            }
            return View(InstrumentVM);
        }
        [HttpGet]
        public IActionResult InsCreateView()
        {
            return View(InstrumentVM);
        }
        [HttpPost] 
        [ActionName("InsCreateView")]
        public IActionResult InsCreateViewPost()
        {
            if (ModelState.IsValid)
            {
                data.instruments.Add(InstrumentVM.Instrument);
                data.SaveChanges();

                var instrumentID = InstrumentVM.Instrument.Id;
                string rootpath = _hostenvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                var save = data.instruments.Find(instrumentID);

                if (files.Count() != 0)
                {
                    var imagepath = @"image\AllImages\";
                    var extn = Path.GetExtension(files[0].FileName);
                    var relativeimgPath = imagepath + instrumentID + extn;
                    var AbsPathImage = Path.Combine(rootpath, relativeimgPath);

                    using (var FileStreams = new FileStream(AbsPathImage, FileMode.Create))
                    {
                        files[0].CopyTo(FileStreams);
                    }
                    save.imgpath = relativeimgPath;
                    data.SaveChanges();
                }
                return RedirectToAction("InstrumentView");

            }
            return View(InstrumentVM);
        }
        [HttpPost]
        [ActionName("DeleteView")]
        public IActionResult DeleteViewPost(int ID)
        {
            var del = data.instruments.Find(ID);
            if (del == null)
            {
                return NotFound();
            }
            data.instruments.Remove(del);
            data.SaveChanges();
            return RedirectToAction("InstrumentView");
        }
    }
}