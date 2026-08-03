
namespace MiniERPShop.Features.Purchasing.Views
{
    public interface IPurchaseView
    {
        int getProductId();
        int getQuantity();
        void ShowMessage(string message);
        void ShowSuccess(string message);
    }
}
