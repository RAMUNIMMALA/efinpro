﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Models;
using System.Text;
using DataAccess;

namespace efinpro.Controllers
{
    public class UserController : EFinProBaseController
    {
        DA_User _dauser = null;
        User _user = null;
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult NewUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewUser(User user,FormCollection form,HttpPostedFileBase file)
        {
            try
            {
                _dauser = new DA_User();
                _user = new User();
                _user = _dauser.CreateUser(user);
            }
            catch (Exception ex)
            {
                ViewBag.alertmessage = ErrorMessage;
            }
            return View("Index");
        }       
    }
}
