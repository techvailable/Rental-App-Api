namespace RentalWebService.DTOs
{
    public class StoreDto : Dto
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
