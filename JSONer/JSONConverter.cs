using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONer
{
    public class JSONConverter : IConvertableToJSON
    {
        public StringBuilder ConvertValuesInDataTableToJSON(DataTable dt, bool lcasepropnames, bool proptynamesinquotes)
        {
            StringBuilder main = new StringBuilder("[");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Dictionary<string, string> values = new Dictionary<string, string>();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (dt.Rows[i][j].ToString().Trim().Length > 0)
                        values.Add(Sanitize(dt.Columns[j].ColumnName), Sanitize(dt.Rows[i][j].ToString().Trim()));
                }

                if (values.Count > 0) //rows
                {
                    StringBuilder sb = new StringBuilder("{");
                    sb.Append(Environment.NewLine);

                    int k, l = 0;

                    foreach (KeyValuePair<string, string> pair in values)
                    {
                        bool convertedToIntSuccessfully = Int32.TryParse(pair.Value, out k);
                        sb.Append("\t");
                        if(proptynamesinquotes) sb.Append("\"");
                        sb.Append(lcasepropnames ? pair.Key.ToLower() : pair.Key);
                        if(proptynamesinquotes) sb.Append("\"");
                        sb.Append(":");

                        if (convertedToIntSuccessfully)
                            sb.Append(pair.Value);
                        else
                            sb.Append("\"" + pair.Value + "\"");

                        if (l < values.Count - 1)
                            sb.Append("," + Environment.NewLine);
                        l++;
                    }

                    main.Append(sb.ToString() + Environment.NewLine + "}");
                }
                if (i < dt.Rows.Count - 1)
                    main.Append(",");
            }
            main.Append("]");
            return main;
        }

        private string Sanitize(string p)
        {
            return p.Replace("\"", "\\\"");
        }
        //catch (Exception ex)
        //{
        //    txtContent.Text = ex.Message;
        //}
        //finally
        //{
        //    if (conn.State == ConnectionState.Open)
        //        conn.Close();
        //}



    }
}
