using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.Infrastructure;
using RentalWebService.DTOs;
using RentalWebService.IServices;

namespace RentalWebService.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        public SubCategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task<List<SubCategoryDto>> Get()
        {
            try
            {
                var entities = await unitOfWork.SubCategoryRepository.GetAsync();
                var entityDtoList = Mapper.Mapping.Mapper.Map<List<SubCategoryDto>>(entities);
                return entityDtoList;
            }
            catch(Exception exception)
            {
                throw;
            }
        }

        public async Task<ResponseDto> Add(SubCategoryDto subCategoryDto)
        {
            try
            {
                SubCategory subCategory = Mapper.Mapping.Mapper.Map<SubCategory>(subCategoryDto);
                await unitOfWork.SubCategoryRepository.Add(subCategory);
                await unitOfWork.SaveChangesAsync();
                var response = new ResponseDto
                {
                    Status = true,
                     Message= "Data saved successfully",
                     Id = subCategory.Id
                };
                return response;
            }
            catch(Exception ex)
            { 
                throw;
            }
        }

        public async Task<ResponseDto> Update(SubCategoryDto subCategoryDto)
        {
            try
            {
                SubCategory subCategory = await unitOfWork.SubCategoryRepository.GetByIdAsync((long)subCategoryDto.Id);
                if (subCategory == null)
                    return new ResponseDto { Status = false, Message = "Data doesn't exists" };
                subCategory.Name = subCategoryDto.Name;
                subCategory.Description = subCategoryDto.Description;
                subCategory.CategoryId = subCategoryDto.CategoryId;
                subCategory.ModifiedAt = DateTime.UtcNow;
                await unitOfWork.SaveChangesAsync();
                var response = new ResponseDto
                {
                    Status = true,
                    Message = "Data updated successfully",
                    Id= subCategory.Id
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
                var subCategory = await unitOfWork.SubCategoryRepository.GetByIdAsync(Id);
                if(subCategory == null)
                        return new ResponseDto { Status = false, Message="Data doesn't exists"};
                await unitOfWork.SubCategoryRepository.DeleteRecord(subCategory);
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

        public async Task<SubCategoryDto> GetById(Int64 Id)
        {
            try
            {
                var entity = await unitOfWork.SubCategoryRepository.GetByIdAsync(Id);
                var subCategoryDto = Mapper.Mapping.Mapper.Map<SubCategoryDto>(entity);
                return subCategoryDto;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
