using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp8
{
    public class MySqlClient : IDbproviderFactoryWrapper
    {
        private readonly DbProviderFactory _factory;

        public MySqlClient()
        {
            _factory = DbProviderFactories.GetFactory("MySql.Data");
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
