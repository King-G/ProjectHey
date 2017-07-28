using ProjectHey.DOMAIN;
using ProjectHeyMobile.ViewModels;
using Refit;
using System.Threading.Tasks;

namespace ProjectHeyMobile.APICommunication
{
    public interface IProjectHeyAPIAppsettings
    {
        [Post("/appsettings/update")]
        Task<string> Update([Body]AppSetting appsetting);
    }
}
