namespace PracticeWebApi.Data.Products
{
    public class ProductDataEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string GroupId { get; set; }
        public bool IsActive { get; set; }
    }
}
