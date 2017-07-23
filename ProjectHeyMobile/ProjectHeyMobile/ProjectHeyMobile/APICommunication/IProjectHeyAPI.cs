using ProjectHey.DOMAIN;
using ProjectHeyMobile.ViewModels;
using Refit;
using System.Threading.Tasks;

namespace ProjectHeyMobile.APICommunication
{
    public interface IProjectHeyAPI
    {
        [Get("/users/getbyfacebookid/{id}")]
        Task<string> UserGetByFacebookId(string id);

        [Get("/users/getbyid/{id}")]
        Task<string> UserGetById(int id);

        [Get("/connections/getbyuserid/{id}")]
        Task<string> ConnectionsGetByUserId(int id);

        [Get("/connections/getconnectionsviewmodelsbyuserid/{id}")]
        Task<string> GetConnectionsViewModelsByUserId(int id);

        [Post("/appsettings/update")]
        Task<string> AppSettingsUpdate([Body(BodySerializationMethod.UrlEncoded)]AppSettingViewModel appsettings);

        [Post("/users/create")]
        Task<string> CreateUser ([Body(BodySerializationMethod.UrlEncoded)]User user);

        [Post("/users/update")]
        Task<string> SyncUser([Body(BodySerializationMethod.UrlEncoded)]User user);
    }
}
