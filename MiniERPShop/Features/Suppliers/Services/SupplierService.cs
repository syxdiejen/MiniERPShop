using MiniERPShop.Features.Suppliers.Models;

namespace MiniERPShop.Features.Suppliers.Services;

public class SupplierService
{
    private readonly List<Supplier> _suppliers;

    public SupplierService(List<Supplier> suppliers)
    {
        _suppliers = suppliers;
    }

    public IReadOnlyList<Supplier> GetAllSuppliers()
    {
        return _suppliers.AsReadOnly();
    }

    public Supplier? GetSupplierById(int supplierId)
    {
        return _suppliers.FirstOrDefault(s => s.Id == supplierId);
    }

    public bool AddSupplier(Supplier supplier)
    {
        if (_suppliers.Any(s => s.Id == supplier.Id))
        {
            return false; // Supplier with the same ID already exists
        }
        _suppliers.Add(supplier);
        return true;
    }   
}