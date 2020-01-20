using CoreStore.Domain.StoredContext.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var c = new Customer("Michael",
                "Muniz",
                "12345678911",
                "hello@michael.com",
                "123456789",
                "Rua dos Developers, 305" );


        }
    }
}
