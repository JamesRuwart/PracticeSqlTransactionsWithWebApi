using PracticeWebApi.CommonClasses.Products;
using PracticeWebApi.Data;
using PracticeWebApi.Data.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeWebApi.Services.Products
{
    public class ProductGroupService : IProductGroupService
    {
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IMapper<ProductGroup, ProductGroupDataEntity> _mapper;

        public ProductGroupService(IProductGroupRepository productGroupRepository, IMapper<ProductGroup, ProductGroupDataEntity> mapper)
        {
            _productGroupRepository = productGroupRepository;
            _mapper = mapper;
        }

        public async Task<ProductGroup> AddProductGroup(ProductGroup productGroup)
        {
            if (productGroup is null) throw new ArgumentNullException(nameof(productGroup));
            if (string.IsNullOrWhiteSpace(productGroup.Name)) throw new ArgumentException($"{nameof(productGroup.Name)} cannot be null or white space");

            productGroup.Id = Guid.NewGuid().ToString();

            var productGroupDataEntity = _mapper.MapToDataEntity(productGroup);

            await _productGroupRepository.AddGroup(productGroupDataEntity);

            return productGroup;
        }

        public async Task DeleteProductGroup(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));
            await _productGroupRepository.DeleteProductGroup(id);
        }

        public async Task<IEnumerable<ProductGroup>> GetAllProductGroups()
        {
            var productGroupDataEntities = await _productGroupRepository.GetAllProductGroups();
            var productGroups = productGroupDataEntities.Select(productGroup => _mapper.MapToBase(productGroup));

            return productGroups;
        }
    }
}
