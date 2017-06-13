using ha_web_api.Models;
using ha_web_api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ha_web_api.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {

        [HttpPost]
        public JsonResult post([FromBody] User user)
        {
            if (user != null)
            {
                DbEntities db = new DbEntities();

                var teste = db.Users.ToList();
                Console.WriteLine(teste);

                User u = db.Users.ToList().Find(i => i.Email == user.Email);

                string token = u != null
                    ? u.Password.Equals(user.Password) ? TokenAccess.Create(u) : ""
                    : "";

                return new JsonResult(new { status = token != "", token = token });
            }
            else return new JsonResult(new { status=false, message="User cannot be null!"});
        }


    }
}
