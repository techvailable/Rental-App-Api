using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.Infrastructure;
using RentalWebService.DTOs;
using RentalWebService.IServices;

namespace RentalWebService.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task<List<OrderDto>> Get()
        {
            try
            {
                var entities = await unitOfWork.OrderRepository.GetAsync();
                var entityDtoList = Mapper.Mapping.Mapper.Map<List<OrderDto>>(entities);
                return entityDtoList;
            }
            catch(Exception exception)
            {
                throw;
            }
        }

        public async Task<ResponseDto> Add(OrderDto orderDto)
        {
            try
            {
                Order order = Mapper.Mapping.Mapper.Map<Order>(orderDto);
                await unitOfWork.OrderRepository.Add(order);
                await unitOfWork.SaveChangesAsync();
                var response = new ResponseDto
                {
                    Status = true,
                     Message= "Data saved successfully",
                     Id = order.Id
                };
                return response;
            }
            catch(Exception ex)
            { 
                throw;
            }
        }

        public async Task<ResponseDto> Update(OrderDto orderDto)
        {
            try
            {
                Order order = await unitOfWork.OrderRepository.GetByIdAsync(orderDto.Id);
                if (order == null)
                    return new ResponseDto { Status = false, Message = "Data doesn't exists" };
                order.UserId = orderDto.UserId;
                order.CartId = orderDto.CartId;
                order.Cost = orderDto.Cost;
                order.Tax = orderDto.Tax;
                order.Currency = orderDto.Currency;
                order.Status = orderDto.Status;
                order.ModifiedAt = DateTime.UtcNow;
                await unitOfWork.SaveChangesAsync();
                var response = new ResponseDto
                {
                    Status = true,
                    Message = "Data updated successfully",
                    Id= order.Id
                };
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ResponseDto> DeleteById(Int64 Id)
        {
            try
            {
                var order = await unitOfWork.OrderRepository.GetByIdAsync(Id);
                if(order == null)
                        return new ResponseDto { Status = false, Message="Data doesn't exists"};
                await unitOfWork.OrderRepository.DeleteRecord(order);
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

        public async Task<OrderDto> GetById(Int64 Id)
        {
            try
            {
                var entity = await unitOfWork.OrderRepository.GetByIdAsync(Id);
                var orderDto = Mapper.Mapping.Mapper.Map<OrderDto>(entity);
                return orderDto;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
