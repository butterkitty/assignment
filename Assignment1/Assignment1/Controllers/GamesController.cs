using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1.Controllers
{
    public class GamesController : Controller
    {
        //
        // GET: /Games/

        public ActionResult Index()
        {
            //MichelleEntities Context = new MichelleEntities();

            return View();
        }

    }
}
