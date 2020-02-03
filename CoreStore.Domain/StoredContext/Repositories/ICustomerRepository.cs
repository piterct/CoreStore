using CoreStore.Domain.StoredContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreStore.Domain.StoredContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CustomerDcoument(string document);
        bool CheckEmail(string email);
        void Save(Customer customer);
    }
}
