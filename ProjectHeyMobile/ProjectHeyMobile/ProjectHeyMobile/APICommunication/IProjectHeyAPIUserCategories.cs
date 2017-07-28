using ProjectHey.DOMAIN;
using ProjectHeyMobile.ViewModels;
using Refit;
using System.Threading.Tasks;

namespace ProjectHeyMobile.APICommunication
{
    public interface IProjectHeyAPIUserCategories
    {
        [Post("/usercategories/create")]
        Task<string> Create([Body]UserCategory usercategory, bool isinroom);

        [Post("/usercategories/delete")]
        Task<string> Delete([Body]UserCategory usercategory);
    }
}
