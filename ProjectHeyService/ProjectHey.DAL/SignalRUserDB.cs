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
    public class SignalRUserDB : ISignalRUser
    {
        private readonly ProjectHeyContext projectHeyContext = new ProjectHeyContext();

        public async Task<SignalRUser> CreateAsync(SignalRUser entity)
        {
            projectHeyContext.SignalRUser.Add(entity);
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<SignalRUser>> CreateRangeAsync(List<SignalRUser> entities)
        {
            projectHeyContext.SignalRUser.AddRange(entities);
            await projectHeyContext.SaveChangesAsync();
            return entities;
        }

        public async Task<SignalRUser> DeleteAsync(SignalRUser entity)
        {
            projectHeyContext.SignalRUser.Remove(projectHeyContext.SignalRUser.Single(x => x.Id == entity.Id));
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await projectHeyContext.SignalRUser.CountAsync();
        }

        public async Task<IEnumerable<SignalRUser>> GetAsync(int skip, int take)
        {
            return await projectHeyContext.SignalRUser.AsNoTracking()
                .Include(x => x.Rooms)
                .OrderBy(x => x.UserId)
                .Skip(skip).Take(take)
                .ToListAsync();
        }

        public async Task<SignalRUser> GetByIdAsync(int id)
        {
            return await projectHeyContext.SignalRUser.AsNoTracking()
                .Include(x => x.Rooms)
                .FirstOrDefaultAsync(x => x.UserId == id);
        }
        public async Task<SignalRUser> UpdateAsync(SignalRUser entity)
        {
            projectHeyContext.SignalRUser.Attach(entity);
            projectHeyContext.Entry<SignalRUser>(entity).State = EntityState.Modified;
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

    }
}
