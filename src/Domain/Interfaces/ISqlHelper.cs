using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISqlHelper : IDisposable
    {
        int Exec(string storedProcedure, object param = null);
        IEnumerable<T> Exec<T>(string storedProcedure, object param = null) where T : class;
        IEnumerable<T> Func<T>(string userFunction, object param) where T : class;
        IEnumerable<T> Query<T>(string query, object param = null) where T : class;
        Task<IEnumerable<T>> QueryAsync<T>(string query) where T : class;
        IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(string query, Func<TFirst, TSecond, TReturn> map, string splitOn, object param = null);
        IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(string query, Func<TFirst, TSecond, TReturn> map, object param);
        Task<T> QuerySingleAsync<T>(string query, object param = null);
        int Insert(string query, object param);
    }
}
