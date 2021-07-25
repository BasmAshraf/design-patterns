using Payment_processing.Business.Exceptions;
using Payment_processing.Business.Models;
using System;

namespace Payment_processing.Business.Handlers.PaymentHandlers
{
    public abstract class PaymentHandler : IHandler<Order>
    {
        private IHandler<Order> Next { get; set; }

        public virtual void Handle(Order order)
        {
            if (order.AmountDue > 0)
            {
                Next.Handle(order);
            }
            else
            {
                order.ShippingStatus = ShippingStatus.ReadyForShippment;
            }
        }

        public IHandler<Order> SetNext(IHandler<Order> next)
        {
            Next = next;

            return Next;
        }
    }
}
