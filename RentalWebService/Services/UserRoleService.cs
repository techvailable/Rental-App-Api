using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.Infrastructure;
using RentalWebService.DTOs;
using RentalWebService.IServices;

namespace RentalWebService.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUnitOfWork unitOfWork;
        public UserRoleService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task<List<UserRoleDto>> Get()
        {
            try
            {
                var entities = await unitOfWork.UserRoleRepository.GetAsync();
                var entityDtoList = Mapper.Mapping.Mapper.Map<List<UserRoleDto>>(entities);
                return entityDtoList;
            }
            catch(Exception exception)
            {
                throw;
            }
        }

        public async Task<ResponseDto> Add(UserRoleDto userRoleDto)
        {
            try
            {
                UserRole userRole = Mapper.Mapping.Mapper.Map<UserRole>(userRoleDto);
                await unitOfWork.UserRoleRepository.Add(userRole);
                await unitOfWork.SaveChangesAsync();
                var response = new ResponseDto
                {
                    Status = true,
                     Message= "Data saved successfully",
                     Id = userRole.Id
                };
                return response;
            }
            catch(Exception ex)
            { 
                throw;
            }
        }

        public async Task<ResponseDto> Update(UserRoleDto userRoleDto)
        {
            try
            {
                UserRole userRole = await unitOfWork.UserRoleRepository.GetByIdAsync(userRoleDto.Id);
                if (userRole == null)
                    return new ResponseDto { Status = false, Message = "Data doesn't exists" };
                userRole.RoleId = userRoleDto.RoleId;
                userRole.UserId = userRoleDto.UserId;
                userRole.ModifiedAt = DateTime.UtcNow;
                await unitOfWork.SaveChangesAsync();
                var response = new ResponseDto
                {
                    Status = true,
                    Message = "Data updated successfully",
                    Id= userRole.Id
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
                var userRole = await unitOfWork.UserRoleRepository.GetByIdAsync(Id);
                if(userRole == null)
                        return new ResponseDto { Status = false, Message="Data doesn't exists"};
                await unitOfWork.UserRoleRepository.DeleteRecord(userRole);
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

        public async Task<UserRoleDto> GetById(Int64 Id)
        {
            try
            {
                var entity = await unitOfWork.UserRoleRepository.GetByIdAsync(Id);
                var userRoleDto = Mapper.Mapping.Mapper.Map<UserRoleDto>(entity);
                return userRoleDto;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
