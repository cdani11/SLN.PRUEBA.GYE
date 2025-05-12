using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM.PRUEBA.QUERY.SERVICE.Model
{
    public class PruebaQueryContextDP
    {
        private readonly string connectionString;

        public PruebaQueryContextDP(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(connectionString);
    }
}
