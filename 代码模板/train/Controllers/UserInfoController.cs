using Newtonsoft.Json;
using osms.Models;
using osms.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace osms.Controllers
{

    //public static class UserInfoExtensions
    //{
    //    public static IEnumerable<UserInfoLite> ToUserInfoLites(this IEnumerable<UserInfo> userInfos)
    //    {
    //        if (userInfos is null)
    //            return null;

    //        return userInfos.Select(p => new UserInfoLite
    //        {
    //            Id = p.ID,
    //        });
    //    }

    //}

    public class UserInfoController : ApiController
    {
        public readonly UserInfoService userInfo=new UserInfoService();
        // GET: api/UserInfo
        public string Get()
        {
            var userinfos = userInfo.Getuserinfo();
            return JsonConvert.SerializeObject(userinfos);
        }
        // GET: api/UserInfo/5
        public UserInfo Get(int id)
        {
            using (osmsEntities db=new osmsEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return db.UserInfo.SingleOrDefault(u=>u.ID==id);
            }
            //return "value";
        }
        public string Login(string username, string pwd)
        {
            using (osmsEntities db = new osmsEntities())
            {
                var sysu = db.UserInfo.SingleOrDefault(d => d.Account == username);
                if (sysu != null && sysu.Password == pwd)
                {
                    return "0000";
                }
                return "1101";
            }
        }
        // POST: api/UserInfo
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UserInfo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserInfo/5
        public void Delete(int id)
        {
        }
    }
}
