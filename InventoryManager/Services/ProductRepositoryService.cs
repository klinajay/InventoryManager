﻿using InventoryManager.Client.Services;
using InventoryManager.Contracts.Repositories;
using InventoryManager.Contracts.Services;
using InventoryManager.Models.Domain;

namespace InventoryManager.Services
{
    public class ProductRepositoryService : Contracts.Services.IProductRepositoryService
    {
        private readonly IProductRepository _productRepository;
        public ProductRepositoryService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllProducts();
        }
        public async Task<Product> GetProductById(string Id)
        {
            return await _productRepository.GetProductById(Id);
        }
        public async Task<int> GetTotalProducts()
        {
            return await _productRepository.GetTotalProducts();
        }
    }
}
