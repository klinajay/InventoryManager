using InventoryManager.Contracts.Services;
using InventoryManager.Models.Domain;
using InventoryManager.Services;
using Microsoft.AspNetCore.Components;

namespace InventoryManager.Components.Pages
{
    public partial class AddProduct
    {
        public bool isLoading = false;
        public bool isSucess = true;
        public string errorMessage = default!;
        [Inject]
        private IProductRepositoryService _productRepositoryService { get; set; }
        [Inject]
        public ISupplierRepositoryService SupplierRepositoryService { get; set; }
        [Inject]
        public IProductCategoryRepositoryService ProductCategoryRepositoryService { get; set; }
        public Product ProductSelected { get; set; } = new();

        public async Task HandleValidSubmit()
        {
            if (ProductSelected.ProductPrice <= 0)
            {
                errorMessage = "Price must be greater than zero.";
                isSucess = false;
                return;
            }

            if (ProductSelected.ProductQuantity <= 0)
            {
                errorMessage = "Quantity must be greater than zero.";
                isSucess = false;
                return;
            }
            Supplier selectedSupplier = await SupplierRepositoryService.GetSupplierById(ProductSelected.SupplierId);
            if (selectedSupplier == null)
            {
                errorMessage = "Supplier not found.";
                isSucess = false;
                return;
            }
            ProductCategory selectedCategory = await ProductCategoryRepositoryService.GetProductCategoriesById(ProductSelected.ProductCategoryId);
            if (selectedCategory == null)
            {
                errorMessage = "Product category not found.";
                isSucess = false;
                return;
            }
            isLoading = true;
            isSucess  = await _productRepositoryService.AddProduct(ProductSelected);
            isLoading = false;
            if (!isSucess) {
                errorMessage = "Something went wrong while adding the product. fill out details correctly";
                return;
            }
            NavigationManager.NavigateTo("/productoverview");
        }
        public void Cancel()
        {
            NavigationManager.NavigateTo("/");
        }

    }
}
