using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComedyEvents.Domain.Models
{
    public partial class User
    {

        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(80)]
        public string FirstName { get; set; }
        public int Age { get; set; }
        [StringLength(30)]
        public string UserName { get; set; }
        [StringLength(30)]
        public string Pwd { get; set; }
        public string Token { get; set; }
    }
}
