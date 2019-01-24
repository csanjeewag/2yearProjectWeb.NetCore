using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Data.GetModels
{
  public  class GetCricketTeam
    {
        public string TeamName { get; set; }
        public int TeamCaptainId { get; set; }
        public List<int> TeamMembers { get; set; }
        public string Description { get; set; }
        public int EventId { get; set; }
        public int VageCount { get; set; }
        public int LiquorCount { get; set; }
    }
}
