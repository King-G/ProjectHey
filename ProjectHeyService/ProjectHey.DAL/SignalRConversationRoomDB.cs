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
    public class SignalRConversationRoomDB : ISignalRConversationRoom
    {
        private readonly ProjectHeyContext projectHeyContext = new ProjectHeyContext();

        public async Task<SignalRConversationRoom> CreateAsync(SignalRConversationRoom entity)
        {
            projectHeyContext.SignalRConversationRoom.Add(entity);
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<SignalRConversationRoom>> CreateRangeAsync(List<SignalRConversationRoom> entities)
        {
            projectHeyContext.SignalRConversationRoom.AddRange(entities);
            await projectHeyContext.SaveChangesAsync();
            return entities;
        }

        public async Task<SignalRConversationRoom> DeleteAsync(SignalRConversationRoom entity)
        {
            projectHeyContext.SignalRConversationRoom.Remove(projectHeyContext.SignalRConversationRoom.Single(x => x.Id == entity.Id));
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }
        public async Task<SignalRConversationRoom> GetByNameAsync(string roomname)
        {
            return await projectHeyContext.SignalRConversationRoom.AsNoTracking()
                .Include(x => x.Messages)
                .FirstOrDefaultAsync(x => x.RoomName == roomname);
        }
        public async Task<int> GetTotalCountAsync()
        {
            return await projectHeyContext.SignalRConversationRoom.CountAsync();
        }

        public async Task<IEnumerable<SignalRConversationRoom>> GetAsync(int skip, int take)
        {
            return await projectHeyContext.SignalRConversationRoom.AsNoTracking().OrderBy(x => x.Id).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<SignalRConversationRoom> GetByIdAsync(int id)
        {
            return await projectHeyContext.SignalRConversationRoom.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<SignalRConversationRoom> UpdateAsync(SignalRConversationRoom entity)
        {
            projectHeyContext.SignalRConversationRoom.Attach(entity);
            projectHeyContext.Entry<SignalRConversationRoom>(entity).State = EntityState.Modified;
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }


    }
}
