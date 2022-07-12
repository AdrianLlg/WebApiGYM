using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Controllers.Login.Models
{
    public class LoginDataRequest
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}