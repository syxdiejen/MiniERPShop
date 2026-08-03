namespace MiniERPShop.Features.Purchasing.Views
{
    public class ConsolePurchaseView : IPurchaseView
    {
        public int getProductId()
        {
            Console.Write("Enter product ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                return id;
            }

            return -1;
        }

        public int getQuantity()
        {
            Console.Write("Enter quantity: ");
            if (int.TryParse(Console.ReadLine(), out int quantity))
            {
                return quantity;
            }

            return -1;
        }

        public void ShowMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void ShowSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
