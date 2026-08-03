using MiniERPShop.Features.Purchasing.DTOs;
using MiniERPShop.Features.Purchasing.Services;
using MiniERPShop.Features.Purchasing.Views;

namespace MiniERPShop.Features.Purchasing.Presenters
{
    public class PurchasePresenter
    {
        private readonly IPurchaseView _view;
        private readonly PurchaseService _purchaseService;

        public PurchasePresenter(IPurchaseView view, PurchaseService purchaseService)
        {
            _view = view;
            _purchaseService = purchaseService;
        }

        public void PurchaseProduct()
        {
            int productId = _view.getProductId();
            int quantity = _view.getQuantity();
            PurchaseResultDto result = _purchaseService.PurchaseProduct(productId, quantity);
            if (result.Success)
            {
                _view.ShowSuccess($"{result.Message} Total cost: {result.TotalCost:C}");
            }
            else
            {
                _view.ShowMessage($"Purchase failed: {result.Message}");
            }
        }
    }
}
