using PracticeWebApi.CommonClasses.Products;
using PracticeWebApi.Data.Products;

namespace PracticeWebApi.Services.Products
{
    public class ProductGroupMapper : IMapper<ProductGroup, ProductGroupDataEntity>
    {
        public ProductGroup MapToBase(ProductGroupDataEntity dataEntity) => new ProductGroup
        {
            Id = dataEntity.Id,
            Name = dataEntity.Name
        };

        public ProductGroupDataEntity MapToDataEntity(ProductGroup productGroup) => new ProductGroupDataEntity
        {
            Id = productGroup.Id,
            Name = productGroup.Name
        };
    }
}
