using CoreStore.Domain.StoredContext.Entities;
using CoreStore.Domain.StoredContext.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreStore.Domain.StoredContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void Save(Customer customer);
        CustomerOrdersCountResult GetCustomerOrdersCount(string document);
    }
}
