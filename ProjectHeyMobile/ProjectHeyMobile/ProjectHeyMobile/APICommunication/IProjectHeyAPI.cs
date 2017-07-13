using ProjectHeyMobile.ViewModels;
using Refit;
using System.Threading.Tasks;

namespace ProjectHeyMobile.APICommunication
{
    public interface IProjectHeyAPI
    {
        [Get("/users/getbyid/{id}")]
        Task<string> UserGetById(int id);

        [Get("/connections/getbyuserid/{id}")]
        Task<string> ConnectionsGetByUserId(int id);

        [Get("/connections/getconnectionsviewmodelsbyuserid/{id}")]
        Task<string> GetConnectionsViewModelsByUserId(int id);

        [Get("/AppSettings/Update/{appSettingViewModel}")]
        Task<string> AppSettingsUpdate(AppSettingViewModel appSettingViewModel);
    }
}
