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
    public class UserAdvertisementManager : IUserAdvertisement
    {
        private readonly UserAdvertisementDB userAdvertisementDB = new UserAdvertisementDB();

        public async Task<UserAdvertisement> CreateAsync(UserAdvertisement entity)
        {
            return await userAdvertisementDB.CreateAsync(entity);
        }

        public async Task<IEnumerable<UserAdvertisement>> CreateRangeAsync(List<UserAdvertisement> entities)
        {
            return await userAdvertisementDB.CreateRangeAsync(entities);
        }

        public async Task<UserAdvertisement> DeleteAsync(UserAdvertisement entity)
        {
            return await userAdvertisementDB.DeleteAsync(entity);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await userAdvertisementDB.GetTotalCountAsync();
        }

        public async Task<IEnumerable<UserAdvertisement>> GetAsync(int skip, int take)
        {
            return await userAdvertisementDB.GetAsync(skip, take);
        }

        public async Task<UserAdvertisement> GetByIdAsync(int id)
        {
            return await userAdvertisementDB.GetByIdAsync(id);
        }

        public async Task<IEnumerable<UserAdvertisement>> GetByViewDate(DateTime date)
        {
            return await userAdvertisementDB.GetByViewDate(date);
        }

        public async Task<UserAdvertisement> UpdateAsync(UserAdvertisement entity)
        {
            return await userAdvertisementDB.UpdateAsync(entity);
        }
    }
}
