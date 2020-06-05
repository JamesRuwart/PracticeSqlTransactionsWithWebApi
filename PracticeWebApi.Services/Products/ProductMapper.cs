using PracticeWebApi.CommonClasses.Products;
using PracticeWebApi.Data.Products;

namespace PracticeWebApi.Services.Products
{
    public class ProductMapper : IMapper<Product, ProductDataEntity>
    {
        public Product MapToBase(ProductDataEntity dataEntity) => new Product
        {
            Id = dataEntity.Id,
            Name = dataEntity.Name,
            Description = dataEntity.Description,
            Price = dataEntity.Price,
            GroupId = dataEntity.GroupId,
            IsActive = dataEntity.IsActive
        };

        public ProductDataEntity MapToDataEntity(Product product) => new ProductDataEntity
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            GroupId = product.GroupId,
            IsActive = product.IsActive
        };
    }
}
