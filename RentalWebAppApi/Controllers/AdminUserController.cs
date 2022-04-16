
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalWebAppApi.Exceptions;
using RentalWebAppApi.Models;
using RentalWebService.DTOs;
using RentalWebService.IServices;
using WeightChopperApi.Helping;

namespace RentalWebAppApi.Controllers
{
    [ApiController]
    public class AdminUserController : PrivateController
    {
        private readonly IAdminUserService adminUserService;
        private readonly JwtSettings jwtSettings;
        public AdminUserController(IAdminUserService adminUserService, JwtSettings jwtSettings)
        {
            this.adminUserService = adminUserService;
            this.jwtSettings = jwtSettings;
        }
        [HttpGet]
        [Route("api/[controller]")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Get()
        {

            var adminUserModel = new AdminUserModel();
            try
            {
                var userId = Convert.ToInt64(User.FindFirst("Id")?.Value);
                var valid = await adminUserService.GetById(userId);
                if (valid != null)
                {
                    var categories = await adminUserService.Get();
                    if (categories.Any())
                    {
                        adminUserModel.AdminUserDtoList = categories;
                        adminUserModel.ResponseDto = GetOkResponse();
                    }
                    else
                    {
                        adminUserModel.ResponseDto = GetNotFoundResponse();
                    }
                }
                else
                {
                    adminUserModel.ResponseDto = GetAuthorizeResponse();
                }
            }
            catch (Exception ex)
            {
                adminUserModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, adminUserModel);
            }
            return Ok(adminUserModel);

        }
        [HttpGet]
        [Route("api/[controller]/{Id}")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetById(int Id)
        {
            var adminUserModel = new AdminUserModel();
            try
            {
                var userId = Convert.ToInt64(User.FindFirst("Id")?.Value);
                var valid = await adminUserService.GetById(userId);
                if (valid != null)
                {
                    var adminUserDto = await adminUserService.GetById(Id);
                    if (adminUserDto != null)
                    {
                        adminUserModel.AdminUserDto = adminUserDto;
                        adminUserModel.ResponseDto = GetOkResponse();
                    }
                    else
                    {
                        adminUserModel.ResponseDto = GetNotFoundResponse();
                    }
                }
                else
                {
                    adminUserModel.ResponseDto = GetAuthorizeResponse();
                }
            }
            catch (Exception ex)
            {
                adminUserModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, adminUserModel);
            }
            return Ok(adminUserModel);
        }
        [HttpPost]
        [Route("api/[controller]")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Add(AdminUserDto adminUserDto)
        {
            var adminUserModel = new AdminUserModel();
            try
            {
                var userId = Convert.ToInt64(User.FindFirst("Id")?.Value);
                var valid = await adminUserService.GetById(userId);
                if (valid != null)
                {
                    var Token = new UserTokens();
                    var response = await adminUserService.Add(adminUserDto);
                    Token = JwtHelpers.GenTokenkey(new UserTokens()
                    {
                        EmailId = adminUserDto.Email,
                        GuidId = Guid.NewGuid(),
                        UserName = adminUserDto.Name,
                        Id = response.Id,
                    }, jwtSettings);
                    return Ok(new AdminUserModel { ResponseDto = response, UserTokens = Token });
                }
                else
                {
                    adminUserModel.ResponseDto = GetAuthorizeResponse();
                    return Ok(adminUserModel);
                }
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new AdminUserModel { ResponseDto = ResponseDto });
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
                    var response = await adminUserService.DeleteById(Id);
                    return Ok(new AdminUserModel { ResponseDto = response });
                }
                else
                {
                    return Ok(new AdminUserModel { ResponseDto = GetAuthorizeResponse() });
                }
            }

            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new AdminUserModel { ResponseDto = ResponseDto });
            }
        }
        [HttpPatch]
        [Route("api/[controller]")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Update(AdminUserDto adminUserDto)
        {
            try
            {
                var userId = Convert.ToInt64(User.FindFirst("Id")?.Value);
                var valid = await adminUserService.GetById(userId);
                if (valid != null)
                {
                    var response = await adminUserService.Update(adminUserDto);
                    return Ok(new AdminUserModel { ResponseDto = response });
                }
                else
                {
                    return Ok(new AdminUserModel { ResponseDto = GetAuthorizeResponse() });
                }
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new AdminUserModel { ResponseDto = ResponseDto });
            }
        }
    }
}
