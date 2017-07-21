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
    public class SignalRConversationRoomManager : ISignalRConversationRoom
    {
        private readonly SignalRConversationRoomDB signalRConversationRoomDB = new SignalRConversationRoomDB();

        public async Task<SignalRConversationRoom> CreateAsync(SignalRConversationRoom entity)
        {
            return await signalRConversationRoomDB.CreateAsync(entity);
        }

        public async Task<IEnumerable<SignalRConversationRoom>> CreateRangeAsync(List<SignalRConversationRoom> entities)
        {
            return await signalRConversationRoomDB.CreateRangeAsync(entities);
        }

        public async Task<SignalRConversationRoom> DeleteAsync(SignalRConversationRoom entity)
        {
            return await signalRConversationRoomDB.DeleteAsync(entity);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await signalRConversationRoomDB.GetTotalCountAsync();
        }

        public async Task<IEnumerable<SignalRConversationRoom>> GetAsync(int skip, int take)
        {
            return await signalRConversationRoomDB.GetAsync(skip, take);
        }
        public async Task<SignalRConversationRoom> GetByNameAsync(string roomname)
        {
            return await signalRConversationRoomDB.GetByNameAsync(roomname);
        }
        public async Task<SignalRConversationRoom> GetByIdAsync(int id)
        {
            return await signalRConversationRoomDB.GetByIdAsync(id);
        }

        public async Task<SignalRConversationRoom> UpdateAsync(SignalRConversationRoom entity)
        {
            return await signalRConversationRoomDB.UpdateAsync(entity);
        }


    }
}
