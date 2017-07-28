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
    public class SignalRUserRoomManager : ISignalRUserRoom
    {
        private readonly SignalRUserRoomDB signalRUserRoomDB = new SignalRUserRoomDB();

        public async Task<SignalRUserRoom> CreateAsync(SignalRUserRoom entity)
        {
            return await signalRUserRoomDB.CreateAsync(entity);
        }

        public async Task<IEnumerable<SignalRUserRoom>> CreateRangeAsync(List<SignalRUserRoom> entities)
        {
            return await signalRUserRoomDB.CreateRangeAsync(entities);
        }
        public async Task<SignalRUserRoom> DeleteAsync(SignalRUserRoom entity)
        {
            return await signalRUserRoomDB.DeleteAsync(entity);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await signalRUserRoomDB.GetTotalCountAsync();
        }

        public async Task<IEnumerable<SignalRUserRoom>> GetAsync(int skip, int take)
        {
            return await signalRUserRoomDB.GetAsync(skip, take);
        }

        public async Task<SignalRUserRoom> GetByIdAsync(int id) //never gonna be used
        {
            return await signalRUserRoomDB.GetByIdAsync(id);
        }
        public async Task<SignalRUserRoom> GetByUserAndRoomIdAsync(int userId, int roomId) //this instead
        {
            return await signalRUserRoomDB.GetByUserAndRoomIdAsync(userId, roomId);
        }
        public async Task<SignalRUserRoom> UpdateAsync(SignalRUserRoom entity)
        {
            return await signalRUserRoomDB.UpdateAsync(entity);
        }

    }
}
