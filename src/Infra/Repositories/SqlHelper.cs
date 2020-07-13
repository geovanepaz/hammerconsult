using Dapper;
using Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class SqlHelper : ISqlHelper
    {
        private readonly IDbConnection _connection;

        public SqlHelper(IConfiguration configuration) => _connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

        public int Exec(string storedProcedure, object param)
        {
            var retorno = _connection.Query<int>(storedProcedure, param, commandType: CommandType.StoredProcedure).First();
            return retorno;
        }

        IEnumerable<T> ISqlHelper.Exec<T>(string storedProcedure, object param)
        {
            var retorno = _connection.Query<T>(storedProcedure, param, commandType: CommandType.StoredProcedure);
            return retorno;
        }

        IEnumerable<T> ISqlHelper.Func<T>(string userFunction, object param)
        {
            var parametros = string.Join(",", param.GetType().GetProperties().Select(x => x.GetValue(param, null)).ToArray());
            var query = string.Concat("SELECT * FROM ", userFunction, "(", parametros, ")");
            var retorno = _connection.Query<T>(query, param);
            return retorno;
        }

        IEnumerable<T> ISqlHelper.Query<T>(string query, object param)
        {
            var retorno = _connection.Query<T>(query, param);
            return retorno;
        }

        async Task<IEnumerable<T>> ISqlHelper.QueryAsync<T>(string query)
        {
            var retorno = await _connection.QueryAsync<T>(query);
            return retorno;

        }

        async Task<T> ISqlHelper.QuerySingleAsync<T>(string query, object param)
        {
            var retorno = await _connection.QueryFirstOrDefaultAsync<T>(query, param);
            return retorno;
        }

        int ISqlHelper.Insert(string query, object param)
        {
            var retorno = _connection.Execute(query, param);
            return retorno;
        }

        IEnumerable<TReturn> ISqlHelper.Query<TFirst, TSecond, TReturn>(string query, Func<TFirst, TSecond, TReturn> map, string splitOn, object param)
        {
            var retorno = _connection.Query(query, map, param, splitOn: splitOn);
            return retorno;
        }

        IEnumerable<TReturn> ISqlHelper.Query<TFirst, TSecond, TReturn>(string query, Func<TFirst, TSecond, TReturn> map, object param)
        {
            var retorno = _connection.Query(query, map, param);
            return retorno;
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}
