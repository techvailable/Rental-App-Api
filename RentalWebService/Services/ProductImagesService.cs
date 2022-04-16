using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.Infrastructure;
using RentalWebService.DTOs;
using RentalWebService.IServices;

namespace RentalWebService.Services
{
    public class ProductImagesService : IProductImagesService
    {
        private readonly IUnitOfWork unitOfWork;
        public ProductImagesService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task<List<ProductImagesDto>> Get()
        {
            try
            {
                var entities = await unitOfWork.ProductImagesRepository.GetAsync();
                var entityDtoList = Mapper.Mapping.Mapper.Map<List<ProductImagesDto>>(entities);
                return entityDtoList;
            }
            catch(Exception exception)
            {
                throw;
            }
        }

        public async Task<ResponseDto> Add(ProductImagesDto productImagesDto)
        {
            try
            {
                ProductImages productImages = Mapper.Mapping.Mapper.Map<ProductImages>(productImagesDto);
                await unitOfWork.ProductImagesRepository.Add(productImages);
                await unitOfWork.SaveChangesAsync();
                var response = new ResponseDto
                {
                    Status = true,
                     Message= "Data saved successfully",
                     Id = productImages.Id
                };
                return response;
            }
            catch(Exception ex)
            { 
                throw;
            }
        }

        //public async Task<ResponseDto> Update(ProductImagesDto productImagesDto)
        //{
        //    try
        //    {
        //        ProductImages productImages = await unitOfWork.ProductImagesRepository.GetByIdAsync(productImagesDto.Id);
        //        if (productImages == null)
        //            return new ResponseDto { Status = false, Message = "Data doesn't exists" };
        //        productImages.Name = productImagesDto.Name;
        //        productImages.Description = productImagesDto.Description;
        //        productImages.StoreId = productImagesDto.StoreId;
        //        productImages.ModifiedAt = DateTime.UtcNow;
        //        await unitOfWork.SaveChangesAsync();
        //        var response = new ResponseDto
        //        {
        //            Status = true,
        //            Message = "Data updated successfully",
        //            Id= productImages.Id
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
                var productImages = await unitOfWork.ProductImagesRepository.GetByIdAsync(Id);
                if(productImages == null)
                        return new ResponseDto { Status = false, Message="Data doesn't exists"};
                await unitOfWork.ProductImagesRepository.DeleteRecord(productImages);
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

        public async Task<ProductImagesDto> GetById(Int64 Id)
        {
            try
            {
                var entity = await unitOfWork.ProductImagesRepository.GetByIdAsync(Id);
                var productImagesDto = Mapper.Mapping.Mapper.Map<ProductImagesDto>(entity);
                return productImagesDto;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
