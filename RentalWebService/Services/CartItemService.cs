using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.Infrastructure;
using RentalWebService.DTOs;
using RentalWebService.IServices;

namespace RentalWebService.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly IUnitOfWork unitOfWork;
        public CartItemService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task<List<CartItemDto>> Get()
        {
            try
            {
                var entities = await unitOfWork.CartItemRepository.GetAsync();
                var entityDtoList = Mapper.Mapping.Mapper.Map<List<CartItemDto>>(entities);
                return entityDtoList;
            }
            catch(Exception exception)
            {
                throw;
            }
        }

        public async Task<ResponseDto> Add(CartItemDto cartItemDto)
        {
            try
            {
                CartItem cartItem = Mapper.Mapping.Mapper.Map<CartItem>(cartItemDto);
                await unitOfWork.CartItemRepository.Add(cartItem);
                await unitOfWork.SaveChangesAsync();
                var response = new ResponseDto
                {
                    Status = true,
                     Message= "Data saved successfully",
                     Id = cartItem.Id
                };
                return response;
            }
            catch(Exception ex)
            { 
                throw;
            }
        }

        public async Task<ResponseDto> Update(CartItemDto cartItemDto)
        {
            try
            {
                CartItem cartItem = await unitOfWork.CartItemRepository.GetByIdAsync(cartItemDto.Id);
                if (cartItem == null)
                    return new ResponseDto { Status = false, Message = "Data doesn't exists" };
                cartItem.CartId = cartItemDto.CartId;
                cartItem.ProductId = cartItemDto.ProductId;
                cartItem.Quantity = cartItemDto.Quantity;
                cartItem.Discount = cartItemDto.Discount;
                cartItem.Total = cartItemDto.Total;
                cartItem.ModifiedAt = DateTime.UtcNow;
                await unitOfWork.SaveChangesAsync();
                var response = new ResponseDto
                {
                    Status = true,
                    Message = "Data updated successfully",
                    Id= cartItem.Id
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
                var cartItem = await unitOfWork.CartItemRepository.GetByIdAsync(Id);
                if(cartItem == null)
                        return new ResponseDto { Status = false, Message="Data doesn't exists"};
                await unitOfWork.CartItemRepository.DeleteRecord(cartItem);
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

        public async Task<CartItemDto> GetById(Int64 Id)
        {
            try
            {
                var entity = await unitOfWork.CartItemRepository.GetByIdAsync(Id);
                var cartItemDto = Mapper.Mapping.Mapper.Map<CartItemDto>(entity);
                return cartItemDto;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
