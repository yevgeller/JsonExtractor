using System;
using System.Data;
using System.Data.SqlClient;

namespace DataExtractor
{
    public class SqlDataProvider : IDataTableable
    {
        public System.Data.DataTable GetData(ProviderSettings ps)
        {
            SqlConnection conn = new SqlConnection();
            DataTable dt = new DataTable();

            try
            {
                using (conn = new SqlConnection(ps.ConnStr))
                {
                    SqlCommand cmd = new SqlCommand(ps.Query, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
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
