using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.Infrastructure;
using RentalWebService.DTOs;
using RentalWebService.IServices;

namespace RentalWebService.Services
{
    public class ProductReviewService : IProductReviewService
    {
        private readonly IUnitOfWork unitOfWork;
        public ProductReviewService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task<List<ProductReviewDto>> Get()
        {
            try
            {
                var entities = await unitOfWork.ProductReviewRepository.GetAsync();
                var entityDtoList = Mapper.Mapping.Mapper.Map<List<ProductReviewDto>>(entities);
                return entityDtoList;
            }
            catch(Exception exception)
            {
                throw;
            }
        }

        public async Task<ResponseDto> Add(ProductReviewDto productReviewDto)
        {
            try
            {
                ProductReview productReview = Mapper.Mapping.Mapper.Map<ProductReview>(productReviewDto);
                await unitOfWork.ProductReviewRepository.Add(productReview);
                await unitOfWork.SaveChangesAsync();
                var response = new ResponseDto
                {
                    Status = true,
                     Message= "Data saved successfully",
                     Id = productReview.Id
                };
                return response;
            }
            catch(Exception ex)
            { 
                throw;
            }
        }

        //public async Task<ResponseDto> Update(ProductReviewDto productReviewDto)
        //{
        //    try
        //    {
        //        ProductReview productReview = await unitOfWork.ProductReviewRepository.GetByIdAsync(productReviewDto.Id);
        //        if (productReview == null)
        //            return new ResponseDto { Status = false, Message = "Data doesn't exists" };
        //        productReview.Name = productReviewDto.Name;
        //        productReview.Description = productReviewDto.Description;
        //        productReview.StoreId = productReviewDto.StoreId;
        //        productReview.ModifiedAt = DateTime.UtcNow;
        //        await unitOfWork.SaveChangesAsync();
        //        var response = new ResponseDto
        //        {
        //            Status = true,
        //            Message = "Data updated successfully",
        //            Id= productReview.Id
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
                var productReview = await unitOfWork.ProductReviewRepository.GetByIdAsync(Id);
                if(productReview == null)
                        return new ResponseDto { Status = false, Message="Data doesn't exists"};
                await unitOfWork.ProductReviewRepository.DeleteRecord(productReview);
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

        public async Task<ProductReviewDto> GetById(Int64 Id)
        {
            try
            {
                var entity = await unitOfWork.ProductReviewRepository.GetByIdAsync(Id);
                var productReviewDto = Mapper.Mapping.Mapper.Map<ProductReviewDto>(entity);
                return productReviewDto;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
