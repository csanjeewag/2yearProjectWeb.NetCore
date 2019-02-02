using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMS.Data.Models
{
    public class RegistrationAttribute
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public Boolean Nic { get; set; }
        public Boolean Dob { get; set; }
        public Boolean SpouseDob { get; set; }
        public Boolean TransportationMode { get; set; }
        public Boolean Accomadation { get; set; }
        public Boolean MealType { get; set; }
        public Boolean Gender { get; set; }
        public Boolean SpouseName { get; set; }
        public Boolean SpouseNic { get; set; }

        


       [ForeignKey("Event")]
        public int EventId { get; set; }
    }
}
