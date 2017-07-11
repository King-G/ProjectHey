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
    public class AppSettingManager : IAppSetting
    {
        private readonly AppSettingDB appSettingDB = new AppSettingDB();

        public async Task<AppSetting> CreateAsync(AppSetting entity)
        {
            return await appSettingDB.CreateAsync(entity);
        }

        public async Task<IEnumerable<AppSetting>> CreateRangeAsync(List<AppSetting> entities)
        {
            return await appSettingDB.CreateRangeAsync(entities);
        }

        public async Task<AppSetting> DeleteAsync(AppSetting entity)
        {
            return await appSettingDB.DeleteAsync(entity);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await appSettingDB.GetTotalCountAsync();
        }

        public async Task<IEnumerable<AppSetting>> GetAsync(int skip, int take)
        {
            return await appSettingDB.GetAsync(skip, take);
        }

        public async Task<AppSetting> GetByIdAsync(int id)
        {
            return await appSettingDB.GetByIdAsync(id);
        }

        public async Task<AppSetting> UpdateAsync(AppSetting entity)
        {
            return await appSettingDB.UpdateAsync(entity);
        }
    }
}
