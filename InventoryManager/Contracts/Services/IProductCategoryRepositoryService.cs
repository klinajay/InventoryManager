using InventoryManager.Models.Domain;

namespace InventoryManager.Contracts.Services
{
    public interface IProductCategoryRepositoryService
    {
        public Task<IEnumerable<ProductCategory>> GetAllCategories();
        public Task<int> GetTotalCategories();
        public Task<ProductCategory>GetProductCategoriesById(string Id);
     
        public string GetIdOfCategory(string categoryName);
    }
}
