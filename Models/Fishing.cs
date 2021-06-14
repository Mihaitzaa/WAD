using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishingHunting.Models
{
    public class Fishing
    {
        public Guid ID { get; set; }
        public string FishingProductName { get; set; }
        public string FishingProductType { get; set; }
        public ICollection<Preferences> Preferences { get; set; }
    }
}
