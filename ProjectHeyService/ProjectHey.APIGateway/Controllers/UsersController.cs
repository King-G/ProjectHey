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
    public class UsersController : Controller
    {
        UserManager userManager = new UserManager();

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                User user = await userManager.GetByIdAsync(id);
                return Ok(Json(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetByFacebookId(string facebookId)
        {
            try
            {
                User user = await userManager.GetByFacebookId(facebookId);
                return Ok(Json(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUserNameById(int id)
        {
            try
            {
                User user = await userManager.GetByIdAsync(id);
                return Ok(Json(user.Username));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IEnumerable<User>> GetByLocation(User requestor, int skip, int take)
        {
            return await userManager.GetUsersByLocationAsync(requestor, skip, take);
        }

        [HttpPost]
        //[ValidateModel]
        //localhost:5000/api/users/create?Id=0&firstname=test&....
        public async Task<IActionResult> Create(User user)
        {
            try
            {
                user = await userManager.CreateAsync(user);
                return Ok(Json(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        //[ValidateModel]
        public async Task<IActionResult> Update(User user)
        {
            try
            {
                user = await userManager.UpdateAsync(user);
                return Ok(Json(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{

        //}
    }
}
