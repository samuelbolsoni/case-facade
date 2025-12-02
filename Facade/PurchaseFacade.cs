using CaseFacade.Facade.Interfaces;
using CaseFacade.Models;
using CaseFacade.Services;

namespace CaseFacade.Facade
{
    public class PurchaseFacade : IPurchaseFacade
    {
        private readonly InventoryService _inventory;
        private readonly PaymentService _payment;
        private readonly ShippingService _shipping;
        private readonly OrderService _order;
        private readonly NotificationService _notification;

        public PurchaseFacade(
            InventoryService inventory,
            PaymentService payment,
            ShippingService shipping,
            OrderService order,
            NotificationService notification)
        {
            _inventory = inventory;
            _payment = payment;
            _shipping = shipping;
            _order = order;
            _notification = notification;
        }

        public Task<PurchaseResult> ProcessPurchaseAsync(PurchaseRequest request)
        {
            // 1. Verifica estoque
            if (!_inventory.HasStock(request.ProductId, request.Quantity))
                return Task.FromResult(new PurchaseResult(false, "Produto sem estoque"));

            // 2. Calcula frete
            var shipping = _shipping.CalculateShipping(request.ProductId, request.Quantity);

            // 3. Cobra pagamento
            var paid = _payment.Charge(request.ProductId, request.Quantity);
            if (!paid)
                return Task.FromResult(new PurchaseResult(false, "Falha no pagamento"));

            // 4. Cria pedido
            var orderId = _order.CreateOrder(request.ProductId, request.Quantity, shipping);

            // 5. Notifica usuário
            _notification.SendEmail(request.UserEmail, $"Pedido {orderId} criado com sucesso!");

            return Task.FromResult(new PurchaseResult(true, "Compra realizada com sucesso", orderId));
        }
    }
}