using System;
using System.Data;
using System.Data.OleDb;

namespace DataExtractor
{
    public class MSAccessDataProvider : IDataTableable
    {
        public DataTable GetData(ProviderSettings ps)
        {
            OleDbConnection conn = new OleDbConnection();
            DataTable dt = new DataTable();

            try
            {
                using (conn = new OleDbConnection(ps.ConnStr))
                {
                    OleDbCommand cmd = new OleDbCommand(ps.Query, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
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
        //private string _connStr;
        //private string _command;

        //public MSAccessDataProvider(string connectionString, string commandText)
        //{
        //    this._connStr = connectionString;
        //    this._command = commandText;
        //}
    }
}
