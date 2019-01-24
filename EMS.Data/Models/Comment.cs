using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Data.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }
        [ForeignKey("Event")]
        public int EventId { get; set; }
        public DateTime CommentTime { get; set; }
        [ForeignKey("Employee")]
        public string Author { get; set; }
        public string CommentIn { get; set; } 

    }
}
