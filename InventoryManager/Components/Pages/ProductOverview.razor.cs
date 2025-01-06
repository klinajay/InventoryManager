using InventoryManager.Models.Domain;
using InventoryManager.Models.Services;
using Serilog;
namespace InventoryManager.Components.Pages
{
    public partial class ProductOverview
    {
        List<Product> Products { get; set; } = default!;
        protected override async Task OnInitializedAsync()
        {
            //Console.WriteLine("Inside the ProductOverview");
            await Task.Delay(1000);
            DataInitializationService.InitializeDemoData();
            Products = DataInitializationService.products;
            Log.Information($"Products initialized {Products}");
        }
    }
}
