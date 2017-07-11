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
    public class UserRoleDB : IUserRole
    {
        private readonly ProjectHeyContext projectHeyContext = new ProjectHeyContext();

        public async Task<UserRole> CreateAsync(UserRole entity)
        {
            projectHeyContext.UserRole.Add(entity);
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<UserRole>> CreateRangeAsync(List<UserRole> entities)
        {
            projectHeyContext.UserRole.AddRange(entities);
            await projectHeyContext.SaveChangesAsync();
            return entities;
        }

        public async Task<UserRole> DeleteAsync(UserRole entity)
        {
            projectHeyContext.UserRole.Remove(projectHeyContext.UserRole.Single(x => x.UserId == entity.UserId && x.RoleId == entity.RoleId));
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await projectHeyContext.UserRole.CountAsync();
        }

        public async Task<IEnumerable<UserRole>> GetAsync(int skip, int take)
        {
            return await projectHeyContext.UserRole.AsNoTracking().OrderBy(x => x.UserId).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<UserRole> GetByIdAsync(int id)
        {
            return await projectHeyContext.UserRole.SingleOrDefaultAsync(x => x.UserId == id);
        }

        public async Task<UserRole> UpdateAsync(UserRole entity)
        {
            projectHeyContext.UserRole.Attach(entity);
            projectHeyContext.Entry<UserRole>(entity).State = EntityState.Modified;
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }
    }
}
