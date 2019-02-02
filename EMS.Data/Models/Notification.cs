using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMS.Data.Models
{
  public  class Notification
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public string DataType { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }
        public int EmployeeId { get; set; }
        public int TaskId { get; set; }
        public int EventId { get; set; }
        public Boolean View { get; set; }
        public Boolean All { get; set; }
        [NotMapped]
        public int count { get; set; }
        
        public string Sendernme { get; set; }
        [NotMapped]
        public int senderId { get; set; }
      //  public virtual NotificationViewEmployee NotificationViewEmployee { get; set; }

    }
}
