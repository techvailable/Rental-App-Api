using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.Infrastructure;
using RentalWebService.DTOs;
using RentalWebService.IServices;

namespace RentalWebService.Services
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork unitOfWork;
        public CartService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task<List<CartDto>> Get()
        {
            try
            {
                var entities = await unitOfWork.CartRepository.GetAsync();
                var entityDtoList = Mapper.Mapping.Mapper.Map<List<CartDto>>(entities);
                return entityDtoList;
            }
            catch(Exception exception)
            {
                throw;
            }
        }

        public async Task<ResponseDto> Add(CartDto cartDto)
        {
            try
            {
                Cart cart = Mapper.Mapping.Mapper.Map<Cart>(cartDto);
                await unitOfWork.CartRepository.Add(cart);
                await unitOfWork.SaveChangesAsync();
                var response = new ResponseDto
                {
                    Status = true,
                     Message= "Data saved successfully",
                     Id = cart.Id
                };
                return response;
            }
            catch(Exception ex)
            { 
                throw;
            }
        }

        public async Task<ResponseDto> Update(CartDto cartDto)
        {
            try
            {
                Cart cart = await unitOfWork.CartRepository.GetByIdAsync(cartDto.Id);
                if (cart == null)
                    return new ResponseDto { Status = false, Message = "Data doesn't exists" };
                cart.Status = cartDto.Status;
                //cart.Total = cartDto.Total;
                cart.ModifiedAt = DateTime.UtcNow;
                await unitOfWork.SaveChangesAsync();
                var response = new ResponseDto
                {
                    Status = true,
                    Message = "Data updated successfully",
                    Id= cart.Id
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
                var cart = await unitOfWork.CartRepository.GetByIdAsync(Id);
                if(cart == null)
                        return new ResponseDto { Status = false, Message="Data doesn't exists"};
                await unitOfWork.CartRepository.DeleteRecord(cart);
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

        public async Task<CartDto> GetById(Int64 Id)
        {
            try
            {
                var entity = await unitOfWork.CartRepository.GetByIdAsync(Id);
                var cartDto = Mapper.Mapping.Mapper.Map<CartDto>(entity);
                return cartDto;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
