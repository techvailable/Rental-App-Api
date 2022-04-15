using RentalWebInfrastructure.Entities;

namespace RentalWebService.DTOs
{
    public class CategoryDto : Dto
    {
        public Int64 Id { get; set; }
        public Int64 StoreId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Store? Store { get; set; }
    }
}
