using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net3.Services.Channel.Services.Services
{
    public static class SqlExecutor
    {
        public static async Task<DataSet> ExecuteQueryAsync(SqlConnection conn, List<SqlParameter> sqlParam, string sproc)
        {
            try
            {
                await conn.OpenAsync();
                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sproc;
                if (sqlParam != null)
                {
                    foreach (SqlParameter p in sqlParam)
                    {
                        cmd.Parameters.Add(p);
                    }
                }

                DataSet dataSet = new DataSet();
                using SqlDataAdapter da = new(cmd);

                await Task.Run(() => da.Fill(dataSet));

                return dataSet;
            }
            catch (Exception)
            {

                throw;
            } finally { conn.Close(); }

        }

        public static async Task<int> ExecuteNonQueryAsync(SqlConnection conn, List<SqlParameter> sqlParam, string sproc)
        {
            try
            {
                await conn.OpenAsync();
                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sproc;
                if (sqlParam != null)
                {
                    foreach (SqlParameter p in sqlParam)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
                return await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception)
            {

                throw;
            } finally { conn.Close(); }
        }
    }
}
