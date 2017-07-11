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
    public class UserProviderManager : IUserProvider
    {
        private readonly UserProviderDB userProviderDB = new UserProviderDB();

        public async Task<UserProvider> CreateAsync(UserProvider entity)
        {
            return await userProviderDB.CreateAsync(entity);
        }

        public async Task<IEnumerable<UserProvider>> CreateRangeAsync(List<UserProvider> entities)
        {
            return await userProviderDB.CreateRangeAsync(entities);
        }

        public async Task<UserProvider> DeleteAsync(UserProvider entity)
        {
            return await userProviderDB.DeleteAsync(entity);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await userProviderDB.GetTotalCountAsync();
        }

        public async Task<IEnumerable<UserProvider>> GetAsync(int skip, int take)
        {
            return await userProviderDB.GetAsync(skip, take);
        }

        public async Task<UserProvider> GetByIdAsync(int id)
        {
            return await userProviderDB.GetByIdAsync(id);
        }
        public async Task<IEnumerable<UserProvider>> GetByUserIdAsync(int userId, int skip, int take)
        {
            return await userProviderDB.GetByUserIdAsync(userId, skip, take);
        }

        public async Task<UserProvider> UpdateAsync(UserProvider entity)
        {
            return await userProviderDB.UpdateAsync(entity);
        }
    }
}
