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
    public class ProviderDB : IProvider
    {
        private readonly ProjectHeyContext projectHeyContext = new ProjectHeyContext();

        public async Task<Provider> CreateAsync(Provider entity)
        {
            projectHeyContext.Provider.Add(entity);
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Provider>> CreateRangeAsync(List<Provider> entities)
        {
            projectHeyContext.Provider.AddRange(entities);
            await projectHeyContext.SaveChangesAsync();
            return entities;
        }

        public async Task<Provider> DeleteAsync(Provider entity)
        {
            projectHeyContext.Provider.Remove(projectHeyContext.Provider.Single(x => x.Id == entity.Id));
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await projectHeyContext.Provider.CountAsync();
        }

        public async Task<IEnumerable<Provider>> GetAsync(int skip, int take)
        {
            return await projectHeyContext.Provider.AsNoTracking().OrderBy(x => x.Id).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<Provider> GetByIdAsync(int id)
        {
            return await projectHeyContext.Provider.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Provider> GetByNameAsync(string name)
        {
            return await projectHeyContext.Provider.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<Provider> UpdateAsync(Provider entity)
        {
            projectHeyContext.Provider.Attach(entity);
            projectHeyContext.Entry<Provider>(entity).State = EntityState.Modified;
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }
    }
}
