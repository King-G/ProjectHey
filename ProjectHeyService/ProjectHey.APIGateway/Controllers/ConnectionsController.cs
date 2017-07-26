using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectHey.BLL;
using ProjectHey.DOMAIN;
//using ProjectHey.APIGateway.Attribute;
using Newtonsoft.Json;
using ProjectHey.APIGateway.ViewModels;

namespace ProjectHey.APIGateway.Controllers
{
    //[Route("api/[controller]")]
    //[ValidateModel]
    public class ConnectionsController : Controller
    {
        ConnectionManager connectionManager = new ConnectionManager();

        [HttpGet]
        public async Task<IActionResult> GetAllByUserId(int id)
        {
            try
            {
                IEnumerable<Connection> connections = await connectionManager.GetAllByIdAsync(id);
                return Ok(Json(connections));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetConnectionsViewModelsByUserId(int id)
        {
            try
            {
                IEnumerable<Connection> connections = await connectionManager.GetAllByIdAsync(id);
                List<ConnectionViewModel> connectionviewModels = new List<ConnectionViewModel>();
                foreach (Connection connection in connections)
                {
                    connectionviewModels.Add(
                        new ConnectionViewModel()
                        {
                            UserId = connection.UserId,
                            UserConnectionId = connection.UserConnectionId,
                            Username = string.Join(string.Empty, connection.UserConnection.Username.Skip(25)),
                            Progress = connection.Progress,
                        });
                }
                return Ok(Json(connectionviewModels));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
