using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThirdSample.Data;
using ThirdSample.Models;

namespace ThirdSample.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDataContext data;

        public LoginController(ApplicationDataContext db)
        {
            data = db;
        }
        [HttpGet]
        public IActionResult LoginView()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginView(login log)
        {
            if (ModelState.IsValid)
            {
                //Validating the user, whether the user is valid or not.
                var valid = IsValidUser(log);

                if (valid != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Failure", "Wrong Username and password combination !");
                    return View();
                }
            }
            else
            {
                return View(log);
            }
        }
        public login IsValidUser(login lg)
        {
            login lgn = data.logins.Where(x => x.Username.Equals(lg.Username) &&
             (x.Password.Equals(lg.Password))).SingleOrDefault();
            if (lgn == null)
                return null;
            //If user is not present false is returned.
            else
                return lgn;
        }
    }
}