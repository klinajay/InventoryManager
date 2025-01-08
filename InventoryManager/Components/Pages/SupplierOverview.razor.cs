using InventoryManager.Contracts.Services;
using InventoryManager.Models.Domain;
using Microsoft.AspNetCore.Components;

namespace InventoryManager.Components.Pages
{
    public partial class SupplierOverview
    {
        [Inject]
        public ISupplierRepositoryService SupplierRepositoryService { get; set; }
        public IEnumerable<Supplier> SelectedSupplier{ get; set; }
        public string? errorMessage;
        public bool isError = false;
        public bool isLoading = false;
        protected async override Task OnInitializedAsync()
        {
            isLoading = true;
            SelectedSupplier = await SupplierRepositoryService.GetAllSuppliers();
            isLoading = false;
            if (SelectedSupplier == null)
            {
                isError = true;
                errorMessage = "Error while fetching the product categories. go back to try again.";
            }

        }
    }
}
