using ProjectHey.DOMAIN.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectHey.DOMAIN.Contracts
{
    public interface IAdvertisement : IGeneric<Advertisement>
    {
        Task<IEnumerable<Advertisement>> GetByAdvertisementTypeAsync(AdvertisementType advertisementType);

        Task<IEnumerable<Advertisement>> GetByLocationAsync(User requestor, int skip, int take);
    }
}
