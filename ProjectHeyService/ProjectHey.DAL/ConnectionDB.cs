using ProjectHey.DOMAIN.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectHey.DOMAIN;
using Microsoft.EntityFrameworkCore;

namespace ProjectHey.DAL
{
    public class ConnectionDB : IConnection
    {
        private readonly ProjectHeyContext projectHeyContext = new ProjectHeyContext();

        public async Task<Connection> CreateAsync(Connection entity)
        {
            projectHeyContext.Connection.Add(entity);
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Connection>> CreateRangeAsync(List<Connection> entities)
        {
            projectHeyContext.Connection.AddRange(entities);
            await projectHeyContext.SaveChangesAsync();
            return entities;
        }

        public async Task<Connection> DeleteAsync(Connection entity)
        {
            projectHeyContext.Connection.Remove(projectHeyContext.Connection.Single(x => x.UserId == entity.UserId && x.UserConnectionId == entity.UserConnectionId));
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await projectHeyContext.Connection.CountAsync();
        }

        public async Task<IEnumerable<Connection>> GetAsync(int skip, int take)
        {
            return await projectHeyContext.Connection.AsNoTracking().OrderBy(x => x.UserId).Skip(skip).Take(take).ToListAsync();
        }
        public async Task<IEnumerable<Connection>> GetByIdAsync(int id, int skip, int take)
        {
            return await projectHeyContext.Connection.AsNoTracking().Where(x => x.UserId == id).OrderBy(x => x.UserId).Skip(skip).Take(take).ToListAsync();
        }
        public async Task<IEnumerable<Connection>> GetAllByIdAsync(int id)
        {
            return await projectHeyContext.Connection.AsNoTracking()
                .Include(x => x.UserConnection)
                .Where(x => x.UserId == id).OrderBy(x => x.UserId)
                .ToListAsync();
        }
        public Task<Connection> GetByIdAsync(int id)
        {
            throw new NotSupportedException();
        }

        public async Task<Connection> UpdateAsync(Connection entity)
        {
            projectHeyContext.Connection.Attach(entity);
            projectHeyContext.Entry<Connection>(entity).State = EntityState.Modified;
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public Task<Connection> CreateConnectionForUser(User requestor)
        {
            throw new NotImplementedException();
        }
    }
}
