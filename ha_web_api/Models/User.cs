using ha_web_api.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ha_web_api.Models
{
    public class User
    {
        [Key]
        public int Id{ get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = Crypt.Encoder(value, Program.APP_HASH_KEY); }
        }
    }
}