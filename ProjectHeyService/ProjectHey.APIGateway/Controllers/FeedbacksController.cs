using System;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectHey.BLL;
using ProjectHey.DOMAIN;

namespace ProjectHey.APIGateway.Controllers
{
    //[Route("api/[controller]")]
    //[ValidateModel]
    public class FeedbacksController : Controller
    {
        FeedbackManager feedbackManager = new FeedbackManager();

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Feedback feedback)
        {
            try
            {
                if (feedback == null)
                    throw new NullReferenceException();

                feedback = await feedbackManager.CreateAsync(feedback);
                return Ok(Json(feedback));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
