using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMS.Data.Models
{
    public class EventAttribute
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Boolean Destination { get; set; }
        public Boolean EndDate { get; set; }
        public Boolean ClosingDate { get; set; }
        public Boolean Liquor { get; set; }
        public Boolean IsFamilyMembersAllowed { get; set; }
        public Boolean Venue { get; set; }
        public Boolean NumberOfTeams { get; set; }
        public Boolean BudgetedCost { get; set; }
        public Boolean ActualCost { get; set; }
        public Boolean MainOrganiZer { get; set; }
        public Boolean Summary { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }
    }
}
