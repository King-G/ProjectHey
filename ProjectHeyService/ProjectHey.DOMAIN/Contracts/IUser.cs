using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectHey.DOMAIN.Contracts
{
    public interface IUser : IGeneric<User>
    {
        Task<User> GetByUsernameAsync(string username);

        Task<IEnumerable<User>> GetByLocationAsync(User requestor, int skip, int take);

    }
}
