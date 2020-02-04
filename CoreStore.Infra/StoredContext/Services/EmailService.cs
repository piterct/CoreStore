using CoreStore.Domain.StoredContext.Entities;
using CoreStore.Domain.StoredContext.Queries;
using CoreStore.Domain.StoredContext.Repositories;
using CoreStore.Domain.StoredContext.Services;
using CoreStore.Infra.StoredContext.DataContexts;
using Dapper;
using System.Data;
using System.Linq;

namespace CoreStore.Infra.StoredContext.Services
{
    public class EmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body)
        {
            // To Do Implementar
            throw new System.NotImplementedException();
        }
    }
}
