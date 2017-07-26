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
    public class UserManager : IUser
    {
        private readonly ConnectionManager connectionManager = new ConnectionManager();
        private readonly UserDB userDB = new UserDB();
        private readonly SignalRRoomDB signalRRoomDB = new SignalRRoomDB();
        public async Task<User> CreateAsync(User entity)
        {
            entity.Username = entity.ResetUsername();
            entity.CreationDate = DateTime.Now;
            entity.ActivityDate = DateTime.Now;
            entity.Appsetting = new AppSetting();
            entity.Appsetting = entity.Appsetting.GetDefaultAppSettings();
            entity.SignalRUser = new SignalRUser();

            return await userDB.CreateAsync(entity);
        }
        //public async Task<Connection> CreateConnectionForUser(User userId)
        //{
        //    //User chosenOne = GetUsersByLocationAsync()
        //}
        public async Task<IEnumerable<User>> CreateRangeAsync(List<User> entities)
        {
            return await userDB.CreateRangeAsync(entities);
        }

        public async Task<User> DeleteAsync(User entity)
        {
            return await userDB.DeleteAsync(entity);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await userDB.GetTotalCountAsync();
        }

        public async Task<IEnumerable<User>> GetAsync(int skip, int take)
        {
            return await userDB.GetAsync(skip, take);
        }
        public async Task<User> GetSimplifiedByIdAsync(int id)
        {
            return await userDB.GetSimplifiedByIdAsync(id);
        }
        public async Task<User> GetByFacebookId(string facebookId)
        {
            return await userDB.GetByFacebookId(facebookId);
        }
        public async Task<User> GetByIdAsync(int id)
        {
            return await userDB.GetByIdAsync(id);
        }
        public async Task<IEnumerable<User>> GetUsersByLocationAsync(User requestor, int skip, int take)
        {
            return await userDB.GetUsersByLocationAsync(requestor, skip, take);
        }
        public async Task<User> GetByUsernameAsync(string username)
        {
            return await userDB.GetByUsernameAsync(username);
        }
        public async Task<User> UpdateAsync(User entity)
        {
            return await userDB.UpdateAsync(entity);
        }


    }
}
