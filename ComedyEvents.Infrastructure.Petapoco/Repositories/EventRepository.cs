using ComedyEvents.Services;
using System;
using System.Collections.Generic;
using System.Text;
using ComedyEvents.Domain;
using System.Threading.Tasks;
using System.Linq.Expressions;
using ComedyEvents.Domain.Models;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data.SqlClient;
using System.Linq;

namespace ComedyEvents.Infrastructure.Petapoco.Repositories
{
    public class EventRepository : IRepository<Event>
    {
        private readonly ICommandTest _commandTest;
        private readonly string _connectionString;
        public EventRepository(IConfiguration configuration, ICommandTest commandTest)
        {
            _commandTest = commandTest;
            _connectionString = configuration.GetConnectionString("ComedyEvent");
        }

        #region Helpers 
        private void ExecuteCommand(string connStr, Action<SqlConnection> task)
        {
            using (var conn = new SqlConnection(connStr))
            { 
                conn.Open(); 
                task(conn); 
            }
        }

        private T ExecuteCommand<T>(string connStr, Func<SqlConnection, T> task)
        { 
            using (var conn = new SqlConnection(connStr))
            { 
                conn.Open(); 
                return task(conn); 
            }
        }

        #endregion

        public Task<IEnumerable<Event>> GetAllAsync()
        {
            var query = ExecuteCommand(_connectionString, con => con.QueryAsync<Event>(_commandTest.GetEvents));

            return query;
        }

        public IEnumerable<Event> GetAll()
        {
            var query = ExecuteCommand(_connectionString, con => con.Query<Event>(_commandTest.GetEvents).ToList());

            return query;
        }

        public Task CreateAsync(Event entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Event entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }



        public Task<Event> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Event>> GetWhereAsync(Expression<Func<Event, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Event entity)
        {
            throw new NotImplementedException();
        }
    }
}
