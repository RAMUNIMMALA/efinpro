using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace efinpro.Controllers
{
    public class EFinProBaseController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}