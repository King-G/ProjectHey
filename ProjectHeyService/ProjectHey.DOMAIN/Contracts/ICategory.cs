
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectHey.DOMAIN.Contracts
{
    public interface ICategory : IGeneric<Category>
    {
        Task<Category> CreateProtectedCategory(Category entity, string password);
        Task<int> GetTotalUsersForCategory(Category entity);
        Task<int> GetTotalSignalRUsersForCategory(Category entity);
        Task<IEnumerable<Category>> GetOrderByTotalUsersAsync(int skip, int take);
        Task<IEnumerable<Category>> GetOrderByTotalSignalRUsersAsync(int skip, int take);
        Task<IEnumerable<Category>> GetBySearchNameAsync(string searchname, int skip, int take);

    }
}
