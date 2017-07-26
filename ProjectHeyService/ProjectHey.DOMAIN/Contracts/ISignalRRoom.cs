using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectHey.DOMAIN.Contracts
{
    public interface ISignalRRoom : IGeneric<SignalRRoom>
    {
        Task<SignalRRoom> GetByNameAsync(string roomname);
    }
}
