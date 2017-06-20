using System;
using System.ComponentModel.DataAnnotations;

namespace ha_web_api.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Breed { get; set; }
        public DateTime BirthDay { get; set; }
    }
}