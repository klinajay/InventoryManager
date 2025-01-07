using System.Net.NetworkInformation;
using InventoryManager.Models.Domain;
using Microsoft.AspNetCore.Components;

namespace InventoryManager.Client.Components
{
    public partial class ProductCard
    {
        [Parameter]
        public Product product { get; set; }

    }
}
