
using Microsoft.AspNetCore.Mvc;
using RentalWebAppApi.Exceptions;
using RentalWebAppApi.Models;
using RentalWebService.DTOs;
using RentalWebService.IServices;

namespace RentalWebAppApi.Controllers
{
    [ApiController]
    public class StoreController : PrivateController
    {
        private readonly IStoreService storeService;
        public StoreController(IStoreService storeService)
        {
            this.storeService = storeService;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> Get()
        {
            var storeModel = new StoreModel();
            try
            {
                var stores = await storeService.Get();
                if (stores.Any())
                {
                    storeModel.StoreDtoList = stores;
                    storeModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    storeModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                storeModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, storeModel);
            }
            return Ok(storeModel);

        }
        [HttpGet]
        [Route("api/[controller]/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var storeModel = new StoreModel();
            try
            {
                var storeDto = await storeService.GetById(Id);
                if (storeDto != null)
                {
                    storeModel.StoreDto = storeDto;
                    storeModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    storeModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                storeModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, storeModel);
            }
            return Ok(storeModel);
        }
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> Add(StoreDto storeDto)
        {
            try
            {
                var response = await storeService.Add(storeDto);
                return Ok(new StoreModel { ResponseDto = response });
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new StoreModel { ResponseDto = ResponseDto });
            }
        }
        [HttpDelete]
        [Route("api/[controller]/{Id}")]
        public async Task<IActionResult> Delete(Int64 Id)
        {
            try
            {
                var response = await storeService.DeleteById(Id);
                return Ok(new StoreModel { ResponseDto = response });
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new StoreModel { ResponseDto = ResponseDto });
            }
        }
        [HttpPatch]
        [Route("api/[controller]")]
        public async Task<IActionResult> Update(StoreDto storeDto)
        {
            try
            {
               var response = await storeService.Update(storeDto);
                return Ok(new StoreModel { ResponseDto = response });
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new StoreModel { ResponseDto = ResponseDto });
            }
        }
    }
}
