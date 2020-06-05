using PracticeWebApi.CommonClasses;
using PracticeWebApi.CommonClasses.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticeWebApi.Services
{
    public interface IProductGroupService
    {
        Task<ProductGroup> AddProductGroup(ProductGroup productGroup);
        Task<IEnumerable<ProductGroup>> GetAllProductGroups();
        Task DeleteProductGroup(string id);
    }
}
