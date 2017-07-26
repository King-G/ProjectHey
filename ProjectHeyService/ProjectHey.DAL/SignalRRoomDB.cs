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
    public class SignalRRoomDB : ISignalRRoom
    {
        private readonly ProjectHeyContext projectHeyContext = new ProjectHeyContext();

        public async Task<SignalRRoom> CreateAsync(SignalRRoom entity)
        {
            projectHeyContext.SignalRRoom.Add(entity);
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<SignalRRoom>> CreateRangeAsync(List<SignalRRoom> entities)
        {
            projectHeyContext.SignalRRoom.AddRange(entities);
            await projectHeyContext.SaveChangesAsync();
            return entities;
        }

        public async Task<SignalRRoom> DeleteAsync(SignalRRoom entity)
        {
            projectHeyContext.SignalRRoom.Remove(projectHeyContext.SignalRRoom.Single(x => x.Id == entity.Id));
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }
        public async Task<SignalRRoom> GetByNameAsync(string roomname)
        {
            return await projectHeyContext.SignalRRoom.AsNoTracking()
                .Include(x => x.Messages)
                .FirstOrDefaultAsync(x => x.Roomname == roomname);
        }
        public async Task<int> GetTotalCountAsync()
        {
            return await projectHeyContext.SignalRRoom.CountAsync();
        }

        public async Task<IEnumerable<SignalRRoom>> GetAsync(int skip, int take)
        {
            return await projectHeyContext.SignalRRoom.AsNoTracking().OrderBy(x => x.Id).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<SignalRRoom> GetByIdAsync(int id)
        {
            return await projectHeyContext.SignalRRoom.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<SignalRRoom> UpdateAsync(SignalRRoom entity)
        {
            projectHeyContext.SignalRRoom.Attach(entity);
            projectHeyContext.Entry<SignalRRoom>(entity).State = EntityState.Modified;
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }


    }
}
