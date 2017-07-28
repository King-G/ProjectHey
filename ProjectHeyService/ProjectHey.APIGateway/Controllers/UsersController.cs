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
                if (string.IsNullOrWhiteSpace(facebookId))
                    throw new NullReferenceException();

                User user = await userManager.GetByFacebookId(facebookId);
                return Ok(Json(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> CreateConnectionForUser([FromBody]User requestor)
        {
            try
            {
                if (requestor == null)
                    throw new NullReferenceException();

                Connection connection = await userManager.CreateConnectionForUser(requestor);
                return Ok(Json(connection));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //[HttpGet]
        //public async Task<IActionResult> GetUserNameById(int id)
        //{
        //    try
        //    {
        //        User user = await userManager.GetByIdAsync(id);
        //        return Ok(Json(user.Username));
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
        //[HttpGet]
        //public async Task<IActionResult> GetByLocation([FromBody]User requestor, int skip, int take)
        //{
        //    try
        //    {
        //        if (requestor == null)
        //            throw new NullReferenceException();

        //        IEnumerable<User> users = await userManager.GetUsersByLocationAsync(requestor, skip, take);
        //        return Ok(Json(users));

        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpPost]
        //[ValidateModel]
        //localhost:5000/api/users/create?Id=0&firstname=test&....
        public async Task<IActionResult> Create([FromBody]User user)
        {
            try
            {
                if (user == null)
                    throw new NullReferenceException();

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
        public async Task<IActionResult> Update([FromBody]User user)
        {
            try
            {
                if (user == null)
                    throw new NullReferenceException();

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
