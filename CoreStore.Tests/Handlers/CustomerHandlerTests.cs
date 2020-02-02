using CoreStore.Domain.StoredContext.Commands.CustomerComands.Inputs;
using CoreStore.Domain.StoredContext.Handlers;
using CoreStore.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreStore.Tests.Handlers
{
    [TestClass]
    public class CustomerHandlerTests
    {
        [TestMethod]
        public void ShouldRegisterCustomerWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Michael";
            command.LastName = "Muniz";
            command.Document = "27728919415";
            command.Email = "michael.developer@gmail.com";
            command.Phone = "11999999999";

            Assert.AreEqual(true, command.Valid());

            var handle = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
        }

    }
}
