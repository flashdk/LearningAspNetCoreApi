using ComedyEvents.Domain.Models;
using ComedyEvents.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Linq;

namespace ComedyEvents.Infrastructure.Repositories
{
    public class GigRepository : Repository<Gig>, IRepository<Gig>
    {
        private DbSet<Event> _dbSetEvent;
        private DbSet<Comedian> _dbSetComedian;

        //base qignifie a chaque fois que l'on appel EventRepository qu'il apelle également Repository qui represente sa base
        public GigRepository(AppDbContext context) : base(context)
        {
            _dbSetEvent = context.Set<Event>();
            _dbSetComedian = context.Set<Comedian>();
        }

        public override async Task<IEnumerable<Gig>> GetAllAsync()
        {
            var query = await _dbSet.FromSqlRaw<Gig>($"SELECT * FROM {_tableName}").ToListAsync();

            foreach (var item in query)
            {
                var id = new SqlParameter("id", SqlDbType.UniqueIdentifier);
                id.Value = item.ComedianId;
                item.Comedian = (await _dbSetComedian.FromSqlRaw<Comedian>("SELECT * FROM Comedian WHERE id = @id", id).ToListAsync()).SingleOrDefault();
                
                id.Value = item.EventId;
                item.Event = (await _dbSetEvent.FromSqlRaw<Event>("SELECT * FROM Event WHERE id = @id", id).ToListAsync()).SingleOrDefault();
            }
            return query;
        }

    }
}
