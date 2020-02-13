using ComedyEvents.Domain.Models;
using ComedyEvents.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ComedyEvents.Infrastructure.Repositories
{

    public class Repository<T> : IRepository<T> where T : EntityBase

    {
        protected readonly AppDbContext _context;
        protected DbSet<T> _dbSet;
        protected string _tableName;
        protected string _primaryKey;
       
        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();

            var entityType = _context.Model.FindEntityType(typeof(T));
            _tableName = entityType.GetTableName();
            _primaryKey = entityType.FindPrimaryKey().GetName();
        }

        public async Task CreateAsync(T entity)
        {
            _dbSet.Add(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);

            _dbSet.Remove(entity);

            await _context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {            
            var query = await _dbSet.FromSqlRaw<T>($"SELECT * FROM dbo.[{_tableName}]").ToListAsync();

            return query;
            //return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public async Task DeleteAsync(Guid Id)
        {
            var entity = await GetAsync(Id);
            await DeleteAsync(entity);
        }
        public async Task<T> GetAsync(Guid Id)
        {
            var id = new SqlParameter("id", Id);
            var query = await _dbSet.FromSqlRaw<T>($"SELECT * FROM {_tableName} WHERE {_primaryKey} = @id ", id).ToListAsync();

            return query.SingleOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<T> Identification(string username, string password)
        {
            var UserName = new SqlParameter("UserName", username);
            var Pwd = new SqlParameter("Pwd", password);

            var query = await _dbSet.FromSqlRaw<T>($"SELECT * FROM dbo.[{_tableName}] WHERE UserName = @UserName AND Pwd = @Pwd", UserName, Pwd).ToListAsync();

            return query.SingleOrDefault();
        }

    }
}
