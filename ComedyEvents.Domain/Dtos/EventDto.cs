using ComedyEvents.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComedyEvents.Dto
{
    public class EventDto
    {
        public EventDto()
        {
            Gig = new List<Gig>();
        }

        [Required]
        public Guid Id { get; set; }
        [Required]
        [StringLength(20)]
        public String EnventName { get; set; }
        public DateTime EventDate { get; set; }
        public Guid VenueId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        //[ForeignKey(nameof(VenueId))]
        public virtual Venue Venue { get; set; }
        public virtual List<Gig> Gig { get; set; }

    }
}
