using CaseFacade.Models;

namespace CaseFacade.Facade.Interfaces
{
    public interface IPurchaseFacade
    {
        Task<PurchaseResult> ProcessPurchaseAsync(PurchaseRequest request);
    } 
}