using CoreStore.Domain.StoredContext.Entities;
using CoreStore.Domain.StoredContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            var name = new Name("Michael ", "Muniz");
            var document = new Document("12345678911");
            var email = new Email("Developer@dev.com.br");
            var c = new Customer(name, document, email, "12345678911");
            var mouse = new Product("Mouse", "Rato", "image.png", 50.63M, 10);
            var teclado = new Product("Teclado", "teclado", "image.png", 150.63M, 10);
            var impressora = new Product("Impressora", "Impressora", "image.png", 50.63M, 10);
            var cadeira = new Product("Cadeira", "Cadeira", "image.png", 50.63M, 10);
            var order = new Order(c);
            order.AddItem(new OrderItem(mouse, 5));
            order.AddItem(new OrderItem(teclado, 5));
            order.AddItem(new OrderItem(impressora, 5));
            order.AddItem(new OrderItem(cadeira, 5));

            // Realizei o pedido
            order.Place();

            // simular o pagamento
            order.Pay();

            // simular o envio
            order.Ship();

            // simular o cancelamento

            order.Cancel();


        }
    }
}
