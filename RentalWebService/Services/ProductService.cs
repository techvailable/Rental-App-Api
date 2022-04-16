using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.Infrastructure;
using RentalWebService.DTOs;
using RentalWebService.IServices;

namespace RentalWebService.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task<List<ProductDto>> Get()
        {
            try
            {
                var entities = await unitOfWork.ProductRepository.GetAsync();
                var entityDtoList = Mapper.Mapping.Mapper.Map<List<ProductDto>>(entities);
                return entityDtoList;
            }
            catch(Exception exception)
            {
                throw;
            }
        }
        public async Task<List<ProductDto>> GetFeatured()
        {
            try
            {
                var entities = await unitOfWork.ProductRepository.GetFeatured();
                var entityDtoList = Mapper.Mapping.Mapper.Map<List<ProductDto>>(entities);
                return entityDtoList;
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public async Task<ResponseDto> Add(ProductDto productDto)
        {
            try
            {
                Product product = Mapper.Mapping.Mapper.Map<Product>(productDto);
                await unitOfWork.ProductRepository.Add(product);
                await unitOfWork.SaveChangesAsync();
                var response = new ResponseDto
                {
                    Status = true,
                     Message= "Data saved successfully",
                     Id = product.Id
                };
                return response;
            }
            catch(Exception ex)
            { 
                throw;
            }
        }

        public async Task<ResponseDto> Update(ProductDto productDto)
        {
            try
            {
                Product product = await unitOfWork.ProductRepository.GetByIdAsync(productDto.Id);
                if (product == null)
                    return new ResponseDto { Status = false, Message = "Data doesn't exists" };
                product.Name = productDto.Name;
                product.Description = productDto.Description;
                product.Quantity = productDto.Quantity;
                product.CategoryId = productDto.CategoryId;
                product.BrandId = productDto.BrandId;
                product.SubCategoryId = productDto.SubCategoryId;
                product.SKU = productDto.SKU;
                product.ShortDescription = productDto.ShortDescription;
                product.Notes = productDto.Notes;
                product.Specifications = productDto.Specifications;
                product.ProductIncludes = productDto.ProductIncludes;
                product.Image = productDto.Image;
                product.Price = productDto.Price;
                product.ModifiedAt = DateTime.UtcNow;
                await unitOfWork.SaveChangesAsync();
                var response = new ResponseDto
                {
                    Status = true,
                    Message = "Data updated successfully",
                    Id= product.Id
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
                var product = await unitOfWork.ProductRepository.GetByIdAsync(Id);
                if(product == null)
                        return new ResponseDto { Status = false, Message="Data doesn't exists"};
                await unitOfWork.ProductRepository.DeleteRecord(product);
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

        public async Task<ProductDto> GetById(Int64 Id)
        {
            try
            {
                var entity = await unitOfWork.ProductRepository.GetByIdAsync(Id);
                var productDto = Mapper.Mapping.Mapper.Map<ProductDto>(entity);
                return productDto;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
