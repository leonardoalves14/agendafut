using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace SocietyAgendor.API.Base
{
    public abstract class Base : IDisposable
    {
        private readonly string _connectionString;

        public Base(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SocietyAgendorDb");
        }

        public void ExecuteSP(string procedureName, DynamicParameters parameters = null)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                var transacao = sqlConnection.BeginTransaction();
                try
                {
                    if (parameters == null)
                        sqlConnection.Execute(procedureName, commandType: System.Data.CommandType.StoredProcedure, transaction: transacao);
                    else
                        sqlConnection.Execute(procedureName, parameters, commandType: System.Data.CommandType.StoredProcedure, transaction: transacao);

                    transacao.Commit();
                }
                catch (Exception ex)
                {
                    transacao.Rollback();
                    throw new Exception($"**************\nROLLBACK NA TRANSAÇÃO \nException: {ex.ToString()}\n**************\n");
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        public List<T> ExecuteSP<T>(string procedureName, DynamicParameters parameters = null, IsolationLevel isolationLevel = IsolationLevel.Snapshot)
        {
            List<T> ret = new List<T>();

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                var transacao = sqlConnection.BeginTransaction();
                try
                {
                    if (parameters == null)
                        ret = sqlConnection.Query<T>(procedureName, transaction: transacao).ToList<T>();
                    else
                        ret = sqlConnection.Query<T>(procedureName,
                                                     parameters,
                                                     transaction: transacao,
                                                     commandType: System.Data.CommandType.StoredProcedure).ToList<T>();
                    transacao.Commit();
                }
                catch (Exception ex)
                {
                    transacao.Rollback();
                    throw new Exception($"**************\nROLLBACK NA TRANSAÇÃO \nException: {ex.ToString()}\n**************\n");
                }
                finally
                {
                    sqlConnection.Close();
                }
            }

            return ret;
        }

        public async Task<T> GetFirstOrDefault<T>(string storedProcedure, DynamicParameters parameters = null) where T : class, new()
        {
            T result = new T();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                if (parameters != null)
                    result = await sqlConnection.QueryFirstOrDefaultAsync<T>(storedProcedure, parameters, commandType: System.Data.CommandType.StoredProcedure);
                else
                    result = await sqlConnection.QueryFirstOrDefaultAsync<T>(storedProcedure, commandType: System.Data.CommandType.StoredProcedure);

                sqlConnection.Close();
            }

            return result;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) { }
    }
}
