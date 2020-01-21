using CoreStore.Domain.StoredContext.Enums;
using System;

namespace CoreStore.Domain.StoredContext.Entities
{
    public class Delivery
    {
        public Delivery(DateTime estimatedDeliveryDate)
        {
            CreateDate = DateTime.Now;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }
        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }

        public void Ship()
        {
            // Se a Data estimada de entrega for no passado não entregar
            Status = EDeliveryStatus.Shpped;
        }


        public void Cancel()
        {
            // Se a o status já estiver entregue nao deve cancelar.
            Status = EDeliveryStatus.Canceled;
        }
    }
}
