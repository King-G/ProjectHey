using ProjectHey.DOMAIN;
using ProjectHeyMobile.ViewModels;
using Refit;
using System.Threading.Tasks;

namespace ProjectHeyMobile.APICommunication
{
    public interface IProjectHeyAPIUsers
    {
        [Post("/users/create")]
        Task<string> Create([Body]User user);

        [Post("/users/update")]
        Task<string> Update([Body]User user);
        [Post("/users/createconnectionforuser")]
        Task<string> CreateConnectionForUser([Body]User requestor);

        [Get("/users/getbyid/{id}")]
        Task<string> GetById(int id);

        [Get("/users/getbyfacebookid/?facebookid={facebookId}")]
        Task<string> GetByFacebookId(string facebookId);

        

        
    }
}
