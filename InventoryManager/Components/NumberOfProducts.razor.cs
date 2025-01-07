using InventoryManager.Client.Services;
using InventoryManager.Contracts.Repositories;
//using InventoryManager.Contracts.Services;
using InventoryManager.State;
using Microsoft.AspNetCore.Components;

namespace InventoryManager.Components
{
    public partial class NumberOfProducts
    {
        public int totalProducts;
        [Inject]
        public ApplicationState ApplicationState { get; set; }
        [Inject]
        public Contracts.Services.IProductRepositoryService ProductServices { get; set; }

        protected  override async Task OnInitializedAsync()
        {
            ApplicationState.NumberOfProducts = await ProductServices.GetTotalProducts();
            totalProducts = ApplicationState.NumberOfProducts;
        }
    }
}
