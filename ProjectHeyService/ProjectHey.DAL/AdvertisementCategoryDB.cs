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
    public class AdvertisementCategoryDB : IAdvertisementCategory
    {
        private readonly ProjectHeyContext projectHeyContext = new ProjectHeyContext();

        public async Task<AdvertisementCategory> CreateAsync(AdvertisementCategory entity)
        {
            projectHeyContext.AdvertisementCategory.Add(entity);
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<AdvertisementCategory>> CreateRangeAsync(List<AdvertisementCategory> entities)
        {
            projectHeyContext.AdvertisementCategory.AddRange(entities);
            await projectHeyContext.SaveChangesAsync();
            return entities;
        }

        public async Task<AdvertisementCategory> DeleteAsync(AdvertisementCategory entity)
        {
            projectHeyContext.AdvertisementCategory.Remove(projectHeyContext.AdvertisementCategory.Single(x => x.AdvertisementId == entity.AdvertisementId && x.CategoryId == entity.CategoryId));
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await projectHeyContext.AdvertisementCategory.CountAsync();
        }

        public async Task<IEnumerable<AdvertisementCategory>> GetAsync(int skip, int take)
        {
            return await projectHeyContext.AdvertisementCategory.AsNoTracking().OrderBy(x => x.AdvertisementId).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<AdvertisementCategory> GetByIdAsync(int id)
        {
            return await projectHeyContext.AdvertisementCategory.FirstOrDefaultAsync(x => x.AdvertisementId == id);
        }

        public async Task<AdvertisementCategory> UpdateAsync(AdvertisementCategory entity)
        {
            projectHeyContext.AdvertisementCategory.Attach(entity);
            projectHeyContext.Entry<AdvertisementCategory>(entity).State = EntityState.Modified;
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }
    }
}
