using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComedyEvents.Domain.Models
{
    public partial class Comedian
    {
        [Required]
        [StringLength(60)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(15)]
        public string ContactPhone { get; set; }
    }
}
