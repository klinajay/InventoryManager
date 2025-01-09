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
        [Inject]
        public IProductCategoryRepositoryService? ProductCategoryService { get; set; }
        public string SelectedCategory;
        public IEnumerable<ProductCategory> Categories = new List<ProductCategory>();
        public bool isError = false;
        public string errorMessage;
        protected override async Task OnInitializedAsync()
        {
            
            
            Products = await ProductService.GetAllProducts();
            Categories = await ProductCategoryService.GetAllCategories();
            foreach(var i in Categories)
            {
                Console.WriteLine(i.ProductCategoryId);
            }
            Log.Information($"Products found {Products}");
        }
        public async Task RenderProductByCategories()
        {
            string categoryId = null;
            
            foreach(var category in Categories)
            {
                if(category.CategoryName == SelectedCategory)
                {
                    categoryId = category.ProductCategoryId;
                }
            }
            if(categoryId == null)
            {
                isError = true;
                errorMessage = "Something went wrong while adding the product.";
                return;
            }
            //categoryId = ProductCategoryService.GetIdOfCategory(SelectedCategory);
            Products = await ProductService.GetProductsByCategory( categoryId);
            StateHasChanged();
        }
    }
}
