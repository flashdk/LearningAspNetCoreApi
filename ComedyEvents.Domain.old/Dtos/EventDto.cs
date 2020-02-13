using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComedyEvents.Dto
{
    public class EventDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [StringLength(20)]
        public String EnventName { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public int VenueId { get; set; }
        public VenueDto Venue { get; set; }

        public ICollection<GigDto> Gigs { get; set; }

    }
}
