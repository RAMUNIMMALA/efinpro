using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;
using PagedList.Mvc;
using System.Web.Mvc;
using Models;
using DataAccess;

namespace efinpro.Controllers
{
    public class UserController : EFinProBaseController
    {
        DA_Users _dausers = null;
        List<Users> users = null;
    
        // GET: Active User List
        public ActionResult Index(int? page)
        {            
            try
            {
                _dausers = new DA_Users();
                users = _dausers.GetUsers();
            }
            catch (Exception ex)
            {
                ViewBag.alertMessage = ErrorMessage;
            }
            return View(users.ToList().ToPagedList(page ?? 1,5));   
        }
        public ActionResult NewUser()
        {
            return View();
        }
    }
}
