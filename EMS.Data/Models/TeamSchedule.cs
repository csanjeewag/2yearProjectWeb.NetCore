using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMS.Data.Models
{
   public class TeamSchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Boolean IsActive { get; set; }
        public string SchName { get; set; }
        public DateTime SchDate { get; set; }
        public string Description { get; set; }
        public int EventId { get; set; }
        public int team1 { get; set; }
        public int team2 { get; set; }
        public int team3 { get; set; }
        public int team4 { get; set; }
        public int team5 { get; set; }
        public int team6 { get; set; }
        public int team7 { get; set; }
        public int team8 { get; set; }
        public int team9 { get; set; }
        public int team10 { get; set; }
        public int team11 { get; set; }
        public int team12 { get; set; }
        public int team13 { get; set; }
        public int team14 { get; set; }
        public int team15 { get; set; }
        public int team16 { get; set; }
    }
}
