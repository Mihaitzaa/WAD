using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishingHunting.Repositories
{
    public interface IRepositoryWrapper
    {
        IFishingRepository FishingRepository { get; }
        IHuntingRepository HuntingRepository { get; }
        IFishingPlaceRepository FishingPlaceRepository { get; }
        void Save();
    }
}
