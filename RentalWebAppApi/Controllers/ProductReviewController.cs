
using Microsoft.AspNetCore.Mvc;
using RentalWebAppApi.Exceptions;
using RentalWebAppApi.Models;
using RentalWebService.DTOs;
using RentalWebService.IServices;

namespace RentalWebAppApi.Controllers
{
    [ApiController]
    public class ProductReviewController : PrivateController
    {
        private readonly IProductReviewService productReviewService;
        private readonly IUserService userService;
        public ProductReviewController(IProductReviewService productReviewService, IUserService userService)
        {
            this.productReviewService = productReviewService;
            this.userService = userService;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> Get()
        {
            var productReviewModel = new ProductReviewModel();
            try
            {
                var categories = await productReviewService.Get();
                if (categories.Any())
                {
                    productReviewModel.ProductReviewDtoList = categories;
                    productReviewModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    productReviewModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                productReviewModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, productReviewModel);
            }
            return Ok(productReviewModel);

        }
        [HttpGet]
        [Route("api/[controller]/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var productReviewModel = new ProductReviewModel();
            try
            {
                var productReviewDto = await productReviewService.GetById(Id);
                if (productReviewDto != null)
                {
                    productReviewModel.ProductReviewDto = productReviewDto;
                    productReviewModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    productReviewModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                productReviewModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, productReviewModel);
            }
            return Ok(productReviewModel);
        }
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> Add(ProductReviewDto productReviewDto)
        {
            try
            {
                var user = await userService.GetById(productReviewDto.UserId);
                if(user != null)
                {
                    productReviewDto.ReviewBy = user.Name;
                    productReviewDto.Address = user.Name;
                }
                var response = await productReviewService.Add(productReviewDto);
                return Ok(new ProductReviewModel { ResponseDto = response });
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new ProductReviewModel { ResponseDto = ResponseDto });
            }
        }
        [HttpDelete]
        [Route("api/[controller]/{Id}")]
        public async Task<IActionResult> Delete(Int64 Id)
        {
            try
            {
                var response = await productReviewService.DeleteById(Id);
                return Ok(new ProductReviewModel { ResponseDto = response });
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new ProductReviewModel { ResponseDto = ResponseDto });
            }
        }
        //[HttpPatch]
        //[Route("api/[controller]")]
        //public async Task<IActionResult> Update(ProductReviewDto productReviewDto)
        //{
        //    try
        //    {
        //       var response = await productReviewService.Update(productReviewDto);
        //        return Ok(new ProductReviewModel { ResponseDto = response });
        //    }
        //    catch (Exception ex)
        //    {
        //        var ResponseDto = GetExeceptionResponse();
        //        return StatusCode(StatusCodes.Status500InternalServerError, new ProductReviewModel { ResponseDto = ResponseDto });
        //    }
        //}
    }
}
