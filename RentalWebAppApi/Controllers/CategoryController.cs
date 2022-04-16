
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RentalWebAppApi.Exceptions;
using RentalWebAppApi.Models;
using RentalWebService.DTOs;
using RentalWebService.IServices;

namespace RentalWebAppApi.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class CategoryController : PrivateController
    {
        private readonly ICategoryService categoryService;
        private readonly IAdminUserService adminUserService;
        public CategoryController(ICategoryService categoryService, IAdminUserService adminUserService)
        {
            this.categoryService = categoryService;
            this.adminUserService = adminUserService;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> Get()
        {
            var categoryModel = new CategoryModel();
            try
            {
                var categories = await categoryService.Get();
                if (categories.Any())
                {
                    categoryModel.CategoryDtoList = categories;
                    categoryModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    categoryModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                categoryModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, categoryModel);
            }
            return Ok(categoryModel);

        }
        [HttpGet]
        [Route("api/[controller]/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var categoryModel = new CategoryModel();
            try
            {
                var categoryDto = await categoryService.GetById(Id);
                if (categoryDto != null)
                {
                    categoryModel.CategoryDto = categoryDto;
                    categoryModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    categoryModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                categoryModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, categoryModel);
            }
            return Ok(categoryModel);
        }
        [HttpPost]
        [Route("api/[controller]")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Add(CategoryDto categoryDto)
        {
            try
            {
                var userId = Convert.ToInt64(User.FindFirst("Id")?.Value);
                var valid = await adminUserService.GetById(userId);
                if (valid != null)
                {
                    var response = await categoryService.Add(categoryDto);
                return Ok(new CategoryModel { ResponseDto = response });
                }
                else
                {
                    return Ok(new CategoryModel { ResponseDto = GetAuthorizeResponse() }); ;
                }
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new CategoryModel { ResponseDto = ResponseDto });
            }
        }
        [HttpDelete]
        [Route("api/[controller]/{Id}")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Delete(Int64 Id)
        {
            try
            {
                var userId = Convert.ToInt64(User.FindFirst("Id")?.Value);
                var valid = await adminUserService.GetById(userId);
                if (valid != null)
                {
                    var response = await categoryService.DeleteById(Id);
                return Ok(new CategoryModel { ResponseDto = response });
                }
                else
                {
                    return Ok(new CategoryModel { ResponseDto = GetAuthorizeResponse() }); ;
                }
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new CategoryModel { ResponseDto = ResponseDto });
            }
        }
        [HttpPatch]
        [Route("api/[controller]")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            try
            {
                var userId = Convert.ToInt64(User.FindFirst("Id")?.Value);
                var valid = await adminUserService.GetById(userId);
                if (valid != null)
                {
                    var response = await categoryService.Update(categoryDto);
                return Ok(new CategoryModel { ResponseDto = response });
                }
                else
                {
                    return Ok(new CategoryModel { ResponseDto = GetAuthorizeResponse() }); ;
                }
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new CategoryModel { ResponseDto = ResponseDto });
            }
        }
    }
}
