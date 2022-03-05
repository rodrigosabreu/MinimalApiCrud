using System.Data;
using Microsoft.Data.SqlClient;

namespace MinimalApiCrud.Factory
{
    public class SqlFactory
    {
        public IDbConnection SqlConnection()
        {
            return new SqlConnection("Server=localhost; Database=CarDataBase; User=sa; Password=010203; Trusted_Connection=False; TrustServerCertificate=True;");
        }
    }
}
