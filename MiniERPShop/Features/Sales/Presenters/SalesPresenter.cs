using MiniERPShop.Common.Results;
using MiniERPShop.Features.Sales.Services;
using MiniERPShop.Features.Sales.Views;

namespace MiniERPShop.Features.Sales.Presenters;

/// <summary>
/// Điều phối chức năng bán hàng.
/// </summary>
public class SalesPresenter
{
    private readonly ISalesView _view;
    private readonly SalesService _salesService;

    /// <summary>
    /// Khởi tạo Presenter.
    /// </summary>
    public SalesPresenter(
        ISalesView view,
        SalesService salesService)
    {
        _view = view;
        _salesService = salesService;
    }

    /// <summary>
    /// Thực hiện quy trình bán hàng.
    /// </summary>
    public void SellProduct()
    {
        int productId = _view.AskProductId();

        int quantity = _view.AskQuantity();

        OperationResult result =
            _salesService.Sell(
                productId,
                quantity);

        if (result.Success)
        {
            _view.ShowSuccess(result.Message);
        }
        else
        {
            _view.ShowError(result.Message);
        }
    }
}