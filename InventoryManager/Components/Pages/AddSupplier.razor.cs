using InventoryManager.Contracts.Services;
using InventoryManager.Models.Domain;
using Microsoft.AspNetCore.Components;

namespace InventoryManager.Components.Pages
{
    public partial class AddSupplier
    {
        public bool isLoading = false;
        public bool isSucess = true;
        public string errorMessage = default!;
        [Inject]
        private ISupplierRepositoryService _supplierRepositoryService { get; set; }
        public Supplier SupplierSelected { get; set; } = new();

        public async Task HandleValidSubmit()
        {
            
            if (SupplierSelected.SupplierContact.Length != 10 || !(CheckMobileNumber(SupplierSelected.SupplierContact)))
            {
                errorMessage = "Enter valid 10 digit mobile.";
                isSucess = false;
                return;
            }
            isLoading = true;
            isSucess = await _supplierRepositoryService.AddSupplier(SupplierSelected);
            isLoading = false;
            if (!isSucess)
            {
                errorMessage = "Something went wrong while adding the product. fill out details correctly";
                return;
            }
            NavigationManager.NavigateTo("/supplieroverview");
        }

        public bool CheckMobileNumber(string supplierContact)
        {
            if (supplierContact.Length != 10) return false;
            for(int i = 0; i < 10; i++)
            {
                if (supplierContact[i] < '0' || supplierContact[i] > '9')
                {
                    Console.WriteLine("break");
                    return false;
                }
            }
            return true;
        }

        public void Cancel()
        {
            NavigationManager.NavigateTo("/");
        }

    }
}
