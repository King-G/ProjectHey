using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectHey.DOMAIN;
using ProjectHey.DOMAIN.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ProjectHey.DAL
{
    public class AppSettingDB : IAppSetting
    {
        private readonly ProjectHeyContext projectHeyContext = new ProjectHeyContext();

        public async Task<AppSetting> CreateAsync(AppSetting entity)
        {
            projectHeyContext.AppSetting.Add(entity);
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<AppSetting>> CreateRangeAsync(List<AppSetting> entities)
        {
            projectHeyContext.AppSetting.AddRange(entities);
            await projectHeyContext.SaveChangesAsync();
            return entities;
        }

        public async Task<AppSetting> DeleteAsync(AppSetting entity)
        {
            projectHeyContext.AppSetting.Remove(projectHeyContext.AppSetting.Single(x => x.Id == entity.Id));
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await projectHeyContext.AppSetting.CountAsync();
        }

        public async Task<IEnumerable<AppSetting>> GetAsync(int skip, int take)
        {
            return await projectHeyContext.AppSetting.AsNoTracking().OrderBy(x => x.Id).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<AppSetting> GetByIdAsync(int id)
        {
            return await projectHeyContext.AppSetting.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<AppSetting> UpdateAsync(AppSetting entity)
        {
            projectHeyContext.AppSetting.Attach(entity);
            projectHeyContext.Entry<AppSetting>(entity).State = EntityState.Modified;
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }
    }
}
