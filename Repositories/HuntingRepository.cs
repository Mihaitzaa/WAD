using FishingHunting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishingHunting.Repositories
{
    public class HuntingRepository : RepositoryBase<Hunting>, IHuntingRepository
    {
        public HuntingRepository(FishingHuntingContext fishingHuntingContext)
            : base(fishingHuntingContext)
        {
        }

    }
}

