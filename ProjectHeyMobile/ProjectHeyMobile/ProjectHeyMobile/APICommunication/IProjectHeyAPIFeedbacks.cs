using ProjectHey.DOMAIN;
using ProjectHeyMobile.ViewModels;
using Refit;
using System.Threading.Tasks;

namespace ProjectHeyMobile.APICommunication
{
    public interface IProjectHeyAPIFeedbacks
    {
        [Post("/feedbacks/create")]
        Task<string> Create([Body]Feedback feedback);
    }
}
