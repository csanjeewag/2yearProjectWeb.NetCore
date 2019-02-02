using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Data.ViewModels
{
  public  class ViewTeamMember
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string TeamName { get; set; }    
        public string Capatain { get; set; }
        public List<string> EmployeeNames { get; set; }
        public int VegeCount { get; set; }
        public int LiquorCount { get; set; }
        public string Description { get; set; }
        public DateTime Registerdate { get; set; }
        
       
    }
}
