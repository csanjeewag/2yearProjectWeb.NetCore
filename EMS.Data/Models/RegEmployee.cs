using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMS.Data.Models
{
    public class RegEmployee
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string MealType { get; set; }
        public string Nic { get; set; }
        public string Accomadation { get; set; }
        public string Gender { get; set; }
        public string TransportationMode { get; set; }
        public string SpouseName { get; set; }
        public string SpouseNic { get; set; }
        public DateTime Dob { get; set; }
        public DateTime SpouseDob { get; set; }
        public Boolean IsActive { get; set; }
        [ForeignKey("Event")]
        public int EventId { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

    }
}
