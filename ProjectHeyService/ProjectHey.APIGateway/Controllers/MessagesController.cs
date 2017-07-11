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
    public class MessagesController : Controller
    {
        MessageManager messageManager = new MessageManager();

        [HttpGet]
        public async Task<IActionResult> GetByUserId(int id)
        {
            try
            {
                IEnumerable<Message> messages = await messageManager.GetAllConversationsFromUserId(id);              
                return Ok(Json(messages));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
