using InventoryManager.Contracts.Repositories;
using InventoryManager.Contracts.Services;
using InventoryManager.Models.Domain;

namespace InventoryManager.Services
{
    public class ProductCategoryRepositoryService : IProductCategoryRepositoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        public ProductCategoryRepositoryService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<IEnumerable<ProductCategory>> GetAllCategories()
        {
            return await _productCategoryRepository.GetAllCategories();
        }
        public async Task<int> GetTotalCategories()
        {
            return await _productCategoryRepository.GetTotalCategories();
        }
    }
}
