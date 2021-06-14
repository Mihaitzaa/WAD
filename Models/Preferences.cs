using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishingHunting.Models
{
    public class Preferences
    {
        public Guid ID { get; set; }
        public HuntingPlace HuntingPlace { get; set; }
        public FishingPlace FishingPlace { get; set; }
        public User User{ get; set; }
        public Fishing FishingProduct{ get; set; }
        public Hunting HuntingProduct{ get; set; }
    }
}
