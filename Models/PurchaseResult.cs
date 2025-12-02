namespace CaseFacade.Models
{
    public record PurchaseResult(bool Success, string Message, Guid? OrderId = null);
}