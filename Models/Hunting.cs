using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishingHunting.Models
{
    public class Hunting
    {
        public Guid ID { get; set; }
        public string HuntingProductName { get; set; }
        public string HuntingProductType { get; set; }
        public ICollection<Preferences> Preferences { get; set; }
    }
}
