using FishingHunting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishingHunting.Repositories
{
    public class PreferencesRepository : RepositoryBase<Preferences>, IPreferencesRepository
    {
        public PreferencesRepository(FishingHuntingContext fishingHuntingContext)
            : base(fishingHuntingContext)
        {
        }
    }
    
}
