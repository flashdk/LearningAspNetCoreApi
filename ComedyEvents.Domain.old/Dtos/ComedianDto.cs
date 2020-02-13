using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComedyEvents.Dto
{
    
    public class ComedianDto
    {

       //private DateTime _createdAt;

       // public DateTime CreatedAt
       // {
       //     get { return _createdAt; }
       // }

       // public ComedianDto(DateTime createdAt)
       // {
       //     _createdAt = createdAt;
       // }

       // public ComedianDto()
       // {
       //     _createdAt = DateTime.UtcNow;
       // }

       // private int taille;

       // public int Taille
       // {
       //     get { return taille; }
       //     set 
       //     {
       //         if(taille > 0.2 && taille < 3)
       //         {
       //             taille = value;
       //         }
       //         else
       //         {
       //             throw new Exception("La taille doit etre comprise entre 0,2 et 3m");
       //         }
       //     }
       // }
             
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string ContactPhone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
