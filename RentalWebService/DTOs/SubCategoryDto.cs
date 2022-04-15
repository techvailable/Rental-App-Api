namespace RentalWebService.DTOs
{
    public class SubCategoryDto : Dto
    {
        public Int64 Id { get; set; }
        public Int64 CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool Active { get; set; }

    }
}
