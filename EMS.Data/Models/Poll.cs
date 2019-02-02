using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMS.Data.Models
{
    public class Poll

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ClosingDate { get; set; }
        public Boolean IsActive { get; set; }

        public IEnumerable<Destination> Destinations { get; set; }
        public IEnumerable<VotedEmployees> VotedEmployee { get; set; }


    }
}
