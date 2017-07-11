using ProjectHeyMobile.ViewModels;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectHeyMobile.Interfaces
{
    public interface IProjectHeyAPI
    {
        [Get("/connections/getbyuserid/{id}")]
        Task<ICollection<Connection>> GetConnectionsByUserId(int id);
    }
}
