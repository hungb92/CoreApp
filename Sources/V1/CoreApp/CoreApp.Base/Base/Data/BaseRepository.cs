using CoreApp.EntityFramework;
using CoreApp.EntityFramework.Models;
using CoreApp.Infrastructure.Constants;
using CoreApp.Infrastructure.Extentions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Infrastructure.Base.Data
{
    public partial class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        #region Fields

        // We do not need dispose this context because DI Container help us do that.
        private readonly CoreAppContext _context;
        private DbSet<T> _entities;

        #endregion

        #region Contructor

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="context">Object context</param>
        public BaseRepository(CoreAppContext context)
        {
            _context = context;
        }

        #endregion

        #region Utilities


        /// <summary>
        /// Get full error
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <returns>Error</returns>
        protected string GetFullErrorText(Exception ex)
        {
            //var msg = string.Empty;
            //foreach (var validationErrors in exc.EntityValidationErrors)
            //    foreach (var error in validationErrors.ValidationErrors)
            //        msg += $"Property: {error.PropertyName} Error: {error.ErrorMessage}" + Environment.NewLine;
            //return msg;
            return ex.Message;
        }

        /// <summary>
        /// Rollback of entity changes and return full error message
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <returns>Error</returns>
        protected string GetFullErrorTextAndRollbackEntityChanges(Exception ex)
        {
            var fullErrorText = GetFullErrorText(ex);
            var entities = _context.ChangeTracker.Entries();
            foreach (var entry in entities)
            {
                if (entry == null)
                    continue;

                //rollback of entity changes
                entry.State = EntityState.Unchanged;
            }

            _context.SaveChanges();
            return fullErrorText;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns>Result</returns>
        public virtual IList<T> GetAll()
        {
            return Entities.ToList();
        }

        /// <summary>
        /// Get async all
        /// </summary>
        /// <returns>Result</returns>
        public virtual async Task<IList<T>> GetAllAsync()
        {
            return await Entities.ToListAsync();
        }

        /// <summary>
        /// Get by Id
        /// </summary>
        /// <param name="id">Object</param>
        /// <returns>Result</returns>
        public virtual T GetById(object id)
        {
            return Entities.Find(id);
        }

        /// <summary>
        /// Get async by Id 
        /// </summary>
        /// <param name="id">Object</param>
        /// <returns>Result</returns>
        public virtual async Task<T> GetByIdAsync(object id)
        {
            return await Entities.FindAsync(id);
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Result</returns>
        public virtual int Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                Entities.Add(entity);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(ex), ex);
            }
        }

        /// <summary>
        /// Insert Async
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Result</returns>
        public virtual async Task<int> InsertAsync(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                Entities.Add(entity);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(ex), ex);
            }
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="entities">Entities</param>
        /// <returns>Result</returns>
        public virtual int Insert(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                foreach (var entity in entities)
                    Entities.Add(entity);

                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(ex), ex);
            }
        }

        /// <summary>
        /// Insert Async
        /// </summary>
        /// <param name="entities">Entities</param>
        /// <returns>Result</returns>
        public virtual async Task<int> InsertAsync(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                foreach (var entity in entities)
                    Entities.Add(entity);

                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(ex), ex);
            }
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual int Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                Entities.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(ex), ex);
            }
        }

        /// <summary>
        /// Update async entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual async Task<int> UpdateAsync(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                Entities.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(ex), ex);
            }
        }

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual int Update(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));
                foreach (var entity in entities)
                {
                    Entities.Attach(entity);
                    _context.Entry(entity).State = EntityState.Modified;
                }
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(ex), ex);
            }
        }

        /// <summary>
        /// Update async entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual async Task<int> UpdateAsync(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));
                foreach (var entity in entities)
                {
                    Entities.Attach(entity);
                    _context.Entry(entity).State = EntityState.Modified;
                }
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(ex), ex);
            }
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual int Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                Entities.Remove(entity);

                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(ex), ex);
            }
        }

        /// <summary>
        /// Delete async entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual async Task<int> DeleteAsync(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                Entities.Remove(entity);

                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(ex), ex);
            }
        }

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual int Delete(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                foreach (var entity in entities)
                    Entities.Remove(entity);

                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(ex), ex);
            }
        }

        /// <summary>
        /// Delete async entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual async Task<int> DeleteAsync(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                foreach (var entity in entities)
                    Entities.Remove(entity);

                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(ex), ex);
            }
        }

        /// <summary>
        /// Where
        /// </summary>
        /// <param name="predicate">Func</param>
        /// <returns>Result</returns>
        public virtual IList<T> Where(Func<T, bool> predicate)
        {
            return Entities.Where(predicate).ToList();
        }

        /// <summary>
        /// Excute command
        /// </summary>
        /// <param name="sqlCommand">String</param>
        /// <param name="parameters">Params objects</param>
        /// <returns>Result</returns>
        public virtual int ExcuteCommand(string sqlCommand, params object[] parameters)
        {
            try
            {
                return _context.Database.ExecuteSqlCommand(sqlCommand, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(ex), ex);
            }
        }

        /// <summary>
        /// Excute command async
        /// </summary>
        /// <param name="sqlCommand">String</param>
        /// <param name="parameters">Params objects</param>
        /// <returns>Result</returns>
        public virtual async Task<int> ExcuteCommandAsync(string sqlCommand, params object[] parameters)
        {
            try
            {
                return await _context.Database.ExecuteSqlCommandAsync(sqlCommand, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(ex), ex);
            }
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
            var cmd = _context.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = name;
            cmd.CommandType = CommandType.StoredProcedure;
            if (parameters.Any())
            {
                cmd.Parameters.AddRange(parameters);
            }
            List<TResult> result;
            using (var reader = cmd.ExecuteReader())
            {
                result = reader.MapToList<TResult>().ToList();
            }
            return result;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Table
        /// </summary>
        public virtual IQueryable<T> Table
        {
            get
            {
                return Entities;
            }
        }

        /// <summary>
        /// Table as no tracking
        /// </summary>
        public virtual IQueryable<T> TableNoTracking
        {
            get
            {
                return Entities.AsNoTracking();
            }
        }

        /// <summary>
        /// Entities
        /// </summary>
        public virtual DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    return _entities = _context.Set<T>();
                return _entities;

            }
        }

        #endregion
    }
}
