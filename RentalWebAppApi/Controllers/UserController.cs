
using Microsoft.AspNetCore.Mvc;
using RentalWebAppApi.Exceptions;
using RentalWebAppApi.Models;
using RentalWebService.DTOs;
using RentalWebService.IServices;

namespace RentalWebAppApi.Controllers
{
    [ApiController]
    public class UserController : PrivateController
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> Get()
        {
            var userModel = new UserModel();
            try
            {
                var categories = await userService.Get();
                if (categories.Any())
                {
                    userModel.UserDtoList = categories;
                    userModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    userModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                userModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, userModel);
            }
            return Ok(userModel);

        }
        [HttpGet]
        [Route("api/[controller]/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var userModel = new UserModel();
            try
            {
                var userDto = await userService.GetById(Id);
                if (userDto != null)
                {
                    userModel.UserDto = userDto;
                    userModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    userModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                userModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, userModel);
            }
            return Ok(userModel);
        }
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> Add(UserDto userDto)
        {
            try
            {
                var response = await userService.Add(userDto);
                return Ok(new UserModel { ResponseDto = response });
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new UserModel { ResponseDto = ResponseDto });
            }
        }
        [HttpDelete]
        [Route("api/[controller]/{Id}")]
        public async Task<IActionResult> Delete(Int64 Id)
        {
            try
            {
                var response = await userService.DeleteById(Id);
                return Ok(new UserModel { ResponseDto = response });
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new UserModel { ResponseDto = ResponseDto });
            }
        }
        [HttpPatch]
        [Route("api/[controller]")]
        public async Task<IActionResult> Update(UserDto userDto)
        {
            try
            {
               var response = await userService.Update(userDto);
                return Ok(new UserModel { ResponseDto = response });
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new UserModel { ResponseDto = ResponseDto });
            }
        }
    }
}
