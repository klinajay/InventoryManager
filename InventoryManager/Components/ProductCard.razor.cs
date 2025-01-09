using System.Net.NetworkInformation;
using InventoryManager.Contracts.Services;
using InventoryManager.Models.Domain;
using InventoryManager.Services;
using Microsoft.AspNetCore.Components;

namespace InventoryManager.Components
{
    public partial class ProductCard
    {
        [Parameter]
        public Product product { get; set; }
        [Inject]
        private  IProductRepositoryService _productRepositoryService { get; set; }
        public string? errorMessage;
        public bool isSuccess = false;
        public bool isLoading = false;
        public async Task  DeleteProduct()
        {
            isLoading = true;
            await Task.Delay(2000);
            isSuccess = await _productRepositoryService.DeleteProduct(product.ProductId);
            isLoading = false;
            if(!isSuccess)
            {

                errorMessage = "Something went wrong while deleting product.go back to try again.";
            }
        }


    }
}
