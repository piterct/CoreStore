using CoreStore.Shared;
using Microsoft.Extensions.Options;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CoreStore.Infra.StoredContext.DataContexts
{
    public class CoreDataContext : IDisposable
    {
        private readonly IOptions<Settings> _config;
        public SqlConnection Connection { get; set; }

        public CoreDataContext(IOptions<Settings> config)
        {
            _config = config;
            Connection = new SqlConnection(_config.Value.ConnectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}
