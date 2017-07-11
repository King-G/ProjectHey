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
    public class MessageDB : IMessage
    {
        private readonly ProjectHeyContext projectHeyContext = new ProjectHeyContext();

        public async Task<Message> CreateAsync(Message entity)
        {
            projectHeyContext.Message.Add(entity);
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Message>> CreateRangeAsync(List<Message> entities)
        {
            projectHeyContext.Message.AddRange(entities);
            await projectHeyContext.SaveChangesAsync();
            return entities;
        }

        public async Task<Message> DeleteAsync(Message entity)
        {
            projectHeyContext.Message.Remove(projectHeyContext.Message.Single(x => x.Id == entity.Id));
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await projectHeyContext.Message.CountAsync();
        }

        public async Task<IEnumerable<Message>> GetAsync(int skip, int take)
        {
            return await projectHeyContext.Message.AsNoTracking().OrderBy(x => x.Id).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<IEnumerable<Message>> GetAllConversationsFromUserId(int userId)
        {
            return await projectHeyContext.Message.AsNoTracking()
                .Include(x => x.UserReceiver)
                .Include(x => x.UserSender)
                .OrderBy(x => x.CreationDate)
                .Where(x => x.UserSenderId == userId || x.UserReceiverId == userId).ToListAsync();
        }
        public async Task<Message> GetByIdAsync(int id)
        {
            return await projectHeyContext.Message.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<Message>> GetConversationsAsync(int userOne, int userTwo, int skip, int take)
        {
            return await projectHeyContext.Message.Where(x => (x.UserSenderId == userOne || x.UserSenderId == userTwo) &&
                                               (x.UserReceiverId == userOne || x.UserReceiverId == userTwo)).OrderBy(x => x.CreationDate).Skip(skip).Take(take).ToListAsync();
        }
        public async Task<Message> UpdateAsync(Message entity)
        {
            projectHeyContext.Message.Attach(entity);
            projectHeyContext.Entry<Message>(entity).State = EntityState.Modified;
            await projectHeyContext.SaveChangesAsync();
            return entity;
        }

    }
}
