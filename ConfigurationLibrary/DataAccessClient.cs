using ConfigurationLibrary.Exceptions;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationLibrary
{
    public class DataAccessClient
    {
        IConfigurationRoot Configuration { get; }
        public DataAccessClient()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .Build();
        }

        private OleDbConnection GetConnection() 
        {
            //Get the Connection String
            string? connectionString = Configuration?["ConnectionString"];
            //Initialize the connection
            if (connectionString is not null)
                return new OleDbConnection(connectionString);
            else
                throw new InvalidConnectionString();
        }

        #region Select

        public async Task<IEnumerable<T>> Query<T>(string sql)
        {
            IEnumerable<T>? Result;
            try
            {
                OleDbConnection conn = GetConnection();
                try
                {
                    //Open Connection
                    await conn.OpenAsync();
                    Result = await conn.QueryAsync<T>(sql);

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    await conn.CloseAsync().ConfigureAwait(false);
                }
                return Result;
            }
            catch (InvalidConnectionString)
            {

                throw;
            }
            //run Query
            //Close The Connection
        }
        public async Task<IEnumerable<T>> Query<T>(string sql, object parameters)
        {
            IEnumerable<T>? Result;
            try
            {
                OleDbConnection conn = GetConnection();
                try
                {
                    //Open Connection
                    await conn.OpenAsync();
                    Result = await conn.QueryAsync<T>(sql, parameters);

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    await conn.CloseAsync().ConfigureAwait(false);
                }
                return Result;
            }
            catch (InvalidConnectionString)
            {

                throw;
            }
            //run Query
            //Close The Connection
        }

        public async Task<T> ExecuteScaler<T>(string sql, object? parameters) 
        {
            T? Result;
            try
            {
                OleDbConnection conn = GetConnection();
                try
                {
                    //Open Connection
                    await conn.OpenAsync();
                    Result = await conn.ExecuteScalarAsync<T>(sql, parameters);

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    await conn.CloseAsync().ConfigureAwait(false);
                }
                return Result;
            }
            catch (InvalidConnectionString)
            {

                throw;
            }
            //run Query
            //Close The Connection
        }
        #endregion
    }
}
