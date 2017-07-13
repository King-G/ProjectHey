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
    public class UserAdvertisementDB : IUserAdvertisement
    {
        private readonly ProjectHeyContext projectHeyContext = new ProjectHeyContext();

        public async Task<UserAdvertisement> CreateAsync(UserAdvertisement entity)
        {
            projectHeyContext.UserAdvertisement.Add(entity);
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<UserAdvertisement>> CreateRangeAsync(List<UserAdvertisement> entities)
        {
            projectHeyContext.UserAdvertisement.AddRange(entities);
            await projectHeyContext.SaveChangesAsync();
            return entities;
        }

        public async Task<UserAdvertisement> DeleteAsync(UserAdvertisement entity)
        {
            projectHeyContext.UserAdvertisement.Remove(projectHeyContext.UserAdvertisement.Single(x => x.UserId == entity.UserId && x.AdvertisementId == entity.AdvertisementId));
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await projectHeyContext.UserAdvertisement.CountAsync();
        }

        public async Task<IEnumerable<UserAdvertisement>> GetAsync(int skip, int take)
        {
            return await projectHeyContext.UserAdvertisement.AsNoTracking().OrderBy(x => x.AdvertisementId).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<UserAdvertisement> GetByIdAsync(int id)
        {
            return await projectHeyContext.UserAdvertisement.FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task<IEnumerable<UserAdvertisement>> GetByViewDate(DateTime date)
        {
            return await projectHeyContext.UserAdvertisement.Where(x => x.ViewDate == date).ToListAsync();
        }

        public async Task<UserAdvertisement> UpdateAsync(UserAdvertisement entity)
        {
            projectHeyContext.UserAdvertisement.Attach(entity);
            projectHeyContext.Entry<UserAdvertisement>(entity).State = EntityState.Modified;
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }
    }
}
