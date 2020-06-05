using PracticeWebApi.Data.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticeWebApi.Data
{
    public interface IProductGroupRepository
    {
        Task AddGroup(ProductGroupDataEntity productGroupDataEntity);
        Task<IList<ProductGroupDataEntity>> GetAllProductGroups();
        Task DeleteProductGroup(string id);
    }
}
