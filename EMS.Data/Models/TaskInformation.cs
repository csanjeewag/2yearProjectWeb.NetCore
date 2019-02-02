using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Data.Models
{
    public class TaskInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int InfoID { get; set; }
        public string InfoDescription { get; set; }
        public Boolean IsComplete { get; set; }
        public Boolean IsActive { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [ForeignKey("Task")]
        public int TaskTaskId { get; set; }

       [ForeignKey("Contact")]
       public int ContactContactId { get; set; }
        [NotMapped]
        public string EventName { get; set; }

        
    }
}
