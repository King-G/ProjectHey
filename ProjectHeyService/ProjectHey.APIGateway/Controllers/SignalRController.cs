using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectHey.BLL;
using ProjectHey.DOMAIN;

namespace ProjectHey.APIGateway.Controllers
{

    public class SignalRController : Controller
    {

        #region SignalRUser Endpoints
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
        [HttpPost]
        public async Task<IActionResult> CreateSignalRUser([FromBody]SignalRUser signalRUser)
        {
            try
            {
                if (signalRUser == null)
                    throw new NullReferenceException();

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
        public async Task<IActionResult> UpdateSignalRUser([FromBody]SignalRUser signalRUser)
        {
            try
            {
                if (signalRUser == null)
                    throw new NullReferenceException();

                SignalRUserManager signalRUserManager = new SignalRUserManager();
                signalRUser = await signalRUserManager.UpdateAsync(signalRUser);
                return Ok(Json(signalRUser));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region SignalRRoom Endpoints
        [HttpGet]
        public async Task<IActionResult> GetSignalRRoomById(int id)
        {
            try
            {
                SignalRRoomManager signalRRoomManager = new SignalRRoomManager();
                SignalRRoom room = await signalRRoomManager.GetByIdAsync(id);
                return Ok(Json(room));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateSignalRRoom([FromBody]SignalRRoom signalRRoom)
        {
            try
            {
                if (signalRRoom == null)
                    throw new NullReferenceException();

                SignalRRoomManager signalRRoomManager = new SignalRRoomManager();
                signalRRoom = await signalRRoomManager.CreateAsync(signalRRoom);
                return Ok(Json(signalRRoom));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region SignalRUserRoom Endpoints
        [HttpGet]
        public async Task<IActionResult> GetByUserAndRoomId(int userid, int roomid)
        {
            try
            {
                SignalRUserRoomManager signalRUserRoomManager = new SignalRUserRoomManager();
                SignalRUserRoom room = await signalRUserRoomManager.GetByUserAndRoomIdAsync(userid, roomid);
                return Ok(Json(room));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateSignalRUserRoom([FromBody]SignalRUserRoom signalRUserRoom)
        {
            try
            {
                if (signalRUserRoom == null)
                    throw new NullReferenceException();

                SignalRUserRoomManager signalRUserRoomManager = new SignalRUserRoomManager();
                await signalRUserRoomManager.CreateAsync(signalRUserRoom);
                return Ok(Json(signalRUserRoom));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteSignalRUserRoom([FromBody]SignalRUserRoom signalRUserRoom)
        {
            try
            {
                if (signalRUserRoom == null)
                    throw new NullReferenceException();

                SignalRUserRoomManager signalRUserRoomManager = new SignalRUserRoomManager();
                await signalRUserRoomManager.DeleteAsync(signalRUserRoom);
                return Ok(Json(signalRUserRoom));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region SignalRMessage Endpoints
        [HttpPost]
        public async Task<IActionResult> CreateSignalRMessage([FromBody]SignalRMessage signalRMessage)
        {
            try
            {
                if (signalRMessage == null)
                    throw new NullReferenceException();

                SignalRMessageManager signalRMessageManager = new SignalRMessageManager();
                signalRMessage = await signalRMessageManager.CreateAsync(signalRMessage);
                return Ok(Json(signalRMessage));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

    }
}
