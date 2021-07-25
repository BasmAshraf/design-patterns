﻿using Payment_processing.Business.Models;
using Payment_processing.Business.PaymentProcessors;
using System.Linq;

namespace Payment_processing.Business.Handlers.PaymentHandlers
{
    public class CreditCardHandler : PaymentHandler
    {
        private IPaymentProcessor paymentProcessor = new CreditCardPaymentProcessor();
        public override void Handle(Order order)
        {
            if (order.SelectedPayments.Any(x => x.PaymentProvider == PaymentProvider.CreditCard))
                paymentProcessor.Finalize(order);
            base.Handle(order);
        }
    }
}
