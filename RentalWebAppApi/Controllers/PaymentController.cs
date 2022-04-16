
using Microsoft.AspNetCore.Mvc;
using RentalWebAppApi.Exceptions;
using RentalWebAppApi.Models;
using RentalWebService.DTOs;
using RentalWebService.IServices;

namespace RentalWebAppApi.Controllers
{
    [ApiController]
    public class PaymentController : PrivateController
    {
        private readonly IPaymentService paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> Get()
        {
            var paymentModel = new PaymentModel();
            try
            {
                var categories = await paymentService.Get();
                if (categories.Any())
                {
                    paymentModel.PaymentDtoList = categories;
                    paymentModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    paymentModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                paymentModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, paymentModel);
            }
            return Ok(paymentModel);

        }
        [HttpGet]
        [Route("api/[controller]/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var paymentModel = new PaymentModel();
            try
            {
                var paymentDto = await paymentService.GetById(Id);
                if (paymentDto != null)
                {
                    paymentModel.PaymentDto = paymentDto;
                    paymentModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    paymentModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                paymentModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, paymentModel);
            }
            return Ok(paymentModel);
        }
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> Add(PaymentDto paymentDto)
        {
            try
            {
                var response = await paymentService.Add(paymentDto);
                return Ok(new PaymentModel { ResponseDto = response });
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new PaymentModel { ResponseDto = ResponseDto });
            }
        }
        [HttpDelete]
        [Route("api/[controller]/{Id}")]
        public async Task<IActionResult> Delete(Int64 Id)
        {
            try
            {
                var response = await paymentService.DeleteById(Id);
                return Ok(new PaymentModel { ResponseDto = response });
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new PaymentModel { ResponseDto = ResponseDto });
            }
        }
        //[HttpPatch]
        //[Route("api/[controller]")]
        //public async Task<IActionResult> Update(PaymentDto paymentDto)
        //{
        //    try
        //    {
        //       var response = await paymentService.Update(paymentDto);
        //        return Ok(new PaymentModel { ResponseDto = response });
        //    }
        //    catch (Exception ex)
        //    {
        //        var ResponseDto = GetExeceptionResponse();
        //        return StatusCode(StatusCodes.Status500InternalServerError, new PaymentModel { ResponseDto = ResponseDto });
        //    }
        //}
    }
}
