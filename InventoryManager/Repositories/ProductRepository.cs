﻿using System.Runtime.CompilerServices;
using InventoryManager.Contracts.Repositories;
using InventoryManager.Data;
using InventoryManager.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;

namespace InventoryManager.Repositories
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        private readonly AppDbContext _appDbContext;
        public ProductRepository(IDbContextFactory<AppDbContext> DbFactory)
        {
            _appDbContext = DbFactory.CreateDbContext();
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _appDbContext.Products.Select(p => p).ToListAsync();
        }
        public async Task<int> GetTotalProducts()
        {
            try
            {
                int totalProducts = await _appDbContext.Products.CountAsync();
                return totalProducts;
            }
            catch (Exception ex)
            {
                Log.Error("Something went wrong.",ex);
                return 0; 
            }
        }
        public async Task<Product> GetProductById(string Id)
        {
            Product? selectedProduct = default!;
            
            selectedProduct = await _appDbContext.Products.FirstOrDefaultAsync(product => product.ProductId == Id);
            
            return selectedProduct; 
        }
        public async Task<bool> UpdateProduct(Product responseProduct)
        {
            if (responseProduct == null)
            {
                Log.Information("Provided product is null.");
                return false;
            }
            Product? existingProduct = await _appDbContext.Products.FindAsync(responseProduct.ProductId);
            if (existingProduct != null) { 
                existingProduct.ProductId = responseProduct.ProductId;
                existingProduct.ProductName = responseProduct.ProductName;
                existingProduct.ProductPrice = responseProduct.ProductPrice;
                existingProduct.ProductQuantity = responseProduct.ProductQuantity;
                existingProduct.ProductCategoryId = responseProduct.ProductCategoryId;
                existingProduct.Description = responseProduct.Description;
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            
                Log.Information("Product not found.");
                return false;
            
            
            
        }
        public async Task<bool> DeleteProduct(string Id)
        {
            if (Id.IsNullOrEmpty())
            {
                Log.Information("Provided product id is null.");
                return false;
            }

            Product? existingProduct = await _appDbContext.Products.FindAsync(Id);

            if(existingProduct != null)
            {
                _appDbContext.Products.Remove(existingProduct);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            Log.Information("Product not found.");
            return false;

        }
        public async Task<bool> AddProduct(Product inputProduct , string productId)
        {
            if (inputProduct == null)
            {
                Log.Information("Provided product is null.");
                return false;
            }
            inputProduct.ProductId = productId;
            await _appDbContext.Products.AddAsync(inputProduct);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
        public string GetLastProductId()
        {
            string productId =  _appDbContext.Products.Max(product => product.ProductId);
            return productId;
        }
        public async Task<IEnumerable<Product>> GetProductsByCategory(string categoryId)
        {
            List<Product> selectedProduct = default!;

            selectedProduct = await _appDbContext.Products.Where(product => product.ProductCategoryId == categoryId).Select(product => product).ToListAsync();

            return selectedProduct;
        }
        public void Dispose() {
            _appDbContext.Dispose();
        }   
    }
}
