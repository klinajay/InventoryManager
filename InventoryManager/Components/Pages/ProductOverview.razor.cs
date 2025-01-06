using InventoryManager.Contracts.Repositories;
using InventoryManager.Contracts.Services;
using InventoryManager.Models.Domain;
using InventoryManager.Models.Services;
using InventoryManager.Services;
using Microsoft.AspNetCore.Components;
using Serilog;
namespace InventoryManager.Components.Pages
{
    public partial class ProductOverview
    {
        public IEnumerable<Product> Products { get; set; } = default!;
        [Inject]
        public IProductRepositoryService? ProductService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            
            
            Products = await ProductService.GetAllProducts();
            
            Log.Information($"Products found {Products}");
        }
    }
}
