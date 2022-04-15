using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.Infrastructure;
using RentalWebService.DTOs;
using RentalWebService.IServices;

namespace RentalWebService.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task<List<UserDto>> Get()
        {
            try
            {
                var entities = await unitOfWork.UserRepository.GetAsync();
                var entityDtoList = Mapper.Mapping.Mapper.Map<List<UserDto>>(entities);
                return entityDtoList;
            }
            catch(Exception exception)
            {
                throw;
            }
        }

        public async Task<ResponseDto> Add(UserDto userDto)
        {
            try
            {
                User user = Mapper.Mapping.Mapper.Map<User>(userDto);
                await unitOfWork.UserRepository.Add(user);
                await unitOfWork.SaveChangesAsync();
                var response = new ResponseDto
                {
                    Status = true,
                     Message= "Data saved successfully",
                     Id = user.Id
                };
                return response;
            }
            catch(Exception ex)
            { 
                throw;
            }
        }

        public async Task<ResponseDto> Update(UserDto userDto)
        {
            try
            {
                User user = await unitOfWork.UserRepository.GetByIdAsync(userDto.Id);
                if (user == null)
                    return new ResponseDto { Status = false, Message = "Data doesn't exists" };
                user.Name = userDto.Name;
                user.Password = userDto.Password;
                user.Email = userDto.Email;
                user.ModifiedAt = DateTime.UtcNow;
                await unitOfWork.SaveChangesAsync();
                var response = new ResponseDto
                {
                    Status = true,
                    Message = "Data updated successfully",
                    Id= user.Id
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
                var user = await unitOfWork.UserRepository.GetByIdAsync(Id);
                if(user == null)
                        return new ResponseDto { Status = false, Message="Data doesn't exists"};
                await unitOfWork.UserRepository.DeleteRecord(user);
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

        public async Task<UserDto> GetById(Int64 Id)
        {
            try
            {
                var entity = await unitOfWork.UserRepository.GetByIdAsync(Id);
                var userDto = Mapper.Mapping.Mapper.Map<UserDto>(entity);
                return userDto;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
