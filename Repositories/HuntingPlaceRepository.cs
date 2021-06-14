using FishingHunting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishingHunting.Repositories
{
    public class HuntingPlaceRepository : RepositoryBase<HuntingPlace>, IHuntingPlaceRepository
    {
        public HuntingPlaceRepository(FishingHuntingContext fishingHuntingContext)
            : base(fishingHuntingContext)
        {
        }
    }
   
}
