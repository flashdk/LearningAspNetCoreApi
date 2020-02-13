using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComedyEvents.Domain.Models
{
    public partial class Event
    {
        [StringLength(60)]
        public string EnventName { get; set; }
        public DateTime EventDate { get; set; }
        public Guid VenueId { get; set; }
        public virtual Venue Venue { get; set; }
    }
}
