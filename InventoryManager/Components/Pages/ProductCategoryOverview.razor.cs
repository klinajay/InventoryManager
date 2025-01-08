using System.Runtime.CompilerServices;
using InventoryManager.Contracts.Services;
using InventoryManager.Models.Domain;
using InventoryManager.Services;
using Microsoft.AspNetCore.Components;

namespace InventoryManager.Components.Pages
{
    public partial class ProductCategoryOverview
    {

        [Inject]
        public IProductCategoryRepositoryService ProductCategoryService { get; set; }
        public IEnumerable<ProductCategory> SelectedProductCategories { get; set; }
        public string? errorMessage;
        public bool isError = false;
        public bool isLoading = false;
        protected async override Task OnInitializedAsync()
        {
            isLoading = true;
            SelectedProductCategories = await ProductCategoryService.GetAllCategories();
            isLoading = false;
            if(SelectedProductCategories == null)
            {
                isError = true;
                errorMessage = "Error while fetching the product categories. go back to try again.";
            }
            
        }
    }
}
