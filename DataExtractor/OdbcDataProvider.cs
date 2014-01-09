using System;
using System.Data;
using System.Data.Odbc;

namespace DataExtractor
{
    public class OdbcDataProvider : IDataTableable
    {
        public System.Data.DataTable GetData(ProviderSettings ps)
        {
            OdbcConnection conn = new OdbcConnection();
            DataTable dt = new DataTable();

            try
            {
                using (conn = new OdbcConnection(ps.ConnStr))
                {
                    OdbcCommand cmd = new OdbcCommand(ps.Query, conn);
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                    conn.Open();
                    da.Fill(dt);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return dt;
        }
    }
}
