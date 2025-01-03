using Microsoft.AspNetCore.Components;
using InventoryManager.Models;
using InventoryManager.Models.Services;
using Serilog;
namespace InventoryManager.Components.Pages
{
    public partial class ProductDetails
    {
        [Parameter]
        public string ProductId { get; set; } = string.Empty;

        public Product ProductSelected;
        public ProductCategory ProductCategory;
        public Supplier SupplierSelected;

        protected override void OnInitialized()
        {
            try
            {
                ProductSelected = DataInitializationService.products.Single(product => product.ProductId == ProductId);
                ProductCategory = DataInitializationService.productCategories.Single(category => category.CategoryId == ProductSelected.ProductCategoryId);
                SupplierSelected = DataInitializationService.suppliers.Single(supplier => supplier.SupplierId == ProductSelected.SupplierId);

            }
            catch (Exception e)
            {
                Log.Error(e, "Product not found.");
            }
            
        }
        public void LogError()
        {
            Log.Error("Product not found.");
        }
    }
}
