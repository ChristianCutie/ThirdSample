using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThirdSample.Models
{
    public class login 
    {
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        public string Username { get; set; }
        [Required]
        [StringLength(100)]
        public string Password { get; set; }
    }
}