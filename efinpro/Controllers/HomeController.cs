using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using DataAccess;
using System.Collections;

namespace efinpro.Controllers
{
    public class HomeController : EFinProBaseController
    {
        DA_Users _daUsers = null;
        Users _users = null;
        String UserMailID = null;
        string Password = null;
        string returnAction = null;
        string returnController = null;
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
                if(_users!=null)
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
