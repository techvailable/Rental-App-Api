
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
    public class SubCategoryController : PrivateController
    {
        private readonly ISubCategoryService subCategoryService;
        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            this.subCategoryService = subCategoryService;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> Get()
        {
            var subCategoryModel = new SubCategoryModel();
            try
            {
                var subCategories = await subCategoryService.Get();
                if (subCategories.Any())
                {
                    subCategoryModel.SubCategoryDtoList = subCategories;
                    subCategoryModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    subCategoryModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                subCategoryModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, subCategoryModel);
            }
            return Ok(subCategoryModel);

        }
        [HttpGet]
        [Route("api/[controller]/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var subCategoryModel = new SubCategoryModel();
            try
            {
                var subCategoryDto = await subCategoryService.GetById(Id);
                if (subCategoryDto != null)
                {
                    subCategoryModel.SubCategoryDto = subCategoryDto;
                    subCategoryModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    subCategoryModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                subCategoryModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, subCategoryModel);
            }
            return Ok(subCategoryModel);
        }
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> Add(SubCategoryDto subCategoryDto)
        {
            try
            {
                var response = await subCategoryService.Add(subCategoryDto);
                return Ok(new SubCategoryModel { ResponseDto = response });
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new SubCategoryModel { ResponseDto = ResponseDto });
            }
        }
        [HttpDelete]
        [Route("api/[controller]/{Id}")]
        public async Task<IActionResult> Delete(Int64 Id)
        {
            try
            {
                var response = await subCategoryService.DeleteById(Id);
                return Ok(new SubCategoryModel { ResponseDto = response });
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new SubCategoryModel { ResponseDto = ResponseDto });
            }
        }
        [HttpPatch]
        [Route("api/[controller]")]
        public async Task<IActionResult> Update(SubCategoryDto subCategoryDto)
        {
            try
            {
               var response = await subCategoryService.Update(subCategoryDto);
                return Ok(new SubCategoryModel { ResponseDto = response });
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new SubCategoryModel { ResponseDto = ResponseDto });
            }
        }
    }
}
