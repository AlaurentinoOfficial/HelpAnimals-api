using ha_web_api.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ha_web_api.Models
{
    public class User
    {
        [Key]
        public int Id{ get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public List<Animal> Animals { get; set; }
        private string password;
        public string Password
        {
            get { return password; }
            set { password = Crypt.Encrypt(value, Program.APP_HASH_KEY); }
        }
    }
}