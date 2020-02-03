using CoreStore.Domain.StoredContext.Entities;
using CoreStore.Domain.StoredContext.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreStore.Tests.Fakes
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public bool CheckEmail(string email)
        {
            return false;
        }

        public bool CustomerDcoument(string document)
        {
            return false;
        }

        public void Save(Customer customer)
        {
            
        }
    }
}
