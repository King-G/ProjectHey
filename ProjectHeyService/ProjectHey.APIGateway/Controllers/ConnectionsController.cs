using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectHey.BLL;
using ProjectHey.DOMAIN;
//using ProjectHey.APIGateway.Attribute;
using Newtonsoft.Json;

namespace ProjectHey.APIGateway.Controllers
{
    //[Route("api/[controller]")]
    //[ValidateModel]
    public class ConnectionsController : Controller
    {
        ConnectionManager connectionManager = new ConnectionManager();

        [HttpGet]
        public async Task<IActionResult> GetByUserId(int id)
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
    }
}
