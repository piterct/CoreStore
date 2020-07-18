using CoreStore.Domain.StoredContext.Commands.CustomerComands.Inputs;
using CoreStore.Domain.StoredContext.Entities;
using CoreStore.Domain.StoredContext.Queries;
using CoreStore.Domain.StoredContext.Repositories;
using CoreStore.Infra.StoredContext.DataContexts;
using CoreStore.Shared;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CoreStore.Infra.StoredContext.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CoreDataContext _context;
        private readonly IOptions<Settings> _config;

        public CustomerRepository(CoreDataContext context, IOptions<Settings> config)

        {
            _context = context;
            _config = config;
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

        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _context
                .Connection
                .Query<ListCustomerQueryResult>(
                    "SELECT[Id], CONCAT([FirstName], ' ', [Lastname]) AS [Name], [Document], [Email] FROM Customer");
        }

        public GetCustomerQueryResult Get(Guid Id)
        {
            return _context
                .Connection
                .Query<GetCustomerQueryResult>(
                    "SELECT[Id], CONCAT([FirstName], ' ', [Lastname]) AS [Name], [Document], [Email] FROM Customer WHERE [Id] = @Id ",
                    new { Id = Id }).FirstOrDefault();
        }

        public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
        {
            return _context
                .Connection
                .Query<CustomerOrdersCountResult>(
                    "spGetCustomerOrdersCount",
                    new { Document = document },
                    commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid Id)
        {
            return _context
               .Connection
               .Query<ListCustomerOrdersQueryResult>("", new { id = Id });
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

        public int AddListCustomersInBulk(ListCreateCustomersCommand customers)
        {
            var sqls = GetCustomerSqlsInBatches(customers.Customers);
            var resultExecute = 0;

            using (var connection = new SqlConnection(_config.Value.ConnectionString))
            {
                foreach (var sql in sqls)
                {
                    resultExecute = connection.ExecuteAsync(sql).Result;
                }
            }

            return resultExecute;
        }

        private IList<string> GetCustomerSqlsInBatches(IList<CreateCustomerCommand> customers)
        {
            var insertSql = "INSERT INTO [Customer] (Id, FirstName, LastName, Document, Email, Phone) VALUES ";
            var valuesSql = "('{0}', '{1}', '{2}' , '{3}', '{4}', '{5}')";
            var batchSize = 1000;

            var sqlsToExecute = new List<string>();
            var numberOfBatches = (int)Math.Ceiling((double)customers.Count / batchSize);


            for (int i = 0; i <= numberOfBatches; i++)
            {
                var valuesToInsert = string.Format(valuesSql, customers[i].Id, customers[i].FirstName, customers[i].LastName, customers[i].Document, customers[i].Email, customers[i].Phone);
                sqlsToExecute.Add(string.Concat(insertSql, valuesToInsert));
            }

            return sqlsToExecute;
        }
    }
}
