using System.Net.NetworkInformation;
using InventoryManager.Models;
using Microsoft.AspNetCore.Components;

namespace InventoryManager.Components
{
    public partial class ProductCard
    {
        [Parameter]
        public Product product { get; set; } 
        
    }
}
