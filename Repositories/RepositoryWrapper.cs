using FishingHunting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishingHunting.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private FishingHuntingContext _fishingHuntingContext;
        private IFishingRepository _fishingRepository;
        private IHuntingRepository _huntingRepository;
        private IFishingPlaceRepository _fishingPlaceRepository;

        public IFishingRepository FishingRepository
        {
            get
            {
                if (_fishingRepository == null)
                {
                    _fishingRepository = new FishingRepository(_fishingHuntingContext);
                }
                return _fishingRepository;
            }
        }

        public IHuntingRepository HuntingRepository
        {
            get
            {
                if (_huntingRepository == null)
                {
                    _huntingRepository = new HuntingRepository(_fishingHuntingContext);
                }
                return _huntingRepository;
            }
        }

        public IFishingPlaceRepository FishingPlaceRepository
        {
            get
            {
                if (_fishingPlaceRepository == null)
                {
                    _fishingPlaceRepository = new FishingPlaceRepository(_fishingHuntingContext);
                }
                return _fishingPlaceRepository;
            }
        }

        public RepositoryWrapper(FishingHuntingContext fishingHuntingContext)
        {
            _fishingHuntingContext = fishingHuntingContext;
        }

        public void Save()
        {
            _fishingHuntingContext.SaveChanges();
        }
    }
}
