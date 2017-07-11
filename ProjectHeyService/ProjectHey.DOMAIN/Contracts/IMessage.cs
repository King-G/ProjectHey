using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectHey.DOMAIN.Contracts
{
    public interface IMessage : IGeneric<Message>
    {
        Task<IEnumerable<Message>> GetAllConversationsFromUserId(int userId);
        Task<IEnumerable<Message>> GetConversationsAsync(int userOne, int userTwo, int skip, int take);
    }
}
