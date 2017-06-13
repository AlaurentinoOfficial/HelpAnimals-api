using ha_web_api.Models;
using ha_web_api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ha_web_api.Controllers
{
    [Route("api")]
    public class AuthController : Controller
    {

        [HttpPost("login")]
        public JsonResult Login([FromBody] User user)
        {
            if (user != null)
            {
                DbEntities db = new DbEntities();

                User u = db.Users.ToList().Find(i => i.Email == user.Email);

                string token = u != null
                    ? u.Password.Equals(user.Password) ? TokenAccess.Create(u) : ""
                    : "";

                return new JsonResult(new { status = token != "", token = token });
            }
            else return new JsonResult(new { status=false, message="User cannot be null!"});
        }

        [HttpPost("register")]
        public JsonResult Register([FromBody] User user)
        {
            if (user != null)
            {
                DbEntities db = new DbEntities();

                db.Users.Add(user);

                return new JsonResult(new { status = true, message = "Succefuly user registred"});
            }
            else return new JsonResult(new { status = false, message = "User cannot be null!" });
        }

    }
}
