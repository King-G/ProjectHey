using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectHey.DOMAIN;
using ProjectHey.DOMAIN.Contracts;
using ProjectHey.DAL;

namespace ProjectHey.BLL
{
    public class SignalRUserConversationRoomManager : ISignalRUserConversationRoom
    {
        private readonly SignalRUserConversationRoomDB signalRUserConversationRoomDB = new SignalRUserConversationRoomDB();

        public async Task<SignalRUserConversationRoom> CreateAsync(SignalRUserConversationRoom entity)
        {
            return await signalRUserConversationRoomDB.CreateAsync(entity);
        }

        public async Task<IEnumerable<SignalRUserConversationRoom>> CreateRangeAsync(List<SignalRUserConversationRoom> entities)
        {
            return await signalRUserConversationRoomDB.CreateRangeAsync(entities);
        }
        public async Task<SignalRUserConversationRoom> DeleteAsync(SignalRUserConversationRoom entity)
        {
            return await signalRUserConversationRoomDB.DeleteAsync(entity);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await signalRUserConversationRoomDB.GetTotalCountAsync();
        }

        public async Task<IEnumerable<SignalRUserConversationRoom>> GetAsync(int skip, int take)
        {
            return await signalRUserConversationRoomDB.GetAsync(skip, take);
        }

        public async Task<SignalRUserConversationRoom> GetByIdAsync(int id)
        {
            return await signalRUserConversationRoomDB.GetByIdAsync(id);
        }

        public async Task<SignalRUserConversationRoom> UpdateAsync(SignalRUserConversationRoom entity)
        {
            return await signalRUserConversationRoomDB.UpdateAsync(entity);
        }
    }
}
