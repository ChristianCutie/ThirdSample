using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThirdSample.Models
{
    public class Type
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Type")]
        public string Name { get; set; }
        public Item Item { get; set; }
        public int itemid { get; set; }
    }
}