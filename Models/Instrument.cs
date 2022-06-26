using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ThirdSample.Models
{
    public class Instrument
    {
        public int Id { get; set; }
        public Type Type { get; set; }
        public int typeid { get; set; }
        public Item Item { get; set; }
        public int itemid { get; set; }
        [DisplayName("Price")]
        public int price { get; set; }
        [DisplayName("Image")]  
        public string imgpath { get; set; }
    }
}