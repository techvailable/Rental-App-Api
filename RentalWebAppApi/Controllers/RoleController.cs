
using Microsoft.AspNetCore.Mvc;
using RentalWebAppApi.Exceptions;
using RentalWebAppApi.Models;
using RentalWebService.DTOs;
using RentalWebService.IServices;

namespace RentalWebAppApi.Controllers
{
    [ApiController]
    public class RoleController : PrivateController
    {
        private readonly IRoleService roleService;
        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> Get()
        {
            var roleModel = new RoleModel();
            try
            {
                var categories = await roleService.Get();
                if (categories.Any())
                {
                    roleModel.RoleDtoList = categories;
                    roleModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    roleModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                roleModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, roleModel);
            }
            return Ok(roleModel);

        }
        [HttpGet]
        [Route("api/[controller]/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var roleModel = new RoleModel();
            try
            {
                var roleDto = await roleService.GetById(Id);
                if (roleDto != null)
                {
                    roleModel.RoleDto = roleDto;
                    roleModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    roleModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                roleModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, roleModel);
            }
            return Ok(roleModel);
        }
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> Add(RoleDto roleDto)
        {
            try
            {
                var response = await roleService.Add(roleDto);
                return Ok(new RoleModel { ResponseDto = response });
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new RoleModel { ResponseDto = ResponseDto });
            }
        }
        [HttpDelete]
        [Route("api/[controller]/{Id}")]
        public async Task<IActionResult> Delete(Int64 Id)
        {
            try
            {
                var response = await roleService.DeleteById(Id);
                return Ok(new RoleModel { ResponseDto = response });
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new RoleModel { ResponseDto = ResponseDto });
            }
        }
        [HttpPatch]
        [Route("api/[controller]")]
        public async Task<IActionResult> Update(RoleDto roleDto)
        {
            try
            {
               var response = await roleService.Update(roleDto);
                return Ok(new RoleModel { ResponseDto = response });
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new RoleModel { ResponseDto = ResponseDto });
            }
        }
    }
}
