using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp8
{
    public interface IDbproviderFactoryWrapper
    {
        DbConnection CreateConnection();
        string ConnectionString { get; set; }
    }
}
