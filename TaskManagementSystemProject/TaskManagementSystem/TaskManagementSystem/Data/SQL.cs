using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace TaskManagementSystem.Data
{
    public class SQL
    {

        private readonly string _connectionString;

        public SQL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataSet ExecuteProcedure(string procedureName)
        {
            DataSet ds = new DataSet();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(ds);
                    }
                }
            }

            return ds;
        }

        public DataSet ExecuteProcedure(string procedureName, List<SqlParameter> parameters)
        {
            DataSet ds = new DataSet();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(ds);
                    }
                }
            }

            return ds;
        }
    }
}