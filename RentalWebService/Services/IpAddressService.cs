using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.Infrastructure;
using RentalWebService.DTOs;
using RentalWebService.IServices;

namespace RentalWebService.Services
{
    public class IpAddressService : IIpAddressService
    {
        private readonly IUnitOfWork unitOfWork;
        public IpAddressService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task<List<IpAddressDto>> Get()
        {
            try
            {
                var entities = await unitOfWork.IpAddressRepository.GetAsync();
                var entityDtoList = Mapper.Mapping.Mapper.Map<List<IpAddressDto>>(entities);
                return entityDtoList;
            }
            catch(Exception exception)
            {
                throw;
            }
        }

        public async Task<ResponseDto> Add(IpAddressDto ipAddressDto)
        {
            try
            {
                IpAddress ipAddress = Mapper.Mapping.Mapper.Map<IpAddress>(ipAddressDto);
                await unitOfWork.IpAddressRepository.Add(ipAddress);
                await unitOfWork.SaveChangesAsync();
                var response = new ResponseDto
                {
                    Status = true,
                     Message= "Data saved successfully",
                     Id = ipAddress.Id
                };
                return response;
            }
            catch(Exception ex)
            { 
                throw;
            }
        }

        public async Task<ResponseDto> Update(IpAddressDto ipAddressDto)
        {
            try
            {
                IpAddress ipAddress = await unitOfWork.IpAddressRepository.GetByIdAsync(ipAddressDto.Id);
                if (ipAddress == null)
                    return new ResponseDto { Status = false, Message = "Data doesn't exists" };
                ipAddress.IpV1 = ipAddressDto.IpV1;
                ipAddress.IpV2 = ipAddressDto.IpV2;
                ipAddress.IpV3 = ipAddressDto.IpV3;
                ipAddress.IpV4 = ipAddressDto.IpV4;
                ipAddress.UserId = ipAddressDto.UserId;
                ipAddress.ModifiedAt = DateTime.UtcNow;
                await unitOfWork.SaveChangesAsync();
                var response = new ResponseDto
                {
                    Status = true,
                    Message = "Data updated successfully",
                    Id= ipAddress.Id
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
                var ipAddress = await unitOfWork.IpAddressRepository.GetByIdAsync(Id);
                if(ipAddress == null)
                        return new ResponseDto { Status = false, Message="Data doesn't exists"};
                await unitOfWork.IpAddressRepository.DeleteRecord(ipAddress);
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

        public async Task<IpAddressDto> GetById(Int64 Id)
        {
            try
            {
                var entity = await unitOfWork.IpAddressRepository.GetByIdAsync(Id);
                var ipAddressDto = Mapper.Mapping.Mapper.Map<IpAddressDto>(entity);
                return ipAddressDto;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
