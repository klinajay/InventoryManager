using Microsoft.AspNetCore.Components;
using InventoryManager.Models.Services;
using Serilog;
using InventoryManager.Models.Domain;
using InventoryManager.Contracts.Services;
namespace InventoryManager.Components.Pages
{
    public partial class ProductDetails
    {
        [Parameter]
        public string ProductId { get; set; } = string.Empty;
        [Inject]
        public IProductRepositoryService ProductRepositoryService { get; set; }
        [Inject]
        public ISupplierRepositoryService SupplierRepositoryService { get; set; }
        [Inject]
        public IProductCategoryRepositoryService ProductCategoryRepositoryService { get; set; }

        public Product ProductSelected;
        public ProductCategory ProductCategory;
        public Supplier SupplierSelected;

        protected async override Task OnInitializedAsync()
        {
            try
            {
                ProductSelected = await ProductRepositoryService.GetProductById(ProductId);
                //ProductCategory = await ProductCategoryRepositoryService.GetAllCategories();
                //SupplierSelected = await SupplierRepositoryService.GetAllSuppliers();
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
