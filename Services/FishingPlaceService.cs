using FishingHunting.Models;
using FishingHunting.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FishingHunting.Services
{
    public class FishingPlaceService : BaseService
    {
        public FishingPlaceService(IRepositoryWrapper repositoryWrapper)
           : base(repositoryWrapper)
        {
        }
        public List<FishingPlace> GetFishingPlace()
        {
            return repositoryWrapper.FishingPlaceRepository.FindAll().ToList();
        }

        public List<FishingPlace> GetFishingPlaceByCondition(Expression<Func<FishingPlace, bool>> expression)
        {
            return repositoryWrapper.FishingPlaceRepository.FindByCondition(expression).ToList();
        }

        public void AddFishingPlace(FishingPlace fishingPlace)
        {
            repositoryWrapper.FishingPlaceRepository.Create(fishingPlace);
        }

        public void UpdateFishingPlace(FishingPlace fishingPlace)
        {
            repositoryWrapper.FishingPlaceRepository.Update(fishingPlace);
        }

        public void DeleteFishingPlace(FishingPlace fishingPlace)
        {
            repositoryWrapper.FishingPlaceRepository.Delete(fishingPlace);
        }


    }
}
