using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace Models
{
    public class Users
    {
        public int Userid { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string MailId { set; get; }
        public string ContactNumber { set; get; }
        public int Role { set; get; }
        public int Status { set; get; }
        public string Password { set; get; } 
    }
}

