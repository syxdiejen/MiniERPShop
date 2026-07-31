public interface ISalesView
{
    int AskProductId();

    int AskQuantity();

    void ShowSuccess(string message);

    void ShowError(string message);
}