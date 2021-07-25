using Payment_processing.Business.Models;
using Payment_processing.Business.PaymentProcessors;
using System.Linq;

namespace Payment_processing.Business.Handlers.PaymentHandlers
{
    public class PaypalHandler : PaymentHandler
    {
        private IPaymentProcessor paymentProcessor = new PaypalPaymentProcessor();
        public override void Handle(Order order)
        {
            if (order.SelectedPayments.Any(x => x.PaymentProvider == PaymentProvider.Paypal))
                paymentProcessor.Finalize(order);
            base.Handle(order);
        }
    }
}
