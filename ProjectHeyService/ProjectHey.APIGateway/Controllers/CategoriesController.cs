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
    public class CategoriesController : Controller
    {
        CategoryManager categoryManager = new CategoryManager();

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Category category, string password)
        {
            try
            {
                if (category == null)
                    throw new NullReferenceException();

                category = await categoryManager.CreateProtectedCategory(category, password);
                return Ok(Json(category));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderByTotalUsers(int skip, int take)
        {
            try
            {
                IEnumerable<Category> categories = await categoryManager.GetOrderByTotalUsersAsync(skip, take);
                return Ok(Json(categories));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetOrderByTotalSignalRUsers(int skip, int take)
        {
            try
            {
                IEnumerable<Category> categories = await categoryManager.GetOrderByTotalSignalRUsersAsync(skip, take);
                return Ok(Json(categories));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetBySearchName(string searchname, int skip, int take)
        {
            try
            {
                IEnumerable<Category> categories = await categoryManager.GetBySearchNameAsync(searchname, skip, take);
                return Ok(Json(categories));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
