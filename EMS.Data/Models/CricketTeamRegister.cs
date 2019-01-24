using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMS.Data.Models
{
   public class CricketTeamRegister
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Event")]
        public int EventId { get; set; }
        public string TeamName { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public int VegeCount { get; set; }
        public int LiquorCount { get; set; }
        public Boolean IsActive { get; set; }
        public string Description { get; set; }
        public DateTime Registerdate { get; set; }
        public virtual ICollection<TeamMember> TeamMembers { get; set; }

    }
}
