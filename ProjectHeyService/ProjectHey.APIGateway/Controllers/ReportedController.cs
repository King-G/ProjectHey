using System;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectHey.BLL;
using ProjectHey.DOMAIN;

namespace ProjectHey.APIGateway.Controllers
{
    //[Route("api/[controller]")]
    //[ValidateModel]
    public class ReportedController : Controller
    {
        ReportedManager reportedManager = new ReportedManager();

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Reported reported)
        {
            try
            {
                if (reported == null)
                    throw new NullReferenceException();

                reported = await reportedManager.CreateAsync(reported);
                return Ok(Json(reported));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
