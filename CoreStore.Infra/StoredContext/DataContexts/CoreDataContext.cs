using CoreStore.Shared;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CoreStore.Infra.StoredContext.DataContexts
{
    public class CoreDataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public CoreDataContext()
        {
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}
