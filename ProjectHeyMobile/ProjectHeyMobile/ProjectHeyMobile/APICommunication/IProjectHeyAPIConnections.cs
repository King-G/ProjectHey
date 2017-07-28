using ProjectHey.DOMAIN;
using ProjectHeyMobile.ViewModels;
using Refit;
using System.Threading.Tasks;

namespace ProjectHeyMobile.APICommunication
{
    public interface IProjectHeyAPIConnections
    {
        [Post("/connections/create")]
        Task<string> Create([Body]Connection connection);

        [Post("/connections/update")]
        Task<string> Update([Body]Connection connection);

        [Get("/connections/getallbyuserid/{id}")]
        Task<string> GetAllByUserId(int id);

    }
}
