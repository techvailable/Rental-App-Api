
using Microsoft.AspNetCore.Mvc;
using RentalWebAppApi.Exceptions;
using RentalWebAppApi.Models;
using RentalWebService.DTOs;
using RentalWebService.IServices;

namespace RentalWebAppApi.Controllers
{
    [ApiController]
    public class DashboardController : PrivateController
    {
        private readonly IBrandService brandService;
        private readonly ICategoryService categoryService;
        public DashboardController(IBrandService brandService, ICategoryService categoryService)
        {
            this.brandService = brandService;
            this.categoryService = categoryService;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> Get()
        {
            var dashboardModel = new DashboardModel();
            try
            {
                var categories = await categoryService.Get();
                var brandDtos = await brandService.Get();
                if (categories.Any())
                {
                    dashboardModel.CategoryDtos = categories.Take(5).ToList();
                    dashboardModel.BrandDtos = brandDtos.Take(10).ToList();
                    dashboardModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    dashboardModel.ResponseDto = GetNotFoundResponse();
                }   
            }
            catch (Exception ex)
            {
                dashboardModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, dashboardModel);
            }
            return Ok(dashboardModel);

        }

    }
}
