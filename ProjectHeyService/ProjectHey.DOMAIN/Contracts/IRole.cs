using System.Threading.Tasks;

namespace ProjectHey.DOMAIN.Contracts
{
    public interface IRole : IGeneric<Role>
    {
        Task<Role> GetByNameAsync(string name);
    }
}
