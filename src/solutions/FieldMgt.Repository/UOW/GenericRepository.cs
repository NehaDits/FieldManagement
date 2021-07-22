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
        public async Task InsertAsync(TEntity entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
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
        private IDbConnection CreateConnection()
        {
            string cn = _dbContext.Database.GetDbConnection().ConnectionString;
            return new SqlConnection(cn);
        }
        
        /// <summary>
        /// Return the collection of T type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
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
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
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
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
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
