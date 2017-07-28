using ProjectHey.DOMAIN;
using ProjectHeyMobile.ViewModels;
using Refit;
using System.Threading.Tasks;

namespace ProjectHeyMobile.APICommunication
{
    public interface IProjectHeyAPIReported
    {
        [Post("/reported/create")]
        Task<string> Create([Body]Reported reported);
    }
}
