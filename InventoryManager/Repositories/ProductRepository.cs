﻿using System.Runtime.CompilerServices;
using InventoryManager.Contracts.Repositories;
using InventoryManager.Data;
using InventoryManager.Models.Domain;
using Microsoft.EntityFrameworkCore;
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
        public void Dispose() {
            _appDbContext.Dispose();
        }   
    }
}
