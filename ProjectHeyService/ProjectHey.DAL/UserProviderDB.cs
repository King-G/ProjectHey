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
    public class UserProviderDB : IUserProvider
    {
        private readonly ProjectHeyContext projectHeyContext = new ProjectHeyContext();

        public async Task<UserProvider> CreateAsync(UserProvider entity)
        {
            projectHeyContext.UserProvider.Add(entity);
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }
        public async Task<IEnumerable<UserProvider>> CreateRangeAsync(List<UserProvider> entities)
        {
            projectHeyContext.UserProvider.AddRange(entities);
            await projectHeyContext.SaveChangesAsync();
            return entities;
        }

        public async Task<UserProvider> DeleteAsync(UserProvider entity)
        {
            projectHeyContext.UserProvider.Remove(projectHeyContext.UserProvider.Single(x => x.UserId == entity.UserId && x.ProviderId == entity.ProviderId));
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await projectHeyContext.UserProvider.CountAsync();
        }

        public async Task<IEnumerable<UserProvider>> GetAsync(int skip, int take)
        {
            return await projectHeyContext.UserProvider.AsNoTracking().OrderBy(x => x.UserId).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<UserProvider> GetByIdAsync(int id)
        {
            return await projectHeyContext.UserProvider.FirstOrDefaultAsync(x => x.ProviderUserId == id);
        }
        public async Task<IEnumerable<UserProvider>> GetByUserIdAsync(int userId, int skip, int take)
        {
            return await projectHeyContext.UserProvider.AsNoTracking().Where(x => x.UserId == userId).OrderBy(x => x.ProviderUserId).Skip(skip).Take(take).ToListAsync();
        }
        public async Task<UserProvider> UpdateAsync(UserProvider entity)
        {
            projectHeyContext.UserProvider.Attach(entity);
            projectHeyContext.Entry<UserProvider>(entity).State = EntityState.Modified;
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }
    }
}
