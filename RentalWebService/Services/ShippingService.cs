using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.Infrastructure;
using RentalWebService.DTOs;
using RentalWebService.IServices;

namespace RentalWebService.Services
{
    public class ShippingService : IShippingService
    {
        private readonly IUnitOfWork unitOfWork;
        public ShippingService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task<List<ShippingDto>> Get()
        {
            try
            {
                var entities = await unitOfWork.ShippingRepository.GetAsync();
                var entityDtoList = Mapper.Mapping.Mapper.Map<List<ShippingDto>>(entities);
                return entityDtoList;
            }
            catch(Exception exception)
            {
                throw;
            }
        }

        public async Task<ResponseDto> Add(ShippingDto shippingDto)
        {
            try
            {
                Shipping shipping = Mapper.Mapping.Mapper.Map<Shipping>(shippingDto);
                await unitOfWork.ShippingRepository.Add(shipping);
                await unitOfWork.SaveChangesAsync();
                var response = new ResponseDto
                {
                    Status = true,
                     Message= "Data saved successfully",
                     Id = shipping.Id
                };
                return response;
            }
            catch(Exception ex)
            { 
                throw;
            }
        }

        //public async Task<ResponseDto> Update(ShippingDto shippingDto)
        //{
        //    try
        //    {
        //        Shipping shipping = await unitOfWork.ShippingRepository.GetByIdAsync(shippingDto.Id);
        //        if (shipping == null)
        //            return new ResponseDto { Status = false, Message = "Data doesn't exists" };
        //        shipping.Name = shippingDto.Name;
        //        shipping.Description = shippingDto.Description;
        //        shipping.StoreId = shippingDto.StoreId;
        //        shipping.ModifiedAt = DateTime.UtcNow;
        //        await unitOfWork.SaveChangesAsync();
        //        var response = new ResponseDto
        //        {
        //            Status = true,
        //            Message = "Data updated successfully",
        //            Id= shipping.Id
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
                var shipping = await unitOfWork.ShippingRepository.GetByIdAsync(Id);
                if(shipping == null)
                        return new ResponseDto { Status = false, Message="Data doesn't exists"};
                await unitOfWork.ShippingRepository.DeleteRecord(shipping);
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

        public async Task<ShippingDto> GetById(Int64 Id)
        {
            try
            {
                var entity = await unitOfWork.ShippingRepository.GetByIdAsync(Id);
                var shippingDto = Mapper.Mapping.Mapper.Map<ShippingDto>(entity);
                return shippingDto;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
