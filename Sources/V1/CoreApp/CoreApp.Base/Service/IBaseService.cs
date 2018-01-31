using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreApp.EntityFramework;

namespace CoreApp.Base.Service
{
    public interface IBaseService<T> where T : class
    {
        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities"></param>
        /// <returns>int</returns>
        int Delete(IEnumerable<T> entities);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>int</returns>
        int Delete(T entity);

        /// <summary>
        /// Delete entities async
        /// </summary>
        /// <param name="entities"></param>
        /// <returns>int</returns>
        Task<int> DeleteAsync(IEnumerable<T> entities);

        /// <summary>
        /// Delete entity async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>int</returns>
        Task<int> DeleteAsync(T entity);

        /// <summary>
        /// Excute command
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="parameters"></param>
        /// <returns>int</returns>
        int ExcuteCommand(string sqlCommand, params object[] parameters);

        /// <summary>
        /// Excute command async
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="parameters"></param>
        /// <returns>int</returns>
        Task<int> ExcuteCommandAsync(string sqlCommand, params object[] parameters);

        /// <summary>
        /// Excute procedure
        /// </summary>
        /// <typeparam name="TResult">Result object type</typeparam>
        /// <param name="name">Store procedure name</param>
        /// <param name="parameters">Store procedure input model</param>
        /// <returns>TResult</returns>
        IList<TResult> ExcuteStoreProcedure<TResult>(string name, params object[] parameters) where TResult : new();

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns>T</returns>
        IList<T> GetAll();

        /// <summary>
        /// Get all async
        /// </summary>
        /// <returns>List<T></returns>
        Task<IList<T>> GetAllAsync();

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>T</returns>
        T GetById(object id);

        /// <summary>
        /// Get by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns>T</returns>
        Task<T> GetByIdAsync(object id);

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities"></param>
        /// <returns>int</returns>
        int Insert(IEnumerable<T> entities);

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>int</returns>
        int Insert(T entity);

        /// <summary>
        /// Insert entities async
        /// </summary>
        /// <param name="entities"></param>
        /// <returns>int</returns>
        Task<int> InsertAsync(IEnumerable<T> entities);

        /// <summary>
        /// Insert entity async 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>int</returns>
        Task<int> InsertAsync(T entity);

        /// <summary>
        /// Update entities 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns>int</returns>
        int Update(IEnumerable<T> entities);

        /// <summary>
        /// Update entity 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>int</returns>
        int Update(T entity);

        /// <summary>
        /// Update entities async
        /// </summary>
        /// <param name="entities"></param>
        /// <returns>int</returns>
        Task<int> UpdateAsync(IEnumerable<T> entities);

        /// <summary>
        /// Update entity async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>int</returns>
        Task<int> UpdateAsync(T entity);

        /// <summary>
        /// Where
        /// </summary>
        /// <param name="predicate">Generic query</param>
        /// <returns>List<T></returns>
        IList<T> Where(Func<T, bool> predicate);
    }
}