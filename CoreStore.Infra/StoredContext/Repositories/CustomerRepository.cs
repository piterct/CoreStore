﻿using CoreStore.Domain.StoredContext.Entities;
using CoreStore.Domain.StoredContext.Repositories;
using CoreStore.Infra.StoredContext.DataContexts;
using Dapper;
using System.Data;
using System.Linq;

namespace CoreStore.Infra.StoredContext.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CoreDataContext _context;

        public CustomerRepository(CoreDataContext context)

        {
            _context = context;
        }
        public bool CheckDocument(string document)
        {
            return
                _context
                .Connection
                .Query<bool>(
                    "spCheckDocument",
                    new { Document = document },
                    commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public bool CheckEmail(string email)
        {
            return _context
                .Connection
                .Query<bool>(
                    "spCheckEmail",
                    new { Email = email },
                    commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public void Save(Customer customer)
        {
            _context.Connection.Execute("spCreateCustomer",
           new
           {
               Id = customer.Id,
               FirstName = customer.Name.FirstName,
               LastName = customer.Name.LastName,
               Document = customer.Document.Number,
               Email = customer.Email.Address,
               Phone = customer.Phone
           }, commandType: CommandType.StoredProcedure);

            foreach (var address in customer.Addresses)
            {
                _context.Connection.Execute("spCreateAddress",
                new
                {
                    Id = address.Id,
                    CustomerId = customer.Id,
                    Number = address.Number,
                    Complement = address.Complement,
                    District = address.District,
                    City = address.City,
                    State = address.State,
                    Country = address.Country,
                    ZipCode = address.ZipCode,
                    Type = address.Type,
                }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
