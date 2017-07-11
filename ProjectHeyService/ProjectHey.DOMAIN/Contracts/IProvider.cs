using System.Threading.Tasks;

namespace ProjectHey.DOMAIN.Contracts
{
    public interface IProvider : IGeneric<Provider>
    {
        Task<Provider> GetByNameAsync(string name);
    }
}
