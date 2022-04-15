using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.Infrastructure;
using RentalWebService.DTOs;
using RentalWebService.IServices;

namespace RentalWebService.Services
{
    public class PhysicalAddressService : IPhysicalAddressService
    {
        private readonly IUnitOfWork unitOfWork;
        public PhysicalAddressService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task<List<PhysicalAddressDto>> Get()
        {
            try
            {
                var entities = await unitOfWork.PhysicalAddressRepository.GetAsync();
                var entityDtoList = Mapper.Mapping.Mapper.Map<List<PhysicalAddressDto>>(entities);
                return entityDtoList;
            }
            catch(Exception exception)
            {
                throw;
            }
        }

        public async Task<ResponseDto> Add(PhysicalAddressDto physicalAddressDto)
        {
            try
            {
                PhysicalAddress physicalAddress = Mapper.Mapping.Mapper.Map<PhysicalAddress>(physicalAddressDto);
                await unitOfWork.PhysicalAddressRepository.Add(physicalAddress);
                await unitOfWork.SaveChangesAsync();
                var response = new ResponseDto
                {
                    Status = true,
                     Message= "Data saved successfully",
                     Id = physicalAddress.Id
                };
                return response;
            }
            catch(Exception ex)
            { 
                throw;
            }
        }

        //public async Task<ResponseDto> Update(PhysicalAddressDto physicalAddressDto)
        //{
        //    try
        //    {
        //        PhysicalAddress physicalAddress = await unitOfWork.PhysicalAddressRepository.GetByIdAsync(physicalAddressDto.Id);
        //        if (physicalAddress == null)
        //            return new ResponseDto { Status = false, Message = "Data doesn't exists" };
        //        physicalAddress.Name = physicalAddressDto.Name;
        //        physicalAddress.Description = physicalAddressDto.Description;
        //        physicalAddress.StoreId = physicalAddressDto.StoreId;
        //        physicalAddress.ModifiedAt = DateTime.UtcNow;
        //        await unitOfWork.SaveChangesAsync();
        //        var response = new ResponseDto
        //        {
        //            Status = true,
        //            Message = "Data updated successfully",
        //            Id= physicalAddress.Id
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
                var physicalAddress = await unitOfWork.PhysicalAddressRepository.GetByIdAsync(Id);
                if(physicalAddress == null)
                        return new ResponseDto { Status = false, Message="Data doesn't exists"};
                await unitOfWork.PhysicalAddressRepository.DeleteRecord(physicalAddress);
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

        public async Task<PhysicalAddressDto> GetById(Int64 Id)
        {
            try
            {
                var entity = await unitOfWork.PhysicalAddressRepository.GetByIdAsync(Id);
                var physicalAddressDto = Mapper.Mapping.Mapper.Map<PhysicalAddressDto>(entity);
                return physicalAddressDto;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
