using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComedyEvents.Domain.Models
{
    public partial class Venue
    {

        [Required]
        [StringLength(30)]
        public string VenueName { get; set; }
        [StringLength(80)]
        public string Street { get; set; }
        [StringLength(80)]
        public string City { get; set; }
        [StringLength(30)]
        public string State { get; set; }
        [StringLength(6)]
        public string ZipCode { get; set; }
        public int Seating { get; set; }
        public bool? ServesAlcohol { get; set; }
    }
}
