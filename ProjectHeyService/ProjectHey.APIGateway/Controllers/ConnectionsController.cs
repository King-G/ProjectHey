using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectHey.BLL;
using ProjectHey.DOMAIN;


namespace ProjectHey.APIGateway.Controllers
{
    //[Route("api/[controller]")]
    //[ValidateModel]
    public class ConnectionsController : Controller
    {
        ConnectionManager connectionManager = new ConnectionManager();

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Connection connection)
        {
            try
            {
                if (connection == null)
                    throw new NullReferenceException();

                connection = await connectionManager.CreateAsync(connection);
                return Ok(Json(connection));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Update([FromBody]Connection connection)
        {
            try
            {
                if (connection == null)
                    throw new NullReferenceException();

                connection = await connectionManager.UpdateAsync(connection);
                return Ok(Json(connection));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
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

    }
}
