using Microsoft.Data.SqlClient;
using System.Data;

namespace MinimalApiComDapper.Factory
{
    public class SqlFactory
    {
        public IDbConnection SqlConnection()
        {
            return new SqlConnection("Server=localhost,1433;Database=Estudos;User ID=sa;Password=1q2w3e4r@#$; Trusted_Connection=False; TrustServerCertificate=True;");
        }
    }
}
