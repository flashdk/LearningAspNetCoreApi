using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComedyEvents.Dto
{
    public class GigDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string GigHeadline { get; set; }
        [Required]
        [Range(15,120)]
        public int GigLengthInMinute { get; set; }

        public Guid EventId { get; set; }
        public EventDto Event { get; set; }

        public Guid ComedianId { get; set; }
        public ComedianDto Comedian { get; set; }
    }
}




