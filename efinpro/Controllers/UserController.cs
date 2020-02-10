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
        Users _users = null;

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

        [HttpGet]
        public ActionResult NewUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewUser(Users user)
        {
            _dausers = new DA_Users();
            try
            {
                _users = _dausers.CreateUser(user);
                if (_users != null)
                {
                    ViewBag.SuccessMessage = "User registered successfully";
                }
                else
                {
                    ViewBag.alertMessage = "Something went wrong";
                }
            }
            catch (Exception ex)
            {
               ViewBag.alertmessage = ErrorMessage;
            }
            return View("Index");
        }
    }
}
