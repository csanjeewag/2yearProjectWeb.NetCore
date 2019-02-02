using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMS.Data.Models
{
    public class VotedEmployees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Poll")]
        public int PollId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
    }
}
