using ha_web_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ha_web_api.Services
{
    public class TokenAccess
    {
        public static string Create(User user)
        {
            string buffer = user.Name+"/"+user.Email;
            buffer = Crypt.Encrypt(buffer, Program.APP_HASH_KEY);

            return buffer;
        }

        public static bool Validate(string token)
        {
            string email = Crypt.Decrypt(token, Program.APP_HASH_KEY);
            email = email.Split('/')[1];

            return new DbEntities().Users.ToList().Find(i => i.Email == email) != null;
        }
    }
}
