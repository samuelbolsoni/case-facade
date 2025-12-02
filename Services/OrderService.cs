namespace CaseFacade.Services
{
    public class OrderService
    {
        public Guid CreateOrder(string productId, int qty, decimal shipping)
        {
            return Guid.NewGuid();
        }
    }
}