using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.Infrastructure;
using RentalWebService.DTOs;
using RentalWebService.IServices;

namespace RentalWebService.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork unitOfWork;
        public PaymentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task<List<PaymentDto>> Get()
        {
            try
            {
                var entities = await unitOfWork.PaymentRepository.GetAsync();
                var entityDtoList = Mapper.Mapping.Mapper.Map<List<PaymentDto>>(entities);
                return entityDtoList;
            }
            catch(Exception exception)
            {
                throw;
            }
        }

        public async Task<ResponseDto> Add(PaymentDto paymentDto)
        {
            try
            {
                Payment payment = Mapper.Mapping.Mapper.Map<Payment>(paymentDto);
                await unitOfWork.PaymentRepository.Add(payment);
                await unitOfWork.SaveChangesAsync();
                var response = new ResponseDto
                {
                    Status = true,
                     Message= "Data saved successfully",
                     Id = payment.Id
                };
                return response;
            }
            catch(Exception ex)
            { 
                throw;
            }
        }

        //public async Task<ResponseDto> Update(PaymentDto paymentDto)
        //{
        //    try
        //    {
        //        Payment payment = await unitOfWork.PaymentRepository.GetByIdAsync(paymentDto.Id);
        //        if (payment == null)
        //            return new ResponseDto { Status = false, Message = "Data doesn't exists" };
        //        payment.Name = paymentDto.Name;
        //        payment.Description = paymentDto.Description;
        //        payment.StoreId = paymentDto.StoreId;
        //        payment.ModifiedAt = DateTime.UtcNow;
        //        await unitOfWork.SaveChangesAsync();
        //        var response = new ResponseDto
        //        {
        //            Status = true,
        //            Message = "Data updated successfully",
        //            Id= payment.Id
        //        };
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        public async Task<ResponseDto> DeleteById(Int64 Id)
        {
            try
            {
                var payment = await unitOfWork.PaymentRepository.GetByIdAsync(Id);
                if(payment == null)
                        return new ResponseDto { Status = false, Message="Data doesn't exists"};
                await unitOfWork.PaymentRepository.DeleteRecord(payment);
                await unitOfWork.SaveChangesAsync();
                var response = new ResponseDto
                {
                    Status = true,
                    Message = "Data deleted successfully"
                };
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PaymentDto> GetById(Int64 Id)
        {
            try
            {
                var entity = await unitOfWork.PaymentRepository.GetByIdAsync(Id);
                var paymentDto = Mapper.Mapping.Mapper.Map<PaymentDto>(entity);
                return paymentDto;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
