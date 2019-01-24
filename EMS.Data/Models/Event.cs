using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace EMS.Data.Models
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public string Liquor { get; set; }
        public string IsFamilyMembersAllowed { get; set; }
        public string Venue { get; set; }
        public string NumberOfTeams { get; set; }
        public string EventImageUrl { get; set; }

        [ForeignKey("Eventtype")]
        public int EventTypeId { get; set; }
        [NotMapped]
        public IFormFile EventImage { get; set; }




    }
}
