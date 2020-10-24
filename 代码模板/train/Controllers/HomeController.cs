using osms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace osms.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {


            return Redirect("/www/Login3.html");
        }
        [HttpGet]
        public ActionResult Login(string username,string pwd)
        {
            using (fashionshoppingDBEntities db = new fashionshoppingDBEntities())
            {
                
                    var sysu = db.Sysuser.SingleOrDefault(d => d.username == username && d.pwd == pwd);
                    if (sysu != null)
                    {
                        return Content("0000");
                    }
                    else
                    {
                        return Content("1101");
                    }
            }
        }
    }
}
