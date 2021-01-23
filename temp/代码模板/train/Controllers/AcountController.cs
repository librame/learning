using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using osms.Models;
namespace osms.Controllers
{
    public class AcountController : ApiController
    {
        [HttpPost]
        public string GetLogin([FromBody]LoginModel model)
        {
            //var username = forms["username"];
            //var password = forms["password"];

            using (osms1Entities1 db = new osms1Entities1())
            {
                var user = db.UserInfos.SingleOrDefault(u => u.UserName == model.Username);
                if (user != null && user.Password == model.Password)
                {
                    return "0000";
                }
                else
                {
                    return "1101";
                }
            }
        }
    }
}
