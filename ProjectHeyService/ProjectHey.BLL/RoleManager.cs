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
    public class RoleManager : IRole
    {
        private readonly RoleDB roleDB = new RoleDB();

        public async Task<Role> CreateAsync(Role entity)
        {
            return await roleDB.CreateAsync(entity);
        }

        public async Task<IEnumerable<Role>> CreateRangeAsync(List<Role> entities)
        {
            return await roleDB.CreateRangeAsync(entities);
        }

        public async Task<Role> DeleteAsync(Role entity)
        {
            return await roleDB.DeleteAsync(entity);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await roleDB.GetTotalCountAsync();
        }

        public async Task<IEnumerable<Role>> GetAsync(int skip, int take)
        {
            return await roleDB.GetAsync(skip, take);
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            return await roleDB.GetByIdAsync(id);
        }
        public async Task<Role> GetByNameAsync(string name)
        {
            return await roleDB.GetByNameAsync(name);
        }

        public async Task<Role> UpdateAsync(Role entity)
        {
            return await roleDB.UpdateAsync(entity);
        }

    }
}
