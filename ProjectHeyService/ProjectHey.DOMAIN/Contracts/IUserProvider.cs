using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectHey.DOMAIN.Contracts
{
    public interface IUserProvider: IGeneric<UserProvider>
    {
        Task<IEnumerable<UserProvider>> GetByUserIdAsync(int userId, int skip, int take);
    }
}
