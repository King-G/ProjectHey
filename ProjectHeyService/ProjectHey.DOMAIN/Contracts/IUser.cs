using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectHey.DOMAIN.Contracts
{
    public interface IUser : IGeneric<User>
    {
        Task<User> GetByUsernameAsync(string username);
        Task<User> GetSimplifiedByIdAsync(int id);
        Task<User> GetByFacebookId(string facebookId);
        Task<IEnumerable<User>> GetByLocationAsync(User requestor, int skip, int take);

    }
}
