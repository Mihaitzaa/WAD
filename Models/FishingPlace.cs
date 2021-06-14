using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishingHunting.Models
{
    public class FishingPlace
    {
        public Guid ID { get; set; }
        public string FishingPlaceName { get; set; }
        public string FishingLocation { get; set; }
        public ICollection<Preferences> Preferences { get; set; }
    }
}
