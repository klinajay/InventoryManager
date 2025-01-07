using System.Text.Json;
using InventoryManager.Models.Domain;

namespace InventoryManager.Client.Services
{
    public class ClientProductDataService : IProductRepositoryClientService
    {
        private readonly HttpClient _httpClient;
        public ClientProductDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {

            Console.WriteLine("Entered");
            IEnumerable<Product>? productsList = await JsonSerializer.DeserializeAsync<IEnumerable<Product>>(
                                                await _httpClient.GetStreamAsync("/api/products"),
                                                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return productsList;
            
        }

        public Task<Product> GetProductById(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalProducts()
        {
            throw new NotImplementedException();
        }
    }
}
