using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.Infrastructure;
using RentalWebService.DTOs;
using RentalWebService.IServices;

namespace RentalWebService.Services
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork unitOfWork;
        public BrandService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task<List<BrandDto>> Get()
        {
            try
            {
                var entities = await unitOfWork.BrandRepository.GetAsync();
                var entityDtoList = Mapper.Mapping.Mapper.Map<List<BrandDto>>(entities);
                return entityDtoList;
            }
            catch(Exception exception)
            {
                throw;
            }
        }

        public async Task<ResponseDto> Add(BrandDto brandDto)
        {
            try
            {
                Brand brand = Mapper.Mapping.Mapper.Map<Brand>(brandDto);
                await unitOfWork.BrandRepository.Add(brand);
                await unitOfWork.SaveChangesAsync();
                var response = new ResponseDto
                {
                    Status = true,
                     Message= "Data saved successfully",
                     Id = brand.Id
                };
                return response;
            }
            catch(Exception ex)
            { 
                throw;
            }
        }

        public async Task<ResponseDto> Update(BrandDto brandDto)
        {
            try
            {
                Brand brand = await unitOfWork.BrandRepository.GetByIdAsync(brandDto.Id);
                if (brand == null)
                    return new ResponseDto { Status = false, Message = "Data doesn't exists" };
                brand.Name = brandDto.Name;
                brand.Description = brandDto.Description;
                brand.CategoryId = brandDto.CategoryId;
                brand.ModifiedAt = DateTime.UtcNow;
                await unitOfWork.SaveChangesAsync();
                var response = new ResponseDto
                {
                    Status = true,
                    Message = "Data updated successfully",
                    Id= brand.Id
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
                var brand = await unitOfWork.BrandRepository.GetByIdAsync(Id);
                if(brand == null)
                        return new ResponseDto { Status = false, Message="Data doesn't exists"};
                await unitOfWork.BrandRepository.DeleteRecord(brand);
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

        public async Task<BrandDto> GetById(Int64 Id)
        {
            try
            {
                var entity = await unitOfWork.BrandRepository.GetByIdAsync(Id);
                var brandDto = Mapper.Mapping.Mapper.Map<BrandDto>(entity);
                return brandDto;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
