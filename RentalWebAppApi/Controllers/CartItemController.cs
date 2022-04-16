
using Microsoft.AspNetCore.Mvc;
using RentalWebAppApi.Exceptions;
using RentalWebAppApi.Models;
using RentalWebService.DTOs;
using RentalWebService.IServices;

namespace RentalWebAppApi.Controllers
{
    [ApiController]
    public class CartItemController : PrivateController
    {
        private readonly ICartItemService cartItemService;
        public CartItemController(ICartItemService cartItemService)
        {
            this.cartItemService = cartItemService;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> Get()
        {
            var cartItemModel = new CartItemModel();
            try
            {
                var categories = await cartItemService.Get();
                if (categories.Any())
                {
                    cartItemModel.CartItemDtoList = categories;
                    cartItemModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    cartItemModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                cartItemModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, cartItemModel);
            }
            return Ok(cartItemModel);

        }
        [HttpGet]
        [Route("api/[controller]/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var cartItemModel = new CartItemModel();
            try
            {
                var cartItemDto = await cartItemService.GetById(Id);
                if (cartItemDto != null)
                {
                    cartItemModel.CartItemDto = cartItemDto;
                    cartItemModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    cartItemModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                cartItemModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, cartItemModel);
            }
            return Ok(cartItemModel);
        }
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> Add(CartItemDto cartItemDto)
        {
            try
            {
                var response = await cartItemService.Add(cartItemDto);
                return Ok(new CartItemModel { ResponseDto = response });
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new CartItemModel { ResponseDto = ResponseDto });
            }
        }
        [HttpDelete]
        [Route("api/[controller]/{Id}")]
        public async Task<IActionResult> Delete(Int64 Id)
        {
            try
            {
                var response = await cartItemService.DeleteById(Id);
                return Ok(new CartItemModel { ResponseDto = response });
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new CartItemModel { ResponseDto = ResponseDto });
            }
        }
        [HttpPatch]
        [Route("api/[controller]")]
        public async Task<IActionResult> Update(CartItemDto cartItemDto)
        {
            try
            {
               var response = await cartItemService.Update(cartItemDto);
                return Ok(new CartItemModel { ResponseDto = response });
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new CartItemModel { ResponseDto = ResponseDto });
            }
        }
    }
}
