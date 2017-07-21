using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectHey.DOMAIN.Contracts
{
    public interface ISignalRConversationRoom : IGeneric<SignalRConversationRoom>
    {
        Task<SignalRConversationRoom> GetByNameAsync(string roomname);
    }
}
