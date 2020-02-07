using DataAccess;
using Models;
using System;
using System.Web.Mvc;

namespace efinpro.Controllers
{
    public class HomeController : EFinProBaseController
    {
        private DA_Users _daUsers = null;
        private Users _users = null;

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
            string returnAction = null;
            string returnController = null;
            _daUsers = new DA_Users();
            try
            {                
                _users = _daUsers.VerifyUserLogin(_userdetails.MailID, _userdetails.Password);                
                if(_users!=null && ModelState.Count>0)
                {
                    if(_users.Status)
                    {
                        Session["userdata"] = _users;
                        returnAction="Dashboard";
                        returnController = "Home";
                    }
                    else
                    {
                        ViewBag.Login = "Invalid Credentials";
                        returnAction = "Index";
                        returnController = "Home";
                    }
                }
                else
                {
                    ViewBag.Login = "Invalid Credentials";
                }
            }
            catch (Exception ex)
            {
                ViewBag.alertMessage = ErrorMessage;
            }
            return RedirectToAction(returnAction, returnController);
        }
    }
}

