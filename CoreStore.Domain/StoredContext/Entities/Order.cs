using CoreStore.Domain.StoredContext.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreStore.Domain.StoredContext.Entities
{
    public class Order
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;
        public Order(Customer customer)
        {
            Customer = Customer;
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();
        public object Guild { get; }


        public void AddItem(OrderItem item)
        {
            _items.Add(item);
        }


        // Criar um pedido
        public void Place()
        {
            // Gera o número do pedido
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
        }

        public void Pay()
        {
            // A cada 5 Produtos é uma entrega.
            Status = EOrderStatus.Paid;

        }

        //Enviar um pedido
        public void Ship()
        {
            // A cada 5 Produtos é uma entrega
            var deliveries = new List<Delivery>();
            var count = 1;

            // Quebra as entregas
            foreach (var item in _items)
            {
                if (count == 5)
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }

                count++;

            }

            // Envia todas as entregas
            deliveries.ForEach(x => x.Ship());

            //Adiciona as entregas ao pedido
            deliveries.ForEach(x => _deliveries.Add(x));

        }

        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x => x.Cancel());
        }

        // Cancelar um pedido

    }
}
