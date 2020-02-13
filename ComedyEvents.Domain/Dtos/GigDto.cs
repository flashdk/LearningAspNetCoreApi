using ComedyEvents.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ComedyEvents.Dto
{
    public class GigDto
    {
        public Guid Id { get; set; }

        [StringLength(60)]
        public string GigHeadline { get; set; }
        public int GigLengthInMinute { get; set; }
        public Guid EventId { get; set; }
        public Guid ComedianId { get; set; }
        public virtual Comedian Comedian { get; set; }
        public virtual Event Event { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}




