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
    public class ProviderManager : IProvider
    {
        private readonly ProviderDB providerDB = new ProviderDB();

        public async Task<Provider> CreateAsync(Provider entity)
        {
            return await providerDB.CreateAsync(entity);
        }

        public async Task<IEnumerable<Provider>> CreateRangeAsync(List<Provider> entities)
        {
            return await providerDB.CreateRangeAsync(entities);
        }

        public async Task<Provider> DeleteAsync(Provider entity)
        {
            return await providerDB.DeleteAsync(entity);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await providerDB.GetTotalCountAsync();
        }

        public async Task<IEnumerable<Provider>> GetAsync(int skip, int take)
        {
            return await providerDB.GetAsync(skip, take);
        }

        public async Task<Provider> GetByIdAsync(int id)
        {
            return await providerDB.GetByIdAsync(id);
        }

        public async Task<Provider> GetByNameAsync(string name)
        {
            return await providerDB.GetByNameAsync(name);
        }

        public async Task<Provider> UpdateAsync(Provider entity)
        {
            return await providerDB.UpdateAsync(entity);
        }
    }
}
