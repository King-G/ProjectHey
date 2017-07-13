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
    public class RoleDB : IRole
    {
        private readonly ProjectHeyContext projectHeyContext = new ProjectHeyContext();

        public async Task<Role> CreateAsync(Role entity)
        {
            projectHeyContext.Role.Add(entity);
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Role>> CreateRangeAsync(List<Role> entities)
        {
            projectHeyContext.Role.AddRange(entities);
            await projectHeyContext.SaveChangesAsync();
            return entities;
        }

        public async Task<Role> DeleteAsync(Role entity)
        {
            projectHeyContext.Role.Remove(projectHeyContext.Role.Single(x => x.Id == entity.Id));
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await projectHeyContext.Role.CountAsync();
        }

        public async Task<IEnumerable<Role>> GetAsync(int skip, int take)
        {
            return await projectHeyContext.Role.AsNoTracking().OrderBy(x => x.Id).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            return await projectHeyContext.Role.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Role> GetByNameAsync(string name)
        {
            return await projectHeyContext.Role.FirstOrDefaultAsync(x => x.Name == name);
        }
        public async Task<Role> UpdateAsync(Role entity)
        {
            projectHeyContext.Role.Attach(entity);
            projectHeyContext.Entry<Role>(entity).State = EntityState.Modified;
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }
    }
}
