using PracticeWebApi.CommonClasses.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeWebApi.Data.Products
{
    public class FakeProductGroupRepository : IProductGroupRepository
    {
        private static IList<ProductGroupDataEntity> _productGroupDataEntities;

        public FakeProductGroupRepository()
        {
            _productGroupDataEntities = new List<ProductGroupDataEntity>();
        }

        public Task AddGroup(ProductGroupDataEntity productGroupDataEntity)
        {
            if (_productGroupDataEntities.Any(pg => pg.Id == productGroupDataEntity.Id)) 
                throw new DuplicateResourceException($"A product group with id {productGroupDataEntity.Id} already exists");

            if(_productGroupDataEntities.Any(pg => pg.Name == productGroupDataEntity.Name))
                throw new DuplicateResourceException($"A product group with name {productGroupDataEntity.Name} already exists");

            _productGroupDataEntities.Add(productGroupDataEntity);

            return Task.CompletedTask;
        }

        public Task DeleteProductGroup(string id)
        {
            if (!_productGroupDataEntities.Any(pg => pg.Id == id)) throw new ResourceNotFoundException($"No product group found with id {id}");

            _productGroupDataEntities = _productGroupDataEntities.Where(pg => pg.Id != id).ToList();

            return Task.CompletedTask;
        }

        public Task<IList<ProductGroupDataEntity>> GetAllProductGroups() => Task.FromResult(_productGroupDataEntities);
    }
}
