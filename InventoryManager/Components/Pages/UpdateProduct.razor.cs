using InventoryManager.Contracts.Services;
using InventoryManager.Models.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Diagnostics.HealthChecks;
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
        public bool isLoading = false;
        public bool isError = false;
        public string errorMessage;
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
                if(ProductSelected.ProductPrice <= 0)
            {
                    errorMessage = "Price must be greater than zero.";
                    isError = true;
                    return;
                }

                if (ProductSelected.ProductQuantity <= 0)
                {
                    errorMessage = "Quantity must be greater than zero.";
                    isError = true;
                    return;
                }
                Supplier selectedSupplier = await SupplierRepositoryService.GetSupplierById(ProductSelected.SupplierId);
                if(selectedSupplier == null)
                {
                    errorMessage = "Supplier not found.";
                    isError = true;
                    return;
                }
                ProductCategory selectedCategory = await ProductCategoryRepositoryService.GetProductCategoriesById(ProductSelected.ProductCategoryId);
                if (selectedCategory == null)
                {
                    errorMessage = "Product category not found.";
                    isError = true;
                    return;
                }
                isLoading = true;
                bool status = await ProductRepositoryService.UpdateProduct(ProductSelected);
                if(!status)
                {
                    isLoading = false;
                    isError = true;
                    errorMessage = "Someting went wrong while updating product. go back to try again.";
                    throw new Exception();
                }

                NavigationManager.NavigateTo($"/productoverview/{ProductId}");
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error updating product: {ex.Message}");
            }
        }
        public void Cancel()
        {
            NavigationManager.NavigateTo("/productoverview");
        }
    }
}
