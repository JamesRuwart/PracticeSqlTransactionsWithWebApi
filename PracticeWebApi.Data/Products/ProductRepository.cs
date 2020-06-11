using PracticeWebApi.CommonClasses.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeWebApi.Data.Products
{
    public class ProductRepository : IProductRepository
    {
        private string _connectionString = @"Data Source = MSI\SQLEXPRESS; Initial Catalog = PracticeCommerce; Integrated Security = True;";
        private string _addProduct =
            @"INSERT INTO Products (id, name, description, price, groupId, isActive) VALUES " +
            "(@Id, @Name, @Description, @Price, @GroupId, @IsActive)";
        private string _activateProduct = "SELECT * FROM Products WHERE [Id] = @ProductId";
        private string _deactiveProduct = "SELECT * FROM Products WHERE [Id] = @ProductId";
        private string _findProductById = "DELETE FROM Products WHERE [Id] = @ProductId";
        private string _getProductsByGroupId = "SELECT * FROM Products WHERE [Id] = @ProductId";
        private string _updateProduct = @"  
            UPDATE Products
              SET [name] = @Name,
	              [description] = @Description,
	              [price] = @Price,
	              [groupId] = @GroupId,
	              [isActive] = @IsActive,
            WHERE [Id] = @Id";

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
            _Products.Add(product);

            return Task.FromResult(product);
        }

        public Task DeactiveProduct(string productId)
        {
            var product = _Products.Where(p => p.Id == productId).FirstOrDefault();

            if (product is null) throw new ResourceNotFoundException($"Product Id {productId} does not exist. Please try again.");

            product.IsActive = false;

            return Task.CompletedTask;
        }

        public Task<ProductDataEntity> FindProductById(string productId)
        {
            var product = _Products.Where(p => p.Id == productId).FirstOrDefault();

            if (product is null) throw new ResourceNotFoundException($"Product Id {productId} does not exist. Please try again.");

            return Task.FromResult(product);
        }

        public Task<IList<ProductDataEntity>> GetProductsByGroupId(string groupId)
        {
            IList<ProductDataEntity> products = _Products.Where(p => p.GroupId == groupId && p.IsActive).ToList();

            return Task.FromResult(products);        
        }

        public Task UpdateProduct(ProductDataEntity product)
        {
            _Products= _Products.Where(p => p.Id != product.Id).ToList();

            _Products.Add(product);

            return Task.CompletedTask;
        }
    }
}
