using InventoryManager.Models;
using InventoryManager.Models.Services;
namespace InventoryManager.Components.Pages
{
    public partial class ProductOverview
    {
        List<Product> Products { get; set; } = default!;
        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(5000);
            DataInitializationService.InitializeDemoData();
            Products = DataInitializationService.products;
            
        }
    }
}
