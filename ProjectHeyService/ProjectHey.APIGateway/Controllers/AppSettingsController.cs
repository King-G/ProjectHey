using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectHey.BLL;
using ProjectHey.DOMAIN;
//using ProjectHey.APIGateway.Attribute;
using Newtonsoft.Json;
using ProjectHey.APIGateway.ViewModels;

namespace ProjectHey.APIGateway.Controllers
{
    //[Route("api/[controller]")]
    //[ValidateModel]
    public class AppSettingsController : Controller
    {
        AppSettingManager appSettingManager = new AppSettingManager();

        [HttpPost]
        public async Task<IActionResult> Update([FromBody]AppSetting appsetting)
        {
            try
            {
                appsetting = await appSettingManager.UpdateAsync(appsetting);
                return Ok(Json(appsetting));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
