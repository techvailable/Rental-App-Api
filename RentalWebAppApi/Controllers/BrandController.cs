
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalWebAppApi.Models;
using RentalWebService.DTOs;
using RentalWebService.IServices;

namespace RentalWebAppApi.Controllers
{
    [ApiController]
    public class BrandController : PrivateController
    {
        private readonly IBrandService brandService;
        private readonly IAdminUserService adminUserService;
        public BrandController(IBrandService brandService, IAdminUserService adminUserService)
        {
            this.brandService = brandService;
            this.adminUserService = adminUserService;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> Get()
        {
            var brandModel = new BrandModel();
            try
            {
                var categories = await brandService.Get();
                if (categories.Any())
                {
                    brandModel.BrandDtoList = categories;
                    brandModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    brandModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                brandModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, brandModel);
            }
            return Ok(brandModel);

        }
        [HttpGet]
        [Route("api/[controller]/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var brandModel = new BrandModel();
            try
            {
                var brandDto = await brandService.GetById(Id);
                if (brandDto != null)
                {
                    brandModel.BrandDto = brandDto;
                    brandModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    brandModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                brandModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, brandModel);
            }
            return Ok(brandModel);
        }
        [HttpPost]
        [Route("api/[controller]")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Add(BrandDto brandDto)
        {
            try
            {
                var userId = Convert.ToInt64(User.FindFirst("Id")?.Value);
                var valid = await adminUserService.GetById(userId);
                if (valid != null)
                {
                    var response = await brandService.Add(brandDto);
                    return Ok(new BrandModel { ResponseDto = response });
                }
                else
                {
                    return Ok(new BrandModel { ResponseDto = GetAuthorizeResponse() }); ;
                }
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new BrandModel { ResponseDto = ResponseDto });
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
                    var response = await brandService.DeleteById(Id);
                    return Ok(new BrandModel { ResponseDto = response });
                }
                else
                {
                    return Ok(new BrandModel { ResponseDto = GetAuthorizeResponse() }); ;
                }

            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new BrandModel { ResponseDto = ResponseDto });
            }
        }
        [HttpPatch]
        [Route("api/[controller]")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Update(BrandDto brandDto)
        {
            try
            {
                var userId = Convert.ToInt64(User.FindFirst("Id")?.Value);
                var valid = await adminUserService.GetById(userId);
                if (valid != null)
                {
                    var response = await brandService.Update(brandDto);
                    return Ok(new BrandModel { ResponseDto = response });
                }
                else
                {
                    return Ok(new BrandModel { ResponseDto = GetAuthorizeResponse() }); ;
                }
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new BrandModel { ResponseDto = ResponseDto });
            }
        }
    }
}
