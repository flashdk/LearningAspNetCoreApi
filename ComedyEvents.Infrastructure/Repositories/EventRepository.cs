using ComedyEvents.Domain.Models;
using ComedyEvents.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Data;

namespace ComedyEvents.Infrastructure.Repositories
{
    public class EventRepository : Repository<Event>, IRepository<Event>
    {
        private DbSet<Venue> _dbSetVenue;

        //base qignifie a chaque fois que l'on appel EventRepository qu'il apelle également Repository qui represente sa base
        public EventRepository(AppDbContext context) : base(context)
        {
            _dbSetVenue = context.Set<Venue>();
        }

        public override async Task<IEnumerable<Event>> GetAllAsync()
        {
            var query = await _dbSet.FromSqlRaw<Event>($"SELECT * FROM {_tableName}").ToListAsync();

            foreach (var item in query)
            {
                var id = new SqlParameter("id", SqlDbType.UniqueIdentifier);
                id.Value = item.VenueId;
                item.Venue = (await _dbSetVenue.FromSqlRaw<Venue>("SELECT * FROM venue WHERE id = @id", id).ToListAsync()).SingleOrDefault();
            }
            return query;
        }
    }
}
