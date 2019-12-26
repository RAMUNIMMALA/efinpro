using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace efinpro.Controllers
{
    public class UserController : EFinProBaseController
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewUser()
        {
            return View();
        }

    }
}