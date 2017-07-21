using ProjectHey.DOMAIN;
using ProjectHeyMobile.ViewModels;
using Refit;
using System.Threading.Tasks;

namespace ProjectHeyMobile.APICommunication
{
    public interface IProjectHeyAPI
    {
        [Headers("Authorization: Bearer")]
        [Get("/users/getbyfacebookid/{id}")]
        Task<string> UserGetByFacebookId(int id);

        [Headers("Authorization: Bearer")]
        [Get("/users/getbyid/{id}")]
        Task<string> UserGetById(int id);

        [Headers("Authorization: Bearer")]
        [Get("/connections/getbyuserid/{id}")]
        Task<string> ConnectionsGetByUserId(int id);

        [Headers("Authorization: Bearer")]
        [Get("/connections/getconnectionsviewmodelsbyuserid/{id}")]
        Task<string> GetConnectionsViewModelsByUserId(int id);

        [Post("/appsettings/update")]
        Task<string> AppSettingsUpdate([Body(BodySerializationMethod.UrlEncoded)]AppSettingViewModel appsettings);

        [Headers("Authorization: Bearer")]
        [Post("/users/create")]
        Task<string> CreateUser ([Body(BodySerializationMethod.UrlEncoded)]User user);

        [Headers("Authorization: Bearer")]
        [Post("/users/update")]
        Task<string> SyncUser([Body(BodySerializationMethod.UrlEncoded)]User user);
    }
}
