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
    public class UserRoleManager : IUserRole
    {
        private readonly UserRoleDB userRoleDB = new UserRoleDB();

        public async Task<UserRole> CreateAsync(UserRole entity)
        {
            return await userRoleDB.CreateAsync(entity);
        }

        public async Task<IEnumerable<UserRole>> CreateRangeAsync(List<UserRole> entities)
        {
            return await userRoleDB.CreateRangeAsync(entities);
        }

        public async Task<UserRole> DeleteAsync(UserRole entity)
        {
            return await userRoleDB.DeleteAsync(entity);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await userRoleDB.GetTotalCountAsync();
        }

        public async Task<IEnumerable<UserRole>> GetAsync(int skip, int take)
        {
            return await userRoleDB.GetAsync(skip, take);
        }

        public async Task<UserRole> GetByIdAsync(int id)
        {
            return await userRoleDB.GetByIdAsync(id);
        }

        public async Task<UserRole> UpdateAsync(UserRole entity)
        {
            return await userRoleDB.UpdateAsync(entity);
        }
    }
}
