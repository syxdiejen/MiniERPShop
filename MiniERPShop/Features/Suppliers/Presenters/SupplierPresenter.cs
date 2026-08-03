using MiniERPShop.Features.Suppliers.Services;
using MiniERPShop.Features.Suppliers.Views;

namespace MiniERPShop.Features.Suppliers.Presenters;

public class SupplierPresenter
{
    private readonly ISupplierView _view;
    private readonly SupplierService _supplierService;

    public SupplierPresenter(
        ISupplierView view,
        SupplierService supplierService)
    {
        _view = view;
        _supplierService = supplierService;
    }

    public void DisplaySuppliers()
    {
        var suppliers = _supplierService.GetAllSuppliers();

        _view.ShowSuppliers(suppliers);
    }
}