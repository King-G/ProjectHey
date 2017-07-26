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
    public class SignalRController : Controller
    {

        [HttpGet]
        public async Task<IActionResult> GetSignalRUserById(int id)
        {
            try
            {
                SignalRUserManager signalRUserManager = new SignalRUserManager();
                SignalRUser signalRUser = await signalRUserManager.GetByIdAsync(id);
                return Ok(Json(signalRUser));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetSignalRRoomByName(string roomname)
        {
            try
            {
                SignalRRoomManager signalRUserConversationRoomManager = new SignalRRoomManager();
                SignalRRoom room = await signalRUserConversationRoomManager.GetByNameAsync(roomname);
                return Ok(Json(room));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateSignalRUser(SignalRUser signalRUser)
        {
            try
            {
                SignalRUserManager signalRUserManager = new SignalRUserManager();
                signalRUser = await signalRUserManager.CreateAsync(signalRUser);
                return Ok(Json(signalRUser));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateSignalRConversationRoom(SignalRRoom signalRConversationRoom)
        {
            try
            {
                SignalRRoomManager signalConversationRoomManager = new SignalRRoomManager();
                signalRConversationRoom = await signalConversationRoomManager.CreateAsync(signalRConversationRoom);
                return Ok(Json(signalRConversationRoom));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteSignalRUserConversationRoom(SignalRUserRoom signalRUserConversationRoom)
        {
            try
            {
                SignalRUserRoomManager signalRUserConversationRoomManager = new SignalRUserRoomManager();
                await signalRUserConversationRoomManager.DeleteAsync(signalRUserConversationRoom);
                return Ok(Json(signalRUserConversationRoom));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
