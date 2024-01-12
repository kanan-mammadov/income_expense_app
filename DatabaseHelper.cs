using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgrarKreditApp
{
    class DatabaseHelper
    {
        // Replace these values with your actual database information
        private static readonly string Username = "agrokredit";
        private static readonly string Password = "agro";
        private static readonly string DataSource = "SMART";

        public static string ConnectionString
        {
            get
            {
                return $"User Id={Username};Password={Password};Data Source={DataSource}";
            }
        }

        public static OracleConnection GetOpenConnection()
        {
            try
            {
                OracleConnection connection = new OracleConnection(ConnectionString);
                connection.Open();
                return connection;
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}
