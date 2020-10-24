using osms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace osms.Controllers
{
    public class SysuserController : ApiController
    {
        // GET: api/Sysuser
        public IEnumerable<Sysuser> Get()
        {
            using (fashionshoppingDBEntities db=new fashionshoppingDBEntities())
            {
                return db.Sysuser.ToList();
            }
        }

        // GET: api/Sysuser/5
        public Sysuser Get(int id)
        {
            using (fashionshoppingDBEntities db=new fashionshoppingDBEntities())
            {
                return db.Sysuser.SingleOrDefault(d => d.id == id);
            }
        }
        public string Get1(string username,string pwd)
        {
            using (fashionshoppingDBEntities db = new fashionshoppingDBEntities())
            {
                var sysu = db.Sysuser.SingleOrDefault(d => d.username == username);
                if (sysu != null&&sysu.pwd==pwd)
                {
                    return "0000";
                }
                return "1101";
            }
        }
        // POST: api/Sysuser
        public Sysuser Post([FromBody]Sysuser value)
        {
            using (fashionshoppingDBEntities db=new fashionshoppingDBEntities())
            {
                db.Sysuser.Add(value);
                db.SaveChanges();
            }
            return value;
        }

        // PUT: api/Sysuser/5
        public Sysuser Put(int id, [FromBody]Sysuser value)
        {
            using (fashionshoppingDBEntities db = new fashionshoppingDBEntities())
            {
                var sysuser = db.Sysuser.SingleOrDefault(s => s.id == id);
                if (sysuser!=null)
                {
                    sysuser.pwd = value.pwd;
                    sysuser.role = value.role;
                    sysuser.username = value.username;
                }
                db.SaveChanges();
            }
            return value;
        }

        // DELETE: api/Sysuser/5
        public void Delete(int id)
        {
        }
    }
}
