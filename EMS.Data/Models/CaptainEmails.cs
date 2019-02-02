using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMS.Data.Models
{
  public  class CaptainEmails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public DateTime senderdate { get; set; }
        [ForeignKey("Event")]
        public int EventId { get; set; }
        public int SenderId { get; set; }
        [NotMapped]
        public string Eventname { get; set; }
        [NotMapped]
        public string Sendername { get; set; } 


    }
}
