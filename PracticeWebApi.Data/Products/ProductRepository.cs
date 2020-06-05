using PracticeWebApi.CommonClasses.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeWebApi.Data.Products
{
    public class ProductRepository : IProductRepository
    {
        private IList<ProductDataEntity> _Products;

        public ProductRepository()
        {
            _Products = new List<ProductDataEntity>();
        }

        public Task ActivateProduct(string productId)
        {
            var product = _Products.Where(p => p.Id == productId).FirstOrDefault();
            
            if (product is null) throw new ResourceNotFoundException($"Product Id {productId} does not exist. Please try again.");
            
            product.IsActive = true;

            return Task.CompletedTask;
        }

        public Task<ProductDataEntity> AddProduct(ProductDataEntity product)
        {
            throw new NotImplementedException();
        }

        public Task DeactiveProduct(string productId)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDataEntity> FindProductById(string productId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<ProductDataEntity>> GetProductsByGroupId(string groupId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProduct(ProductDataEntity product)
        {
            throw new NotImplementedException();
        }
    }
}
