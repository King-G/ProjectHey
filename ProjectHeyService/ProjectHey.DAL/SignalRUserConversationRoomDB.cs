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
    public class SignalRUserConversationRoomDB : ISignalRUserConversationRoom
    {
        private readonly ProjectHeyContext projectHeyContext = new ProjectHeyContext();

        public async Task<SignalRUserConversationRoom> CreateAsync(SignalRUserConversationRoom entity)
        {
            projectHeyContext.SignalRUserConversationRoom.Add(entity);
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<SignalRUserConversationRoom>> CreateRangeAsync(List<SignalRUserConversationRoom> entities)
        {
            projectHeyContext.SignalRUserConversationRoom.AddRange(entities);
            await projectHeyContext.SaveChangesAsync();
            return entities;
        }

        public async Task<SignalRUserConversationRoom> DeleteAsync(SignalRUserConversationRoom entity)
        {
            projectHeyContext.SignalRUserConversationRoom.Remove(projectHeyContext.SignalRUserConversationRoom.Single(x => x.SignalRUserId == entity.SignalRUserId && x.SignalRConversationRoomId == entity.SignalRConversationRoomId));
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await projectHeyContext.SignalRUserConversationRoom.CountAsync();
        }

        public async Task<IEnumerable<SignalRUserConversationRoom>> GetAsync(int skip, int take)
        {
            return await projectHeyContext.SignalRUserConversationRoom.AsNoTracking().OrderBy(x => x.SignalRUserId).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<SignalRUserConversationRoom> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<SignalRUserConversationRoom> UpdateAsync(SignalRUserConversationRoom entity)
        {
            projectHeyContext.SignalRUserConversationRoom.Attach(entity);
            projectHeyContext.Entry<SignalRUserConversationRoom>(entity).State = EntityState.Modified;
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

    }
}
