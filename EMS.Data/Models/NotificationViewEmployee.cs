using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMS.Data.Models
{
  public  class NotificationViewEmployee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
     
        public int EmployeeId { get; set; }    
     
        public int NotificationId { get; set; }
        public Boolean View { get; set; }
    
    }
}
