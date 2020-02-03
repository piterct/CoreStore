using CoreStore.Domain.StoredContext.Commands.CustomerComands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreStore.Tests.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Michael";
            command.LastName = "Muniz";
            command.Document = "27728919415";
            command.Email = "michael.developer@gmail.com";
            command.Phone = "11999999999";

            Assert.AreEqual(true, command.Valid());
        }
    }
}
