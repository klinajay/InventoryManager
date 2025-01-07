
//using InventoryManager.Client.Services;
using InventoryManager.Models.Domain;

using Microsoft.AspNetCore.Components;
using Serilog;
namespace InventoryManager.Client.Pages
{
    public partial class ProductOverview
    {
        public IEnumerable<Product> Products { get; set; } = default!;
        //[Inject]
        //public IProductRepositoryService? ProductService { get; set; }
        protected override async Task OnInitializedAsync()
        {


            Products = await clientProductService.GetAllProducts();

            Log.Information($"Products found {Products}");
        }
    }
}
