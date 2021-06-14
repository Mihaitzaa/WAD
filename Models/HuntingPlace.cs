using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishingHunting.Models
{
    public class HuntingPlace
    {
        public Guid ID { get; set; }
        public string HuntingPlaceName { get; set; }
        public string HuntingLocation { get; set; }
        public ICollection<Preferences> Preferences { get; set; }
    }
}
