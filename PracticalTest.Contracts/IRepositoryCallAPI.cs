using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Contracts
{
    public interface IRepositoryCallAPI
    {
        Task<IEnumerable<T>> GetAll<T>(string url);
        Task<T> Get<T>(string url);
        Task<TResponse> Create<TResponse, TRequest>(string url, TRequest entity);
        Task<TResponse> Update<TResponse, TRequest>(string url, int id, TRequest entity);
        Task Delete(string url, int id);
    }
}
