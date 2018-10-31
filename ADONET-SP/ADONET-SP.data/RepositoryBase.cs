using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ADONET_SP.data
{
    public abstract class RepositoryBase
    {
        protected string CallStoredProcedure(string proc, List<SqlParameter> parameters)
        {
            using (var conn = Connect())
            using (var cmd = CreateCommand(proc, conn))
            {

                //create data adapter, init parameters
                var adapter = CreateAdapter(cmd, CommandType.StoredProcedure, parameters);

                //fill datatable
                var dt = new DataTable();
                adapter.Fill(dt);

                //expected result is a single JSON string in the only row/column returned
                if (dt.Rows.Count > 0)
                    return dt.Rows[0][0].ToString();
                else
                    throw new Exception("Unexpected response from database");
            }
        }

        private SqlDataAdapter CreateAdapter(SqlCommand command, CommandType type, List<SqlParameter> parameters = null)
        {
            var adapter = new SqlDataAdapter(command);
            adapter.SelectCommand.CommandType = type;
            if (parameters != null)
                adapter.SelectCommand.Parameters.AddRange(parameters.ToArray());

            return adapter;
        }

        private SqlCommand CreateCommand(string commandTxt, SqlConnection conn)
        {
            return new SqlCommand(commandTxt, conn);
        }

        private SqlConnection Connect()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["Log150"].ConnectionString);
        }
    }
}
