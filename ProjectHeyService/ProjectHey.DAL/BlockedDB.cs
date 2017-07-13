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
    public class BlockedDB : IBlocked
    {
        private readonly ProjectHeyContext projectHeyContext = new ProjectHeyContext();

        public async Task<Blocked> CreateAsync(Blocked entity)
        {
            projectHeyContext.Blocked.Add(entity);
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Blocked>> CreateRangeAsync(List<Blocked> entities)
        {
            projectHeyContext.Blocked.AddRange(entities);
            await projectHeyContext.SaveChangesAsync();
            return entities;
        }

        public async Task<Blocked> DeleteAsync(Blocked entity)
        {
            projectHeyContext.Blocked.Remove(projectHeyContext.Blocked.Single(x => x.UserId== entity.UserId && x.BlockedUserId == entity.BlockedUserId));
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await projectHeyContext.Blocked.CountAsync();
        }

        public async Task<IEnumerable<Blocked>> GetAsync(int skip, int take)
        {
            return await projectHeyContext.Blocked.AsNoTracking().OrderBy(x => x.UserId).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<Blocked> GetByIdAsync(int id)
        {
            return await projectHeyContext.Blocked.FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task<Blocked> UpdateAsync(Blocked entity)
        {
            projectHeyContext.Blocked.Attach(entity);
            projectHeyContext.Entry<Blocked>(entity).State = EntityState.Modified;
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }
    }
}
