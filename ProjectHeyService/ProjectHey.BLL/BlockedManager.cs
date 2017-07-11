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
    public class BlockedManager : IBlocked
    {
        private readonly BlockedDB blockedDB = new BlockedDB();

        public async Task<Blocked> CreateAsync(Blocked entity)
        {
            return await blockedDB.CreateAsync(entity);
        }

        public async Task<IEnumerable<Blocked>> CreateRangeAsync(List<Blocked> entities)
        {
            return await blockedDB.CreateRangeAsync(entities);
        }

        public async Task<Blocked> DeleteAsync(Blocked entity)
        {
            return await blockedDB.DeleteAsync(entity);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await blockedDB.GetTotalCountAsync();
        }

        public async Task<IEnumerable<Blocked>> GetAsync(int skip, int take)
        {
            return await blockedDB.GetAsync(skip, take);
        }

        public async Task<Blocked> GetByIdAsync(int id)
        {
            return await blockedDB.GetByIdAsync(id);
        }

        public async Task<Blocked> UpdateAsync(Blocked entity)
        {
            return await blockedDB.UpdateAsync(entity);
        }
    }
}
