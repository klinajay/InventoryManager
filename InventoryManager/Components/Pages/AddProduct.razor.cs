using InventoryManager.Contracts.Services;
using InventoryManager.Models.Domain;
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
