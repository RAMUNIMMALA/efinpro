using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using DataAccess;

namespace efinpro.Controllers
{
    public class HomeController : EFinProBaseController
    {
        DA_Users _daUsers = null;
        Users _users = null;
        String UserMailID = null;
        string Password = null;
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SignIn()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Users _userdetails)
        {
            _daUsers = new DA_Users();
            try
            {
                UserMailID = _userdetails.MailID;
                Password = _userdetails.Password;
                _users = _daUsers.VerifyUserLogin(UserMailID, Password);
                Session["userdata"] = _users;
            }
            catch (Exception ex)
            {
                ViewBag.alertMessage = ErrorMessage;
            }
            return View("Dashboard");
        }
    }
}
