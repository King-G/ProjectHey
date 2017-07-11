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
    public class MessageManager : IMessage
    {
        private readonly MessageDB messageDB = new MessageDB();

        public async Task<Message> CreateAsync(Message entity)
        {
            return await messageDB.CreateAsync(entity);
        }

        public async Task<IEnumerable<Message>> CreateRangeAsync(List<Message> entities)
        {
            return await messageDB.CreateRangeAsync(entities);
        }

        public async Task<Message> DeleteAsync(Message entity)
        {
            return await messageDB.DeleteAsync(entity);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await messageDB.GetTotalCountAsync();
        }

        public async Task<IEnumerable<Message>> GetAsync(int skip, int take)
        {
            return await messageDB.GetAsync(skip, take);
        }

        public async Task<Message> GetByIdAsync(int id)
        {
            return await messageDB.GetByIdAsync(id);
        }
        public async Task<IEnumerable<Message>> GetAllConversationsFromUserId(int userId)
        {
            return await messageDB.GetAllConversationsFromUserId(userId);
        }
        public async Task<IEnumerable<Message>> GetConversationsAsync(int userOne, int userTwo, int skip, int take)
        {
            return await messageDB.GetConversationsAsync(userOne, userTwo, skip, take);
        }
        public async Task<Message> UpdateAsync(Message entity)
        {
            return await messageDB.UpdateAsync(entity);
        }
    }
}
