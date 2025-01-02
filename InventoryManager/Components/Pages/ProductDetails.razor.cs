using Microsoft.AspNetCore.Components;
using InventoryManager.Models;
using InventoryManager.Models.Services;
namespace InventoryManager.Components.Pages
{
    public partial class ProductDetails
    {
        [Parameter]
        public string ProductId { get; set; } = string.Empty;

        public Product ProductSelected;
        public ProductCategory ProductCategory;

        protected override void OnInitialized()
        {
            Console.WriteLine($"Inside the {ProductId}");
            ProductSelected = DataInitializationService.products.Single(product => product.ProductId == ProductId);
            ProductCategory = DataInitializationService.productCategories.Single(category => category.CategoryId == ProductSelected.ProductCategoryId);
        }
    }
}
