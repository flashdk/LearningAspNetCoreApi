using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComedyEvents.Domain.Models
{
    public partial class Gig
    {
        [Required]
        [StringLength(60)]
        public string GigHeadline { get; set; }
        public int GigLengthInMinute { get; set; }
        public Guid EventId { get; set; }
        public Guid ComedianId { get; set; }
        public virtual Comedian Comedian { get; set; }
        public virtual Event Event { get; set; }
    }
}
