using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectHey.DOMAIN.Contracts
{
    public interface IFeedback : IGeneric<Feedback>
    {
        Task<IEnumerable<Feedback>> GetByRating(int rating, int skip, int take);

    }
}
