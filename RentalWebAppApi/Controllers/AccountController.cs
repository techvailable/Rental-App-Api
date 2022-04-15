
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalWebAppApi.Exceptions;
using RentalWebAppApi.Models;
using RentalWebService.DTOs;
using RentalWebService.IServices;
using System.Net;
using WeightChopperApi.Helping;

namespace RentalWebAppApi.Controllers
{
    [ApiController]
    public class AccountController : PrivateController
    {
        private readonly IAdminUserService adminUserService;
        private readonly JwtSettings jwtSettings;
        public AccountController(IAdminUserService adminUserService, JwtSettings jwtSettings)
        {
            this.adminUserService = adminUserService;
            this.jwtSettings = jwtSettings;
        }
         private IEnumerable < Users > logins = new List < Users > () {
            new Users() {
                    Id = Guid.NewGuid(),
                        EmailId = "adminakp@gmail.com",
                        UserName = "Admin",
                        Password = "Admin",
                },
                new Users() {
                    Id = Guid.NewGuid(),
                        EmailId = "adminakp@gmail.com",
                        UserName = "User1",
                        Password = "Admin",
                }
        };

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> Login(UserLogins userLogins) {
            try
            {
                var Token = new UserTokens();
                var users = await adminUserService.GetByName(userLogins.UserName);
                var Valid = logins.Any(x => x.UserName.Equals(userLogins.UserName, StringComparison.OrdinalIgnoreCase));
                if (users.Any())
                {
                    var user = users.FirstOrDefault(x => x.Name.Equals(userLogins.UserName, StringComparison.OrdinalIgnoreCase) || x.Email.Equals(userLogins.UserName, StringComparison.OrdinalIgnoreCase));
                    Token = JwtHelpers.GenTokenkey(new UserTokens()
                    {
                        EmailId = user.Email,
                        GuidId = Guid.NewGuid(),
                        UserName = user.Name,
                        Id = user.Id,
                    }, jwtSettings);
                }
                else
                {
                    return BadRequest("wrong password");
                }
                return Ok(Token);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Get List of UserAccounts
        /// </summary>
        /// <returns>List Of UserAccounts</returns>
        [HttpGet]
        [Route("api/[controller]")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]

        public IActionResult GetList() {
            var userId = User.FindFirst("Id")?.Value;
            string Token =  Request.Headers["Authorization"];
            return Ok(logins);
        }
       
        //[HttpGet]
        //[Route("api/[controller]")]
        //public async Task<IActionResult> Get()
        //{
        //    var adminUserModel = new AdminUserModel();
        //    try
        //    {
        //        var categories = await adminUserService.Get();
        //        if (categories.Any())
        //        {
        //            adminUserModel.AdminUserDtoList = categories;
        //            adminUserModel.ResponseDto = GetOkResponse();
        //        }
        //        else
        //        {
        //            adminUserModel.ResponseDto = GetNotFoundResponse();
        //        }   
        //    }
        //    catch (Exception ex)
        //    {
        //        adminUserModel.ResponseDto = GetExeceptionResponse();
        //        return StatusCode(StatusCodes.Status500InternalServerError, adminUserModel);
        //    }
        //    return Ok(adminUserModel);

        //}
        //[HttpGet]
        //[Route("api/[controller]/{Id}")]
        //public async Task<IActionResult> GetById(int Id)
        //{
        //    var adminUserModel = new AdminUserModel();
        //    try
        //    {
        //        var adminUserDto = await adminUserService.GetById(Id);
        //        if (adminUserDto != null)
        //        {
        //            adminUserModel.AdminUserDto = adminUserDto;
        //            adminUserModel.ResponseDto = GetOkResponse();
        //        }
        //        else
        //        {
        //            adminUserModel.ResponseDto = GetNotFoundResponse();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        adminUserModel.ResponseDto = GetExeceptionResponse();
        //        return StatusCode(StatusCodes.Status500InternalServerError, adminUserModel);
        //    }
        //    return Ok(adminUserModel);
        //}
        //[HttpPost]
        //[Route("api/[controller]")]
        //public async Task<IActionResult> Add(AdminUserDto adminUserDto)
        //{
        //    try
        //    {
        //        var response = await adminUserService.Add(adminUserDto);
        //        return Ok(new AdminUserModel { ResponseDto = response });
        //    }
        //    catch (Exception ex)
        //    {
        //        var ResponseDto = GetExeceptionResponse();
        //        return StatusCode(StatusCodes.Status500InternalServerError, new AdminUserModel { ResponseDto = ResponseDto });
        //    }
        //}
        //[HttpDelete]
        //[Route("api/[controller]/{Id}")]
        //public async Task<IActionResult> Delete(Int64 Id)
        //{
        //    try
        //    {
        //        var response = await adminUserService.DeleteById(Id);
        //        return Ok(new AdminUserModel { ResponseDto = response });
        //    }
        //    catch (Exception ex)
        //    {
        //        var ResponseDto = GetExeceptionResponse();
        //        return StatusCode(StatusCodes.Status500InternalServerError, new AdminUserModel { ResponseDto = ResponseDto });
        //    }
        //}
        //[HttpPatch]
        //[Route("api/[controller]")]
        //public async Task<IActionResult> Update(AdminUserDto adminUserDto)
        //{
        //    try
        //    {
        //       var response = await adminUserService.Update(adminUserDto);
        //        return Ok(new AdminUserModel { ResponseDto = response });
        //    }
        //    catch (Exception ex)
        //    {
        //        var ResponseDto = GetExeceptionResponse();
        //        return StatusCode(StatusCodes.Status500InternalServerError, new AdminUserModel { ResponseDto = ResponseDto });
        //    }
        //}
    }
    public class UserLogins
    {

        public string UserName
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }
        public UserLogins() { }
    }
    public class Users
    {
        public string UserName
        {
            get;
            set;
        }
        public Guid Id
        {
            get;
            set;
        }
        public string EmailId
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
    }
}
