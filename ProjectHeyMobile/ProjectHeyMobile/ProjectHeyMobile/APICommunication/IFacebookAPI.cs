using ProjectHey.DOMAIN;
using ProjectHeyMobile.ViewModels;
using Refit;
using System.Threading.Tasks;

namespace ProjectHeyMobile.APICommunication
{
    public interface IFacebookAPI
    {
        [Get("me?fiels=name,picture,cover,age_range,devices,email,gender,is_verified&access_token={token}")]
        Task<string> GetFacebookProfile(string token);
    }
}
