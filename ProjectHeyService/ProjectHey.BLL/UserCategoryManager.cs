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
    public class UserCategoryManager : IUserCategory
    {
        private readonly UserCategoryDB userCategoryDB = new UserCategoryDB();

        public async Task<UserCategory> CreateAsync(UserCategory entity)
        {
            return await userCategoryDB.CreateAsync(entity);
        }
        public async Task<UserCategory> CreateAndAddToRoom(UserCategory entity, bool isinroom)
        {
            if (isinroom)
            {
                SignalRUserManager signalRUserManager = new SignalRUserManager();
                SignalRRoomManager signalRRoomManager = new SignalRRoomManager();
                SignalRUserRoomManager signalRUserRoomManager = new SignalRUserRoomManager();

                SignalRUser signalRUser = await signalRUserManager.GetByIdAsync(entity.UserId);
                SignalRRoom signalRRoom = await signalRRoomManager.GetByIdAsync(entity.Category.SignalRRoomId);

                SignalRUserRoom signalRUserRoom = new SignalRUserRoom()
                {
                    SignalRUser = signalRUser,
                    SignalRRoom = signalRRoom
                };

                await signalRUserRoomManager.CreateAsync(signalRUserRoom);
            }
            return await userCategoryDB.CreateAndAddToRoom(entity, isinroom);
        }
        public async Task<IEnumerable<UserCategory>> CreateRangeAsync(List<UserCategory> entities)
        {
            return await userCategoryDB.CreateRangeAsync(entities);
        }

        public async Task<UserCategory> DeleteAsync(UserCategory entity)
        {
            return await userCategoryDB.DeleteAsync(entity);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await userCategoryDB.GetTotalCountAsync();
        }

        public async Task<IEnumerable<UserCategory>> GetAsync(int skip, int take)
        {
            return await userCategoryDB.GetAsync(skip, take);
        }

        public async Task<UserCategory> GetByIdAsync(int id)
        {
            return await userCategoryDB.GetByIdAsync(id);
        }

        public async Task<UserCategory> UpdateAsync(UserCategory entity)
        {
            return await userCategoryDB.UpdateAsync(entity);
        }

        public async Task<IEnumerable<UserCategory>> GetAllByIdAsync(int userId)
        {
            return await userCategoryDB.GetAllByIdAsync(userId);
        }

        
    }
}
