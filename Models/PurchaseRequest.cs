namespace CaseFacade.Models
{
    public record PurchaseRequest(string ProductId, int Quantity, string UserEmail);
}