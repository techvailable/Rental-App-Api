
using Microsoft.AspNetCore.Mvc;
using RentalWebAppApi.Exceptions;
using RentalWebAppApi.Models;
using RentalWebService.DTOs;
using RentalWebService.IServices;

namespace RentalWebAppApi.Controllers
{
    [ApiController]
    public class OrderController : PrivateController
    {
        private readonly IOrderService orderService;
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> Get()
        {
            var orderModel = new OrderModel();
            try
            {
                var categories = await orderService.Get();
                if (categories.Any())
                {
                    orderModel.OrderDtoList = categories;
                    orderModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    orderModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                orderModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, orderModel);
            }
            return Ok(orderModel);

        }
        [HttpGet]
        [Route("api/[controller]/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var orderModel = new OrderModel();
            try
            {
                var orderDto = await orderService.GetById(Id);
                if (orderDto != null)
                {
                    orderModel.OrderDto = orderDto;
                    orderModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    orderModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                orderModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, orderModel);
            }
            return Ok(orderModel);
        }
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> Add(OrderDto orderDto)
        {
            try
            {
                var response = await orderService.Add(orderDto);
                return Ok(new OrderModel { ResponseDto = response });
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new OrderModel { ResponseDto = ResponseDto });
            }
        }
        [HttpDelete]
        [Route("api/[controller]/{Id}")]
        public async Task<IActionResult> Delete(Int64 Id)
        {
            try
            {
                var response = await orderService.DeleteById(Id);
                return Ok(new OrderModel { ResponseDto = response });
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new OrderModel { ResponseDto = ResponseDto });
            }
        }
        [HttpPatch]
        [Route("api/[controller]")]
        public async Task<IActionResult> Update(OrderDto orderDto)
        {
            try
            {
               var response = await orderService.Update(orderDto);
                return Ok(new OrderModel { ResponseDto = response });
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new OrderModel { ResponseDto = ResponseDto });
            }
        }
    }
}
