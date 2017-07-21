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
        private readonly UserDB userDB = new UserDB();

        public async Task<User> CreateAsync(User entity)
        {
            entity.Username = entity.ResetUsername();
            entity.Appsetting = entity.Appsetting.GetDefaultAppSettings();
            entity.SignalRUser = new SignalRUser();

            return await userDB.CreateAsync(entity);
        }

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
        public async Task<User> GetByIdAsync(int id)
        {
            return await userDB.GetByIdAsync(id);
        }
        public async Task<IEnumerable<User>> GetByLocationAsync(User requestor, int skip, int take)
        {
            return await userDB.GetByLocationAsync(requestor, skip, take);
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
