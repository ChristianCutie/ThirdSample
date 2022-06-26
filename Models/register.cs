using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThirdSample.Models
{
    public class register : login
    {
        public int userID { get; set; }
         [Required]
        [StringLength(100)]
        public string FirstNane { get; set; }
         [Required]
        [StringLength(100)]
        public string LastNane { get; set; }
        public string Gender { get; set; }
         [Required]
        [StringLength(3)]
        public int Age { get; set; }
    }
}