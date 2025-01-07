
//using InventoryManager.Client.Services;
using InventoryManager.Client.Services;
using InventoryManager.Models.Domain;

using Microsoft.AspNetCore.Components;
using Serilog;
namespace InventoryManager.Client.Pages
{
    public partial class ProductOverview
    {
        private List<Product> Products  = new();
        [Inject]
        public IProductRepositoryClientService? ClientProductService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            //ClientProductDataService C = new ClientProductDataService(HttpClient _hhtpClient);

            //Products = (await ClientProductService.GetAllProducts()).ToList();

            Log.Information($"Products found {Products}");
        }
    }
}
