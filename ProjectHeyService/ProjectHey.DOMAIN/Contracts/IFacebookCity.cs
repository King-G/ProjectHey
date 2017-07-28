
using System.Threading.Tasks;

namespace ProjectHey.DOMAIN.Contracts
{
    public interface IFacebookCity : IGeneric<FacebookCity>
    {
        Task<FacebookCity> GetByCityIdAsync(string cityId);
    }
}
