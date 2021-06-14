using FishingHunting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishingHunting.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(FishingHuntingContext fishingHuntingContext)
            : base(fishingHuntingContext)
        {
        }
    }
    
}
