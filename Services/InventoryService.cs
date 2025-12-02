namespace CaseFacade.Services
{
    public class InventoryService
    {
        public bool HasStock(string productId, int qtd)
        {
            return qtd <= 5;
        }
    }
}