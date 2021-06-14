using FishingHunting.Models;
using FishingHunting.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FishingHunting.Services
{
    public class HuntingService : BaseService
    {
        public HuntingService(IRepositoryWrapper repositoryWrapper)
          : base(repositoryWrapper)
        {
        }
        public List<Hunting> GetHuntingItem()
        {
            return repositoryWrapper.HuntingRepository.FindAll().ToList();
        }

        public List<Hunting> GetHuntingItemByCondition(Expression<Func<Hunting, bool>> expression)
        {
            return repositoryWrapper.HuntingRepository.FindByCondition(expression).ToList();
        }

        public void AddHuntingItem(Hunting hunting)
        {
            repositoryWrapper.HuntingRepository.Create(hunting);
        }

        public void UpdateHuntingItem(Hunting hunting)
        {
            repositoryWrapper.HuntingRepository.Update(hunting);
        }

        public void DeleteHuntingItem(Hunting hunting)
        {
            repositoryWrapper.HuntingRepository.Delete(hunting);
        }


    }
}
