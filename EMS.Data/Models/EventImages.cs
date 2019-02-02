using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMS.Data.Models
{
   public class EventImages
    {
        [Key]
        public string ImageId { get; set; }      
        public string Caption { get; set; }
        public string Description { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; } 
        [ForeignKey("Event")]
        public int EventId { get; set; }
        [NotMapped]
        public string Author { get; set; }
        
}
}
