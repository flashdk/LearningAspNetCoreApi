using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyEvents.Domain.Models
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
