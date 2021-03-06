﻿using CoreStore.Domain.StoredContext.Commands.CustomerComands.Inputs;
using CoreStore.Domain.StoredContext.Entities;
using CoreStore.Domain.StoredContext.Queries;
using CoreStore.Domain.StoredContext.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreStore.Tests.Fakes
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public bool CheckEmail(string email)
        {
            return false;
        }

        public bool CheckDocument(string document)
        {
            return false;
        }

        public void Save(Customer customer)
        {
            
        }

        public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ListCustomerQueryResult> Get()
        {
            throw new NotImplementedException();
        }

        public GetCustomerQueryResult Get(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid Id)
        {
            throw new NotImplementedException();
        }

        public int AddListCustomers(IList<ListCreateCustomersCommand> customers)
        {
            throw new NotImplementedException();
        }

        public int AddListCustomersInBulk(ListCreateCustomersCommand customers)
        {
            throw new NotImplementedException();
        }

        public Task<int> TaskAddListCustomersInBulk(ListCreateCustomersCommand customers)
        {
            throw new NotImplementedException();
        }
    }
}
