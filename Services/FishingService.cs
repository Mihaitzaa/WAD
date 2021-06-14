using FishingHunting.Models;
using FishingHunting.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FishingHunting.Services
{
    public class FishingService : BaseService
    {
        public FishingService(IRepositoryWrapper repositoryWrapper)
           : base(repositoryWrapper)
        {
        }
        public List<Fishing> GetFishingItem()
        {
            return repositoryWrapper.FishingRepository.FindAll().ToList();
        }

        public List<Fishing> GetFishingItemByCondition(Expression<Func<Fishing, bool>> expression)
        {
            return repositoryWrapper.FishingRepository.FindByCondition(expression).ToList();
        }

        public void AddFishingItem(Fishing fishing)
        {
            repositoryWrapper.FishingRepository.Create(fishing);
        }

        public void UpdateFishingItem(Fishing fishing)
        {
            repositoryWrapper.FishingRepository.Update(fishing);
        }

        public void DeleteFishingItem(Fishing fishing)
        {
            repositoryWrapper.FishingRepository.Delete(fishing);
        }


    }
}
