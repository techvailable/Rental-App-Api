using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.Infrastructure;
using RentalWebService.DTOs;
using RentalWebService.IServices;

namespace RentalWebService.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task<List<CategoryDto>> Get()
        {
            try
            {
                var entities = await unitOfWork.CategoryRepository.GetAsync();
                var entityDtoList = Mapper.Mapping.Mapper.Map<List<CategoryDto>>(entities);
                return entityDtoList;
            }
            catch(Exception exception)
            {
                throw;
            }
        }

        public async Task<ResponseDto> Add(CategoryDto categoryDto)
        {
            try
            {
                Category category = Mapper.Mapping.Mapper.Map<Category>(categoryDto);
                await unitOfWork.CategoryRepository.Add(category);
                await unitOfWork.SaveChangesAsync();
                var response = new ResponseDto
                {
                    Status = true,
                     Message= "Data saved successfully",
                     Id = category.Id
                };
                return response;
            }
            catch(Exception ex)
            { 
                throw;
            }
        }

        public async Task<ResponseDto> Update(CategoryDto categoryDto)
        {
            try
            {
                Category category = await unitOfWork.CategoryRepository.GetByIdAsync(categoryDto.Id);
                if (category == null)
                    return new ResponseDto { Status = false, Message = "Data doesn't exists" };
                category.Name = categoryDto.Name;
                category.Description = categoryDto.Description;
                category.StoreId = categoryDto.StoreId;
                category.ModifiedAt = DateTime.UtcNow;
                await unitOfWork.SaveChangesAsync();
                var response = new ResponseDto
                {
                    Status = true,
                    Message = "Data updated successfully",
                    Id= category.Id
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
                var category = await unitOfWork.CategoryRepository.GetByIdAsync(Id);
                if(category == null)
                        return new ResponseDto { Status = false, Message="Data doesn't exists"};
                await unitOfWork.CategoryRepository.DeleteRecord(category);
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

        public async Task<CategoryDto> GetById(Int64 Id)
        {
            try
            {
                var entity = await unitOfWork.CategoryRepository.GetByIdAsync(Id);
                var categoryDto = Mapper.Mapping.Mapper.Map<CategoryDto>(entity);
                return categoryDto;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
