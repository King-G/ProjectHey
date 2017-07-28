using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectHey.DOMAIN;
using ProjectHey.DOMAIN.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ProjectHey.DAL
{
    public class FacebookCityDB : IFacebookCity
    {
        private readonly ProjectHeyContext projectHeyContext = new ProjectHeyContext();

        public async Task<FacebookCity> CreateAsync(FacebookCity entity)
        {
            projectHeyContext.FacebookCity.Add(entity);
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<FacebookCity>> CreateRangeAsync(List<FacebookCity> entities)
        {
            projectHeyContext.FacebookCity.AddRange(entities);
            await projectHeyContext.SaveChangesAsync();
            return entities;
        }

        public async Task<FacebookCity> DeleteAsync(FacebookCity entity)
        {
            projectHeyContext.FacebookCity.Remove(projectHeyContext.FacebookCity.Single(x => x.Id == entity.Id));
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await projectHeyContext.FacebookCity.CountAsync();
        }

        public async Task<IEnumerable<FacebookCity>> GetAsync(int skip, int take)
        {
            return await projectHeyContext.FacebookCity.AsNoTracking().OrderBy(x => x.Id).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<FacebookCity> GetByIdAsync(int id)
        {
            return await projectHeyContext.FacebookCity.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<FacebookCity> GetByCityIdAsync(string cityId)
        {
            return await projectHeyContext.FacebookCity.SingleOrDefaultAsync(x => x.CityId == cityId);
        }
        public async Task<FacebookCity> UpdateAsync(FacebookCity entity)
        {
            projectHeyContext.FacebookCity.Attach(entity);
            projectHeyContext.Entry<FacebookCity>(entity).State = EntityState.Modified;
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        
    }
}
