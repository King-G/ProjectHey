using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectHey.DOMAIN.Contracts
{
    public interface IUserAdvertisement : IGeneric<UserAdvertisement>
    {
        Task<IEnumerable<UserAdvertisement>> GetByViewDate(DateTime date);
    }
}
