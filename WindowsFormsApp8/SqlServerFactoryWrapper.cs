using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp8
{
    public class SqlServerFactoryWrapper : IDbproviderFactoryWrapper
    {
        private readonly DbProviderFactory _factory;

        public SqlServerFactoryWrapper()
        {
            _factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
        }

        public DbConnection CreateConnection()
        {
            var connection = _factory.CreateConnection();
            connection.ConnectionString = ConnectionString;
            return connection;
        }

        public string ConnectionString { get; set; }
    }
}
