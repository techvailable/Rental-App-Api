
using Microsoft.AspNetCore.Mvc;
using RentalWebAppApi.Exceptions;
using RentalWebAppApi.Models;
using RentalWebService.DTOs;
using RentalWebService.IServices;

namespace RentalWebAppApi.Controllers
{
    [ApiController]
    public class UserRoleController : PrivateController
    {
        private readonly IUserRoleService userRoleService;
        public UserRoleController(IUserRoleService userRoleService)
        {
            this.userRoleService = userRoleService;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> Get()
        {
            var userRoleModel = new UserRoleModel();
            try
            {
                var categories = await userRoleService.Get();
                if (categories.Any())
                {
                    userRoleModel.UserRoleDtoList = categories;
                    userRoleModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    userRoleModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                userRoleModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, userRoleModel);
            }
            return Ok(userRoleModel);

        }
        [HttpGet]
        [Route("api/[controller]/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var userRoleModel = new UserRoleModel();
            try
            {
                var userRoleDto = await userRoleService.GetById(Id);
                if (userRoleDto != null)
                {
                    userRoleModel.UserRoleDto = userRoleDto;
                    userRoleModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    userRoleModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                userRoleModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, userRoleModel);
            }
            return Ok(userRoleModel);
        }
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> Add(UserRoleDto userRoleDto)
        {
            try
            {
                var response = await userRoleService.Add(userRoleDto);
                return Ok(new UserRoleModel { ResponseDto = response });
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new UserRoleModel { ResponseDto = ResponseDto });
            }
        }
        [HttpDelete]
        [Route("api/[controller]/{Id}")]
        public async Task<IActionResult> Delete(Int64 Id)
        {
            try
            {
                var response = await userRoleService.DeleteById(Id);
                return Ok(new UserRoleModel { ResponseDto = response });
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new UserRoleModel { ResponseDto = ResponseDto });
            }
        }
        [HttpPatch]
        [Route("api/[controller]")]
        public async Task<IActionResult> Update(UserRoleDto userRoleDto)
        {
            try
            {
               var response = await userRoleService.Update(userRoleDto);
                return Ok(new UserRoleModel { ResponseDto = response });
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new UserRoleModel { ResponseDto = ResponseDto });
            }
        }
    }
}
