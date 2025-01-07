using InventoryManager.Contracts.Services;
using InventoryManager.Models.Domain;
using Microsoft.AspNetCore.Components;
using Serilog;


namespace InventoryManager.Components.Pages
{
    public partial class UpdateProduct
    {

        [Parameter]
        public string ProductId { get; set; } = string.Empty;

        [Inject]
        public IProductRepositoryService ProductRepositoryService { get; set; }
        [Inject]
        public ISupplierRepositoryService SupplierRepositoryService { get; set; }
        [Inject]
        public IProductCategoryRepositoryService ProductCategoryRepositoryService { get; set; }

        public Product ProductSelected { get; set; } = new Product();
        public ProductCategory ProductCategory { get; set; } = new ProductCategory();
        public Supplier SupplierSelected { get; set; } = new Supplier();

        protected async override Task OnInitializedAsync()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ProductId))
                {
                    Log.Error("ProductId is null or empty.");
                    return;
                }

                ProductSelected = await ProductRepositoryService.GetProductById(ProductId);

                if (ProductSelected == null)
                {
                    Log.Error("Product not found with ID: {ProductId}", ProductId);
                    return;
                }

                ProductCategory = await ProductCategoryRepositoryService.GetProductCategoriesById(ProductSelected.ProductCategoryId);
                if (ProductCategory == null)
                {
                    Log.Error("Product category not found with ID: {ProductId}", ProductId);
                    return;
                }
                SupplierSelected = await SupplierRepositoryService.GetSupplierById(ProductSelected.SupplierId);
                if (SupplierSelected == null)
                {
                    Log.Error("Product supplier not found with ID: {ProductId}", ProductId);
                    return;
                }
            }
            catch (Exception e)
            {
                Log.Error(e, "Error occurred while loading product details.");
            }
        }
    
    
    public async Task HandleValidSubmit() {
            try
            {
                // Logic to save or update the product
                //await ProductRepositoryService.UpdateProduct(ProductSelected);

                // Navigate back to the product list or show a success message
                NavigationManager.NavigateTo("/products");
            }
            catch (Exception ex)
            {
                // Handle errors (optional)
                Console.WriteLine($"Error updating product: {ex.Message}");
            }
        }
        public void Cancel()
        {
            NavigationManager.NavigateTo("/productoverview");
        }
    }
}
