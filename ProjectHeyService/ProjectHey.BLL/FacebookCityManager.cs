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
    public class FacebookCityManager : IFacebookCity
    {
        private readonly FacebookCityDB facebookCityDB = new FacebookCityDB();

        public async Task<FacebookCity> CreateAsync(FacebookCity entity)
        {
            return await facebookCityDB.CreateAsync(entity);
        }

        public async Task<IEnumerable<FacebookCity>> CreateRangeAsync(List<FacebookCity> entities)
        {
            return await facebookCityDB.CreateRangeAsync(entities);
        }

        public async Task<FacebookCity> DeleteAsync(FacebookCity entity)
        {
            return await facebookCityDB.DeleteAsync(entity);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await facebookCityDB.GetTotalCountAsync();
        }

        public async Task<IEnumerable<FacebookCity>> GetAsync(int skip, int take)
        {
            return await facebookCityDB.GetAsync(skip, take);
        }

        public async Task<FacebookCity> GetByIdAsync(int id)
        {
            return await facebookCityDB.GetByIdAsync(id);
        }
        public async Task<FacebookCity> GetByCityIdAsync(string cityId)
        {
            return await facebookCityDB.GetByCityIdAsync(cityId);
        }
        public async Task<FacebookCity> UpdateAsync(FacebookCity entity)
        {
            return await facebookCityDB.UpdateAsync(entity);
        }

        
    }
}
