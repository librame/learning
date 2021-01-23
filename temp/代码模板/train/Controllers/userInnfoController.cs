using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using osms.Models;
namespace osms.Controllers
{
    public class UserInnfoController : ApiController
    {
        //[HttpPost]
        //public string GetLogin(System.Web.Mvc.FormCollection forms)
        //{
        //    var username = forms["username"];
        //    var password = forms["password"];

        //    using (osms1Entities1 db = new osms1Entities1())
        //    {
        //        var user = db.UserInfos.SingleOrDefault(u => u.UserName == username);
        //        if (user != null && user.Password == password)
        //        {
        //            return "0000";
        //        }
        //        else
        //        {
        //            return "1101";
        //        }
        //    }
        //}
        //查询表信息
        // GET: api/userInnfo
        public string Get()
        {
            using (osms1Entities1 db=new osms1Entities1())
            {
                var user= db.UserInfos.ToList();
                return JsonConvert.SerializeObject(user);
            }
        }
        //根据ID修改
        // GET: api/userInnfo/5
        public void Get(int id)
        {
            using (osms1Entities1 db = new osms1Entities1())
            {
                var user= db.UserInfos.SingleOrDefault(u=>u.Id==id);
                if (user!=null)
                {
                    user.Password = "123456";
                    db.SaveChanges();
                }
            }
        }
        //增加
        // POST: api/userInnfo
        public void Post([FromBody]UserInfos value)
        {
            using (osms1Entities1 db=new osms1Entities1())
            {
                db.UserInfos.Add(value);
                db.SaveChanges();
            }
        }

        // PUT: api/userInnfo/5
        public void Put(int id, [FromBody]UserInfos value)
        {
            using (osms1Entities1 db = new osms1Entities1())
            {
                var userinfo = db.UserInfos.SingleOrDefault(u=>u.Id==id);
                if (userinfo!=null)
                {
                    userinfo.UserName = value.UserName;
                    userinfo.Password = value.Password;
                }
            }
        }
        //删除
        // DELETE: api/userInnfo/5
        [HttpDelete]
        public void Delete(int id)
        {
            using (osms1Entities1 db=new osms1Entities1())
            {
                var userid = db.UserInfos.SingleOrDefault(u => u.Id == id);
                if (userid != null)
                {
                    db.UserInfos.Remove(userid);
                    db.SaveChanges();
                }
                //var userid=db.UserInfos.SingleOrDefault()
            }
        }
    }
}
