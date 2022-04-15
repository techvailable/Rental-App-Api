using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.Infrastructure;
using RentalWebService.DTOs;
using RentalWebService.IServices;

namespace RentalWebService.Services
{
    public class StoreService : IStoreService
    {
        private readonly IUnitOfWork unitOfWork;
        public StoreService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task<List<StoreDto>> Get()
        {
            try
            {
                var stores = await unitOfWork.StoreRepository.GetAsync();
                var storeDtoList = Mapper.Mapping.Mapper.Map<List<StoreDto>>(stores);
                return storeDtoList;
            }
            catch(Exception exception)
            {
                throw;
            }
        }

        public async Task<ResponseDto> Add(StoreDto storeDto)
        {
            try
            {
                Store store = Mapper.Mapping.Mapper.Map<Store>(storeDto);
                unitOfWork.StoreRepository.Add(store);
                await unitOfWork.SaveChangesAsync();
                var response = new ResponseDto
                {
                    Status = true,
                     Message= "Data saved successfully",
                     Id = store.Id
                };
                return response;
            }
            catch(Exception ex)
            { 
                throw;
            }
        }

        public async Task<ResponseDto> Update(StoreDto storeDto)
        {
            try
            {
                Store store = await unitOfWork.StoreRepository.GetByIdAsync(storeDto.Id);
                if (store == null)
                    return new ResponseDto { Status = false, Message = "Data doesn't exists" };
                store.Name = storeDto.Name;
                store.Description = storeDto.Description;
                store.ModifiedAt = DateTime.UtcNow;
                await unitOfWork.SaveChangesAsync();
                var response = new ResponseDto
                {
                    Status = true,
                    Message = "Data updated successfully",
                    Id= store.Id
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
                var store = await unitOfWork.StoreRepository.GetByIdAsync(Id);
                if(store == null)
                        return new ResponseDto { Status = false, Message="Data doesn't exists"};
                await unitOfWork.StoreRepository.DeleteRecord(store);
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

        public async Task<StoreDto> GetById(Int64 Id)
        {
            try
            {
                var stores = await unitOfWork.StoreRepository.GetByIdAsync(Id);
                var storeDto = Mapper.Mapping.Mapper.Map<StoreDto>(stores);
                return storeDto;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
