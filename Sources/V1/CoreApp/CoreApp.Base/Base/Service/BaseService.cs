using CoreApp.EntityFramework;
using CoreApp.Infrastructure.Base.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Infrastructure.Base.Service
{
    public partial class BaseService<T> : IBaseService<T> where T : BaseEntity
    {

        #region Fields

        private readonly IBaseRepository<T> _rep;

        #endregion

        #region Contructor

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="rep"></param>
        public BaseService(IBaseRepository<T> rep)
        {
            this._rep = rep;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns>Result</returns>
        public virtual IList<T> GetAll()
        {
            return _rep.GetAll();
        }

        /// <summary>
        /// Get async all
        /// </summary>
        /// <returns>Result</returns>
        public virtual async Task<IList<T>> GetAllAsync()
        {
            return await _rep.GetAllAsync();
        }

        /// <summary>
        /// Get by Id
        /// </summary>
        /// <param name="id">Object</param>
        /// <returns>Result</returns>
        public virtual T GetById(object id)
        {
            return _rep.GetById(id);
        }

        /// <summary>
        /// Get async by Id 
        /// </summary>
        /// <param name="id">Object</param>
        /// <returns>Result</returns>
        public virtual async Task<T> GetByIdAsync(object id)
        {
            return await _rep.GetByIdAsync(id);
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Result</returns>
        public virtual int Insert(T entity)
        {
            return _rep.Insert(entity);
        }

        /// <summary>
        /// Insert Async
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Result</returns>
        public virtual async Task<int> InsertAsync(T entity)
        {
            return await _rep.InsertAsync(entity);
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="entities">Entities</param>
        /// <returns>Result</returns>
        public virtual int Insert(IEnumerable<T> entities)
        {
            return _rep.Insert(entities);
        }

        /// <summary>
        /// Insert Async
        /// </summary>
        /// <param name="entities">Entities</param>
        /// <returns>Result</returns>
        public virtual async Task<int> InsertAsync(IEnumerable<T> entities)
        {
            return await _rep.InsertAsync(entities);
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual int Update(T entity)
        {
            return _rep.Update(entity);
        }

        /// <summary>
        /// Update async entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual async Task<int> UpdateAsync(T entity)
        {
            return await _rep.UpdateAsync(entity);
        }

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual int Update(IEnumerable<T> entities)
        {
            return _rep.Update(entities);
        }

        /// <summary>
        /// Update async entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual async Task<int> UpdateAsync(IEnumerable<T> entities)
        {
            return await _rep.UpdateAsync(entities);
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual int Delete(T entity)
        {
            return _rep.Delete(entity);
        }

        /// <summary>
        /// Delete async entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual async Task<int> DeleteAsync(T entity)
        {
            return await _rep.DeleteAsync(entity);
        }

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual int Delete(IEnumerable<T> entities)
        {
            return _rep.Delete(entities);
        }

        /// <summary>
        /// Delete async entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual async Task<int> DeleteAsync(IEnumerable<T> entities)
        {
            return await _rep.DeleteAsync(entities);
        }

        /// <summary>
        /// Where
        /// </summary>
        /// <param name="predicate">Func</param>
        /// <returns>Result</returns>
        public virtual IList<T> Where(Func<T, bool> predicate)
        {
            return _rep.Where(predicate);
        }

        /// <summary>
        /// Excute command
        /// </summary>
        /// <param name="sqlCommand">String</param>
        /// <param name="parameters">Params objects</param>
        /// <returns>Result</returns>
        public virtual int ExcuteCommand(string sqlCommand, params object[] parameters)
        {
            return _rep.ExcuteCommand(sqlCommand, parameters);
        }

        /// <summary>
        /// Excute command async
        /// </summary>
        /// <param name="sqlCommand">String</param>
        /// <param name="parameters">Params objects</param>
        /// <returns>Result</returns>
        public virtual async Task<int> ExcuteCommandAsync(string sqlCommand, params object[] parameters)
        {
            return await _rep.ExcuteCommandAsync(sqlCommand, parameters);
        }

        /// <summary>
        /// Excute store procedure
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="name">Store procedure name</param>
        /// <param name="parameters">Store procedure input model</param>
        /// <returns>List<TResult></returns>
        public virtual IList<TResult> ExcuteStoreProcedure<TResult>(string name, params object[] parameters) where TResult : new()
        {
            return _rep.ExcuteStoreProcedure<TResult>(name, parameters);
        }

        #endregion
    }
}
