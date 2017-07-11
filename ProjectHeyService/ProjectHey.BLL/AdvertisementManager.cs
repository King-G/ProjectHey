using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectHey.DOMAIN;
using ProjectHey.DOMAIN.Contracts;
using ProjectHey.DAL;
using ProjectHey.DOMAIN.Enums;

namespace ProjectHey.BLL
{
    public class AdvertisementManager : IAdvertisement
    {
        private readonly AdvertisementDB advertisementDB = new AdvertisementDB();

        public async Task<Advertisement> CreateAsync(Advertisement entity)
        {
            return await advertisementDB.CreateAsync(entity);
        }

        public async Task<IEnumerable<Advertisement>> CreateRangeAsync(List<Advertisement> entities)
        {
            return await advertisementDB.CreateRangeAsync(entities);
        }

        public async Task<Advertisement> DeleteAsync(Advertisement entity)
        {
            return await advertisementDB.DeleteAsync(entity);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await advertisementDB.GetTotalCountAsync();
        }

        public async Task<IEnumerable<Advertisement>> GetAsync(int skip, int take)
        {
            return await advertisementDB.GetAsync(skip, take);
        }

        public async Task<IEnumerable<Advertisement>> GetByAdvertisementTypeAsync(AdvertisementType advertisementType)
        {
            return await advertisementDB.GetByAdvertisementTypeAsync(advertisementType);
        }

        public async Task<Advertisement> GetByIdAsync(int id)
        {
            return await advertisementDB.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Advertisement>> GetByLocationAsync(User requestor, int skip, int take)
        {
            return await advertisementDB.GetByLocationAsync(requestor, skip, take);
        }

        public async Task<Advertisement> UpdateAsync(Advertisement entity)
        {
            return await advertisementDB.UpdateAsync(entity);
        }
    }
}
