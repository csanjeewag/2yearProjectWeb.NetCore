using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMS.Data.Models
{
   public class TeamMember
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }
        [ForeignKey("CricketTeamRegister")]
        public int CricketTeamRegisterId { get; set; }
        public Boolean IsActive { get; set; }
    }
}
