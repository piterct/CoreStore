using CoreStore.Domain.StoredContext.Entities;
using CoreStore.Domain.StoredContext.Enums;
using CoreStore.Domain.StoredContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreStore.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {
        private Product _mouse;
        private Product _keyboard;
        private Product _chair;
        private Product _monitor;
        private Customer _customer;
        private Order _order;
        public OrderTests()
        {
            var name = new Name("Michael", "Muniz");
            var document = new Document("3221077076");
            var email = new Email("michael.developer@gmail.com");
            _customer = new Customer(name, document, email, "4521020312");
            _order = new Order(_customer);
            _mouse = new Product("Mouse Gamer", "Mouse Gamer", "mouse.jpg", 100M, 10);
            _keyboard = new Product("Teclado Gamer", "Teclado Gamer", "teclado.jpg", 100M, 10);
            _chair = new Product("Cadeira Gamer", "Cadeira Gamer", "cadeira.jpg", 100M, 10);
            _monitor = new Product("Monitor Gamer", "Monitor Game", "monitor.jpg", 100M, 10);
        }
        // Consigo criar um novo pedido
        [TestMethod]
        public void ShouldCreateOrderWhenValid()
        {
            Assert.AreEqual(true, _order.IsValid);
        }

        // Ao criar o pedido, o status deve ser created
        [TestMethod]
        public void StatusShouldBeCreatedWhenOrderCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        // Ao adcionar um novo item, a quantidade de itens deve mudar
        [TestMethod]
        public void ShouldReturnTwoWhenAddedValidTwoItems()
        {
            _order.AddItem(_monitor, 5);
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(2, _order.Items.Count);
        }

        // Ao adicionar um novo item, deve subtrair a quantidadde do produto
        [TestMethod]
        public void ShouldReturnFiveWhenAddedPurchasedFiveItems()
        {
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(_mouse.QuantityOnHand, 5);
        }

        // Ao confirmar o pedido deve gerar um número
        [TestMethod]
        public void ShouldReturnANumberOrderPlaced()
        {
            _order.Place();
            Assert.AreNotEqual("", _order.Number);
        }

        // Ao pagar o pedido o status deve ser pago
        [TestMethod]
        public void ShouldReturnPaidWhenOrderPaid()
        {
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }
        // Dados  mais 10 produtos, devem haver duas entregas
        [TestMethod]
        public void ShouldTwoWhenPurchaseTenProducts()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.Ship();

            Assert.AreEqual(2, _order.Deliveries.Count);
        }

        // Ao cancelar o  pedido, o status deve ser cancelado
        [TestMethod]
        public void StatusShoulBeCanceledWhenOrderCanceled()
        {
            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        // Ao cancelar o pedido, deve cancelar as entregas
        [TestMethod]
        public void ShouldCancelShippingsWhenOrderCanceled()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.Ship();

            _order.Cancel();
            foreach (var x in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, x.Status);
            }

        }
    }
}
