using ProjectHeyMobile.Models;
using Refit;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjectHeyMobile.Interfaces
{
    public interface IProjectHeyAPI
    {
        [Get("/connections/getbyuserid/{id}")]
        Task<string> GetConnectionsByUserId(int id);

        [Get("/connections/getconnectionsviewmodelsbyuserid/{id}")]
        Task<string> GetConnectionsViewModelsByUserId(int id);
    }
}
