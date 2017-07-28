using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectHey.BLL;
using ProjectHey.DOMAIN;

namespace ProjectHey.APIGateway.Controllers
{
    //[Route("api/[controller]")]
    //[ValidateModel]
    public class UserCategoriesController : Controller
    {
        UserCategoryManager usercategoryManager = new UserCategoryManager();

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]UserCategory usercategory, bool isinroom)
        {
            try
            {
                if (usercategory == null)
                    throw new NullReferenceException();

                usercategory = await usercategoryManager.CreateAndAddToRoom(usercategory, isinroom);
                return Ok(Json(usercategory));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete([FromBody]UserCategory usercategory)
        {
            try
            {
                if (usercategory == null)
                    throw new NullReferenceException();

                await usercategoryManager.DeleteAsync(usercategory);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
