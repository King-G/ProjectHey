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
        public async Task<IEnumerable<User>> GetByLocation(User requestor, int skip, int take)
        {
            return await userManager.GetByLocationAsync(requestor, skip, take);
        }

        [HttpPost]
        //[ValidateModel]
        //localhost:5000/api/users/create?Id=0&firstname=test&....
        public async Task<User> Create(User user)
        {
            return await userManager.CreateAsync(user);
        }

        [HttpPost]
        //[ValidateModel]
        public async Task<User> Update(User user)
        {
            return await userManager.UpdateAsync(user);
        }

        // DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{

        //}
    }
}
