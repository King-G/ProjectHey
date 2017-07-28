using ProjectHey.DOMAIN;
using ProjectHeyMobile.ViewModels;
using Refit;
using System.Threading.Tasks;

namespace ProjectHeyMobile.APICommunication
{
    public interface IProjectHeyAPICategories
    {
        [Post("/categories/create")]
        Task<string> Create([Body]Category category);

        [Post("/categories/update")]
        Task<string> Update([Body]Category category);

        [Get("/categories/getorderbytotalusers/?skip={skip}&take={take}")]
        Task<string> GetOrderByTotalUsers(int skip, int take);

        [Get("/categories/getorderbytotalsignalusers/?skip={skip}&take={take}")]
        Task<string> GetOrderByTotalSignalRUsers(int skip, int take);

        [Get("/categories/getbysearchname/?searchname={searchname}&skip={skip}&take={take}")]
        Task<string> GetBySearchName(string searchname, int skip, int take);
    }
}
