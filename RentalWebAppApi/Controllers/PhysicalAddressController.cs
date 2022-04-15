
using Microsoft.AspNetCore.Mvc;
using RentalWebAppApi.Exceptions;
using RentalWebAppApi.Models;
using RentalWebService.DTOs;
using RentalWebService.IServices;

namespace RentalWebAppApi.Controllers
{
    [ApiController]
    public class PhysicalAddressController : PrivateController
    {
        private readonly IPhysicalAddressService physicalAddressService;
        public PhysicalAddressController(IPhysicalAddressService physicalAddressService)
        {
            this.physicalAddressService = physicalAddressService;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> Get()
        {
            var physicalAddressModel = new PhysicalAddressModel();
            try
            {
                var categories = await physicalAddressService.Get();
                if (categories.Any())
                {
                    physicalAddressModel.PhysicalAddressDtoList = categories;
                    physicalAddressModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    physicalAddressModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                physicalAddressModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, physicalAddressModel);
            }
            return Ok(physicalAddressModel);

        }
        [HttpGet]
        [Route("api/[controller]/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var physicalAddressModel = new PhysicalAddressModel();
            try
            {
                var physicalAddressDto = await physicalAddressService.GetById(Id);
                if (physicalAddressDto != null)
                {
                    physicalAddressModel.PhysicalAddressDto = physicalAddressDto;
                    physicalAddressModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    physicalAddressModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                physicalAddressModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, physicalAddressModel);
            }
            return Ok(physicalAddressModel);
        }
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> Add(PhysicalAddressDto physicalAddressDto)
        {
            try
            {
                var response = await physicalAddressService.Add(physicalAddressDto);
                return Ok(new PhysicalAddressModel { ResponseDto = response });
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new PhysicalAddressModel { ResponseDto = ResponseDto });
            }
        }
        [HttpDelete]
        [Route("api/[controller]/{Id}")]
        public async Task<IActionResult> Delete(Int64 Id)
        {
            try
            {
                var response = await physicalAddressService.DeleteById(Id);
                return Ok(new PhysicalAddressModel { ResponseDto = response });
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new PhysicalAddressModel { ResponseDto = ResponseDto });
            }
        }
        //[HttpPatch]
        //[Route("api/[controller]")]
        //public async Task<IActionResult> Update(PhysicalAddressDto physicalAddressDto)
        //{
        //    try
        //    {
        //       var response = await physicalAddressService.Update(physicalAddressDto);
        //        return Ok(new PhysicalAddressModel { ResponseDto = response });
        //    }
        //    catch (Exception ex)
        //    {
        //        var ResponseDto = GetExeceptionResponse();
        //        return StatusCode(StatusCodes.Status500InternalServerError, new PhysicalAddressModel { ResponseDto = ResponseDto });
        //    }
        //}
    }
}
