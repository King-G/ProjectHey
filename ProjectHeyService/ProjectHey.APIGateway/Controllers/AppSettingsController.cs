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
        public async Task<IActionResult> Update(AppSetting appsettings)
        {
            try
            {
                AppSetting appsetting = await appSettingManager.UpdateAsync(appsettings);
                return Ok(Json(appsetting));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
