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
    public class AdvertisementCategoryManager : IAdvertisementCategory
    {
        private readonly AdvertisementCategoryDB advertisementCategoryDB = new AdvertisementCategoryDB();

        public async Task<AdvertisementCategory> CreateAsync(AdvertisementCategory entity)
        {
            return await advertisementCategoryDB.CreateAsync(entity);
        }

        public async Task<IEnumerable<AdvertisementCategory>> CreateRangeAsync(List<AdvertisementCategory> entities)
        {
            return await advertisementCategoryDB.CreateRangeAsync(entities);
        }

        public async Task<AdvertisementCategory> DeleteAsync(AdvertisementCategory entity)
        {
            return await advertisementCategoryDB.DeleteAsync(entity);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await advertisementCategoryDB.GetTotalCountAsync();
        }

        public async Task<IEnumerable<AdvertisementCategory>> GetAsync(int skip, int take)
        {
            return await advertisementCategoryDB.GetAsync(skip, take);
        }

        public async Task<AdvertisementCategory> GetByIdAsync(int id)
        {
            return await advertisementCategoryDB.GetByIdAsync(id);
        }

        public async Task<AdvertisementCategory> UpdateAsync(AdvertisementCategory entity)
        {
            return await advertisementCategoryDB.UpdateAsync(entity);
        }
    }
}
