using FishingHunting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishingHunting.Repositories
{
    public class FishingPlaceRepository : RepositoryBase<FishingPlace>, IFishingPlaceRepository
    {
        public FishingPlaceRepository(FishingHuntingContext fishingHuntingContext)
            : base(fishingHuntingContext)
    {
    }
}
    }

