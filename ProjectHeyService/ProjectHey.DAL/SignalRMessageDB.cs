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
    public class SignalRMessageDB : ISignalRMessage
    {
        private readonly ProjectHeyContext projectHeyContext = new ProjectHeyContext();

        public async Task<SignalRMessage> CreateAsync(SignalRMessage entity)
        {
            projectHeyContext.SignalRMessage.Add(entity);
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<SignalRMessage>> CreateRangeAsync(List<SignalRMessage> entities)
        {
            projectHeyContext.SignalRMessage.AddRange(entities);
            await projectHeyContext.SaveChangesAsync();
            return entities;
        }

        public async Task<SignalRMessage> DeleteAsync(SignalRMessage entity)
        {
            projectHeyContext.SignalRMessage.Remove(projectHeyContext.SignalRMessage.Single(x => x.Id == entity.Id));
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await projectHeyContext.SignalRMessage.CountAsync();
        }

        public async Task<IEnumerable<SignalRMessage>> GetAsync(int skip, int take)
        {
            return await projectHeyContext.SignalRMessage.AsNoTracking().OrderBy(x => x.Id).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<SignalRMessage> GetByIdAsync(int id)
        {
            return await projectHeyContext.SignalRMessage.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<SignalRMessage> UpdateAsync(SignalRMessage entity)
        {
            projectHeyContext.SignalRMessage.Attach(entity);
            projectHeyContext.Entry<SignalRMessage>(entity).State = EntityState.Modified;
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

    }
}
