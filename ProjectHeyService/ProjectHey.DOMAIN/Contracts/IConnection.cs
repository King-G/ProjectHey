using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectHey.DOMAIN.Contracts
{
    public interface IConnection : IGeneric<Connection>
    {
        Task<IEnumerable<Connection>> GetByIdAsync(int id, int skip, int take);
        Task<IEnumerable<Connection>> GetAllByIdAsync(int id);

    }
}
