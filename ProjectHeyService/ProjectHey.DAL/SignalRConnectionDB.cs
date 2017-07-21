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
    public class SignalRConnectionDB : ISignalRConnection
    {
        private readonly ProjectHeyContext projectHeyContext = new ProjectHeyContext();

        public async Task<SignalRConnection> CreateAsync(SignalRConnection entity)
        {
            projectHeyContext.SignalRConnection.Add(entity);
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<SignalRConnection>> CreateRangeAsync(List<SignalRConnection> entities)
        {
            projectHeyContext.SignalRConnection.AddRange(entities);
            await projectHeyContext.SaveChangesAsync();
            return entities;
        }

        public async Task<SignalRConnection> DeleteAsync(SignalRConnection entity)
        {
            projectHeyContext.SignalRConnection.Remove(projectHeyContext.SignalRConnection.Single(x => x.Id == entity.Id));
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await projectHeyContext.SignalRConnection.CountAsync();
        }

        public async Task<IEnumerable<SignalRConnection>> GetAsync(int skip, int take)
        {
            return await projectHeyContext.SignalRConnection.AsNoTracking().OrderBy(x => x.Id).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<SignalRConnection> GetByIdAsync(int id)
        {
            return await projectHeyContext.SignalRConnection.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<SignalRConnection> UpdateAsync(SignalRConnection entity)
        {
            projectHeyContext.SignalRConnection.Attach(entity);
            projectHeyContext.Entry<SignalRConnection>(entity).State = EntityState.Modified;
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

    }
}
