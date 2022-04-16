using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.Infrastructure;
using RentalWebService.DTOs;
using RentalWebService.IServices;

namespace RentalWebService.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork unitOfWork;
        public RoleService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task<List<RoleDto>> Get()
        {
            try
            {
                var entities = await unitOfWork.RoleRepository.GetAsync();
                var entityDtoList = Mapper.Mapping.Mapper.Map<List<RoleDto>>(entities);
                return entityDtoList;
            }
            catch(Exception exception)
            {
                throw;
            }
        }

        public async Task<ResponseDto> Add(RoleDto roleDto)
        {
            try
            {
                Role role = Mapper.Mapping.Mapper.Map<Role>(roleDto);
                await unitOfWork.RoleRepository.Add(role);
                await unitOfWork.SaveChangesAsync();
                var response = new ResponseDto
                {
                    Status = true,
                     Message= "Data saved successfully",
                     Id = role.Id
                };
                return response;
            }
            catch(Exception ex)
            { 
                throw;
            }
        }

        public async Task<ResponseDto> Update(RoleDto roleDto)
        {
            try
            {
                Role role = await unitOfWork.RoleRepository.GetByIdAsync(roleDto.Id);
                if (role == null)
                    return new ResponseDto { Status = false, Message = "Data doesn't exists" };
                role.Name = roleDto.Name;
                role.ModifiedAt = DateTime.UtcNow;
                await unitOfWork.SaveChangesAsync();
                var response = new ResponseDto
                {
                    Status = true,
                    Message = "Data updated successfully",
                    Id= role.Id
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
                var role = await unitOfWork.RoleRepository.GetByIdAsync(Id);
                if(role == null)
                        return new ResponseDto { Status = false, Message="Data doesn't exists"};
                await unitOfWork.RoleRepository.DeleteRecord(role);
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

        public async Task<RoleDto> GetById(Int64 Id)
        {
            try
            {
                var entity = await unitOfWork.RoleRepository.GetByIdAsync(Id);
                var roleDto = Mapper.Mapping.Mapper.Map<RoleDto>(entity);
                return roleDto;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
