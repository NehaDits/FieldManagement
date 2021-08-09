using System.Collections.Generic;
using FieldMgt.Core.DomainModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using FieldMgt.Core.UOW;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Threading;
using System;

namespace FieldMgt.Repository.UOW
{
    public class GenericRepository<TEntity> where TEntity:class
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }
        /// <summary>
        /// Deletes an Entity 
        /// </summary>
        /// <typeparamname="obj"></typeparam>
        /// <paramname="Object"></param>
        /// <returns></returns>
        public void Delete(object obj)
        {
            try
            {
                TEntity entityToDelete = _dbSet.Find(obj);
                _dbContext.Entry(obj).State = EntityState.Deleted;
                _dbSet.Remove(entityToDelete);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        /// <summary>
        /// Get all records
        /// </summary>
        /// <paramname=""></param>
        /// <returns>TEntity</returns>
        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return _dbSet.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        /// <summary>
        /// Get all records by a primary key field
        /// </summary>
        /// <typeparamname="Object"></typeparam>
        /// <paramname="id"></param>
        /// <returns>TEntity</returns>
        public TEntity GetById(object id)
        {
            try
            {
                return _dbSet.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        /// <summary>
        /// Inserts a record
        /// </summary>
        /// <typeparamname="TEntity"></typeparam>
        /// <paramname="entity"></param>
        /// <returns>Task</returns>
        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            try
            {
                var entity1= await _dbSet.AddAsync(entity);
                var entityToReturn = entity1.Entity;
                return entityToReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        /// <summary>
        /// Updates a record
        /// </summary>
        /// <typeparamname="TEntity"></typeparam>
        /// <paramname="entity"></param>
        /// <returns>TEntity</returns>
        public TEntity Update(TEntity entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        /// <summary>
        /// Generates a connection string
        /// </summary>
        /// <typeparamname=""></typeparam>
        /// <paramname=""></param>
        /// <returns></returns>
        private IDbConnection CreateConnection()
        {
            string cn = _dbContext.Database.GetDbConnection().ConnectionString;
            return new SqlConnection(cn);
        }        
        /// <summary>
        /// Return the collection of T type
        /// </summary>
        /// <typeparamname="T"></typeparam>
        /// <paramname="sql"></param>
        /// <paramname="parameters"></param>
        /// <returns></returns>
        protected async Task<IEnumerable<T>> CollectionsAsync<T>(string sql, object parameters = null)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var QueryResponse = await connection.QueryAsync<T>(sql: sql, param: parameters, commandType: CommandType.StoredProcedure);

                    return QueryResponse;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Return the single row
        /// </summary>
        /// <typeparamname="T"></typeparam>
        /// <paramname="sql"></param>
        /// <paramname="parameters"></param>
        /// <returns></returns>
        protected async Task<T> SingleAsync<T>(string sql, object parameters = null)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    return await connection.QuerySingleAsync<T>(new CommandDefinition(commandText: sql, parameters: parameters, commandType: CommandType.StoredProcedure));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        /// <summary>
        /// Used to perform insert, update, delete
        /// </summary>
        /// <typeparamname="T"></typeparam>
        /// <paramname="sql"></param>
        /// <paramname="parameters"></param>
        /// <returns></returns>
        protected async Task<T> CommandAsync<T>(string sql, object parameters = null)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var QueryResponse = await connection.QuerySingleAsync<T>(sql: sql, param: parameters, commandType: CommandType.StoredProcedure);
                    return QueryResponse;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
