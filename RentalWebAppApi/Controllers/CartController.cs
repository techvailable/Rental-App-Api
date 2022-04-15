
using Microsoft.AspNetCore.Mvc;
using RentalWebAppApi.Exceptions;
using RentalWebAppApi.Models;
using RentalWebService.DTOs;
using RentalWebService.IServices;

namespace RentalWebAppApi.Controllers
{
    [ApiController]
    public class CartController : PrivateController
    {
        private readonly ICartService cartService;
        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> Get()
        {
            var cartModel = new CartModel();
            try
            {
                var categories = await cartService.Get();
                if (categories.Any())
                {
                    cartModel.CartDtoList = categories;
                    cartModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    cartModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                cartModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, cartModel);
            }
            return Ok(cartModel);

        }
        [HttpGet]
        [Route("api/[controller]/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var cartModel = new CartModel();
            try
            {
                var cartDto = await cartService.GetById(Id);
                if (cartDto != null)
                {
                    cartModel.CartDto = cartDto;
                    cartModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    cartModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                cartModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, cartModel);
            }
            return Ok(cartModel);
        }
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> Add(CartDto cartDto)
        {
            try
            {
                var response = await cartService.Add(cartDto);
                return Ok(new CartModel { ResponseDto = response });
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new CartModel { ResponseDto = ResponseDto });
            }
        }
        [HttpDelete]
        [Route("api/[controller]/{Id}")]
        public async Task<IActionResult> Delete(Int64 Id)
        {
            try
            {
                var response = await cartService.DeleteById(Id);
                return Ok(new CartModel { ResponseDto = response });
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new CartModel { ResponseDto = ResponseDto });
            }
        }
        [HttpPatch]
        [Route("api/[controller]")]
        public async Task<IActionResult> Update(CartDto cartDto)
        {
            try
            {
               var response = await cartService.Update(cartDto);
                return Ok(new CartModel { ResponseDto = response });
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new CartModel { ResponseDto = ResponseDto });
            }
        }
    }
}
