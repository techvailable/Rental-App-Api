using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.Infrastructure;
using RentalWebService.DTOs;
using RentalWebService.IServices;

namespace RentalWebService.Services
{
    public class AdminUserService : IAdminUserService
    {
        private readonly IUnitOfWork unitOfWork;
        public AdminUserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task<List<AdminUserDto>> Get()
        {
            try
            {
                var entities = await unitOfWork.AdminUserRepository.GetAsync();
                var entityDtoList = Mapper.Mapping.Mapper.Map<List<AdminUserDto>>(entities);
                return entityDtoList;
            }
            catch(Exception exception)
            {
                throw;
            }
        }
        public async Task<List<AdminUserDto>> GetByName(string name)
        {
            try
            {
                var entities = await unitOfWork.AdminUserRepository.GetAsync(x=>x.Name.Equals(name) || x.Email.Equals(name));
                var entityDtoList = Mapper.Mapping.Mapper.Map<List<AdminUserDto>>(entities);
                return entityDtoList;
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public async Task<ResponseDto> Add(AdminUserDto adminUserDto)
        {
            try
            {
                AdminUser adminUser = Mapper.Mapping.Mapper.Map<AdminUser>(adminUserDto);
                await unitOfWork.AdminUserRepository.Add(adminUser);
                await unitOfWork.SaveChangesAsync();
                var response = new ResponseDto
                {
                    Status = true,
                     Message= "Data saved successfully",
                     Id = adminUser.Id
                };
                return response;
            }
            catch(Exception ex)
            { 
                throw;
            }
        }

        public async Task<ResponseDto> Update(AdminUserDto adminUserDto)
        {
            try
            {
                AdminUser adminUser = await unitOfWork.AdminUserRepository.GetByIdAsync(adminUserDto.Id);
                if (adminUser == null)
                    return new ResponseDto { Status = false, Message = "Data doesn't exists" };
                adminUser.Name = adminUserDto.Name;
                adminUser.Password = adminUserDto.Password;
                adminUser.Email = adminUserDto.Email;
                adminUser.ModifiedAt = DateTime.UtcNow;
                await unitOfWork.SaveChangesAsync();
                var response = new ResponseDto
                {
                    Status = true,
                    Message = "Data updated successfully",
                    Id= adminUser.Id
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
                var adminUser = await unitOfWork.AdminUserRepository.GetByIdAsync(Id);
                if(adminUser == null)
                        return new ResponseDto { Status = false, Message="Data doesn't exists"};
                await unitOfWork.AdminUserRepository.DeleteRecord(adminUser);
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

        public async Task<AdminUserDto> GetById(Int64 Id)
        {
            try
            {
                var entity = await unitOfWork.AdminUserRepository.GetByIdAsync(Id);
                var adminUserDto = Mapper.Mapping.Mapper.Map<AdminUserDto>(entity);
                return adminUserDto;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
