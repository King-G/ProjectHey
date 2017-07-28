using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectHey.DOMAIN.Contracts
{
    public interface ISignalRUserRoom : IGeneric<SignalRUserRoom>
    {
        Task<SignalRUserRoom> GetByUserAndRoomIdAsync(int userId, int roomId);
    }
}
