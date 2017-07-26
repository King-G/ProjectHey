
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectHey.DOMAIN.Contracts
{
    public interface IUserCategory : IGeneric<UserCategory>
    {
        Task<IEnumerable<UserCategory>> GetAllByIdAsync (int userId);
    }
}
