using FishingHunting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishingHunting.Repositories
{
    public class FishingRepository : RepositoryBase<Fishing>, IFishingRepository
    {
        public FishingRepository(FishingHuntingContext fishingHuntingContext)
            : base(fishingHuntingContext)
        {
        }


    }
}
