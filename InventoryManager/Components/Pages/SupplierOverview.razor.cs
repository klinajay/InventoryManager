using InventoryManager.Contracts.Services;
using InventoryManager.Models.Domain;
using Microsoft.AspNetCore.Components;

namespace InventoryManager.Components.Pages
{
    public partial class SupplierOverview
    {
        [Inject]
        public ISupplierRepositoryService _supplierRepositoryService { get; set; }
        public IEnumerable<Supplier> SelectedSupplier{ get; set; }
        public string? errorMessage;
        public bool isError = false;
        public bool isLoading = false;
        
        protected async override Task OnInitializedAsync()
        {
            isLoading = true;
            SelectedSupplier = await _supplierRepositoryService.GetAllSuppliers();
            isLoading = false;
            if (SelectedSupplier == null)
            {
                isError = true;
                errorMessage = "Error while fetching the product categories. go back to try again.";
            }

        }
		private async Task DeleteSupplier(string supplierId)
		{
            isLoading = true;
            isError = await _supplierRepositoryService.DeleteSupplier(supplierId);
            isLoading = false;
            if(!isError)
            {
                isError = true;
                errorMessage = "Something went wrong while deleteing the supplier.try going back.";
            }

        }
    }
}
