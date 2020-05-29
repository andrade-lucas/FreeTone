using System.Data;
using System.Data.SqlClient;

namespace Tone.Infra.Context
{
    public class MsSqlDB : IDB
    {
        private SqlConnection DB;

        public IDbConnection Connection()
        {
            DB = new SqlConnection(Settings.ConnectionString);
            return this.DB;
        }

        public void Dispose()
        {
            if (DB.State != ConnectionState.Closed)
                DB.Close();
        }
    }
}