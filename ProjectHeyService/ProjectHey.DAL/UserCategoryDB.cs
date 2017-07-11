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
    public class UserCategoryDB : IUserCategory
    {
        private readonly ProjectHeyContext projectHeyContext = new ProjectHeyContext();

        public async Task<UserCategory> CreateAsync(UserCategory entity)
        {
            projectHeyContext.UserCategory.Add(entity);
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<UserCategory>> CreateRangeAsync(List<UserCategory> entities)
        {
            projectHeyContext.UserCategory.AddRange(entities);
            await projectHeyContext.SaveChangesAsync();
            return entities;
        }

        public async Task<UserCategory> DeleteAsync(UserCategory entity)
        {
            projectHeyContext.UserCategory.Remove(projectHeyContext.UserCategory.Single(x => x.CategoryId == entity.CategoryId && x.UserId == entity.UserId));
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await projectHeyContext.UserCategory.CountAsync();
        }

        public async Task<IEnumerable<UserCategory>> GetAsync(int skip, int take)
        {
            return await projectHeyContext.UserCategory.AsNoTracking().OrderBy(x => x.UserId).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<UserCategory> GetByIdAsync(int id)
        {
            return await projectHeyContext.UserCategory.SingleOrDefaultAsync(x => x.UserId == id);
        }

        public async Task<UserCategory> UpdateAsync(UserCategory entity)
        {
            projectHeyContext.UserCategory.Attach(entity);
            projectHeyContext.Entry<UserCategory>(entity).State = EntityState.Modified;
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }
    }
}
