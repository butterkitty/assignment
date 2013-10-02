using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.LoginModel Model)
        {
            MichelleEntities Context = new MichelleEntities();
            Login login = (from l in Context.Logins where l.Email == Model.Email && l.Password == Model.Password select l).FirstOrDefault();
            if (login != null)
            {
                System.Web.Security.FormsAuthentication.RedirectFromLoginPage(Model.Email, true);
                
            }
            return View();
        }
        public ActionResult Logout()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
