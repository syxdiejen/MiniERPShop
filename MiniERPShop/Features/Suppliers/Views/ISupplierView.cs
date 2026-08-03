using MiniERPShop.Features.Suppliers.Models;

namespace MiniERPShop.Features.Suppliers.Views;

public interface ISupplierView
{
    void ShowSuppliers(IReadOnlyList<Supplier> suppliers);

    void ShowMessage(string message);
}