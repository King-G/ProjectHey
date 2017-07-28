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
    public class SignalRUserRoomDB : ISignalRUserRoom
    {
        private readonly ProjectHeyContext projectHeyContext = new ProjectHeyContext();

        public async Task<SignalRUserRoom> CreateAsync(SignalRUserRoom entity)
        {
            projectHeyContext.SignalRUserRoom.Add(entity);
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<SignalRUserRoom>> CreateRangeAsync(List<SignalRUserRoom> entities)
        {
            projectHeyContext.SignalRUserRoom.AddRange(entities);
            await projectHeyContext.SaveChangesAsync();
            return entities;
        }

        public async Task<SignalRUserRoom> DeleteAsync(SignalRUserRoom entity)
        {
            projectHeyContext.SignalRUserRoom.Remove(projectHeyContext.SignalRUserRoom.Single(x => x.SignalRUserId == entity.SignalRUserId && x.SignalRRoomId == entity.SignalRRoomId));
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await projectHeyContext.SignalRUserRoom.CountAsync();
        }

        public async Task<IEnumerable<SignalRUserRoom>> GetAsync(int skip, int take)
        {
            return await projectHeyContext.SignalRUserRoom.AsNoTracking().OrderBy(x => x.SignalRUserId).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<SignalRUserRoom> GetByIdAsync(int id) //never gonna be used.
        {
            return await projectHeyContext.SignalRUserRoom.AsNoTracking()
                .SingleOrDefaultAsync(x => x.SignalRUserId == id);
        }
        public async Task<SignalRUserRoom> GetByUserAndRoomIdAsync(int userId, int roomId) //this instead
        {
            return await projectHeyContext.SignalRUserRoom.AsNoTracking()
                .SingleOrDefaultAsync(x => x.SignalRUserId == userId && x.SignalRRoomId == roomId);
        }
        public async Task<SignalRUserRoom> UpdateAsync(SignalRUserRoom entity)
        {
            projectHeyContext.SignalRUserRoom.Attach(entity);
            projectHeyContext.Entry<SignalRUserRoom>(entity).State = EntityState.Modified;
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        
    }
}
